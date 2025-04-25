using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.HotpotService
{
    public class UtensilService : IUtensilService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UtensilService> _logger;

        public UtensilService(IUnitOfWork unitOfWork, ILogger<UtensilService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region Utensil Methods

        public async Task<PagedResult<Utensil>> GetUtensilsAsync(
        string searchTerm = null,
        int? typeId = null,
        bool? isAvailable = null,
        int pageNumber = 1,
        int pageSize = 10,
        string sortBy = "Name",
        bool ascending = true)
        {
            try
            {
                var query = _unitOfWork.Repository<Utensil>()
                    .Include(u => u.UtensilType)
                    .Where(u => !u.IsDelete);

                // Apply filters
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(i =>
                        EF.Functions.Collate(i.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        EF.Functions.Collate(i.Material.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        i.Description != null && EF.Functions.Collate(i.Description.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm)
                    );
                }

                if (typeId.HasValue)
                {
                    query = query.Where(u => u.UtensilTypeId == typeId.Value);
                }

                if (isAvailable.HasValue)
                {
                    if (isAvailable.Value)
                    {
                        query = query.Where(u => u.Status && u.Quantity > 0);
                    }
                    else
                    {
                        query = query.Where(u => !u.Status || u.Quantity <= 0);
                    }
                }

                // Apply sorting
                query = ApplySorting(query, sortBy, ascending);

                // Get total count before pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PagedResult<Utensil>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensils with filters");
                throw;
            }
        }

        private IQueryable<Utensil> ApplySorting(IQueryable<Utensil> query, string sortBy, bool ascending)
        {
            switch (sortBy?.ToLower())
            {
                case "utensilid":
                    return ascending ? query.OrderBy(u => u.UtensilId) : query.OrderByDescending(u => u.UtensilId);
                case "price":
                    return ascending ? query.OrderBy(u => u.Price) : query.OrderByDescending(u => u.Price);
                case "quantity":
                    return ascending ? query.OrderBy(u => u.Quantity) : query.OrderByDescending(u => u.Quantity);
                case "material":
                    return ascending ? query.OrderBy(u => u.Material) : query.OrderByDescending(u => u.Material);
                case "lastmaintaindate":
                    return ascending ? query.OrderBy(u => u.LastMaintainDate) : query.OrderByDescending(u => u.LastMaintainDate);
                case "type":
                case "typename":
                    return ascending
                        ? query.OrderBy(u => u.UtensilType.Name)
                        : query.OrderByDescending(u => u.UtensilType.Name);
                case "createdat":
                    return ascending ? query.OrderBy(u => u.CreatedAt) : query.OrderByDescending(u => u.CreatedAt);
                case "updatedat":
                    return ascending ? query.OrderBy(u => u.UpdatedAt) : query.OrderByDescending(u => u.UpdatedAt);
                case "name":
                default:
                    return ascending ? query.OrderBy(u => u.Name) : query.OrderByDescending(u => u.Name);
            }
        }

        public async Task<Utensil> GetUtensilByIdAsync(int id)
        {
            try
            {
                var utensil = await _unitOfWork.Repository<Utensil>()
                    .Include(u => u.UtensilType)
                    .FirstOrDefaultAsync(u => u.UtensilId == id && !u.IsDelete);

                if (utensil == null)
                    throw new NotFoundException($"Không tìm thấy công cụ");

                return utensil;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil with ID {UtensilId}", id);
                throw;
            }
        }

        public async Task<Utensil> CreateUtensilAsync(Utensil entity)
        {
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Validate basic properties
                ValidateUtensilBasicProperties(entity);

                // Validate UtensilType exists
                var utensilType = await _unitOfWork.Repository<UtensilType>()
                    .FindAsync(ut => ut.UtensilTypeId == entity.UtensilTypeId && !ut.IsDelete);

                if (utensilType == null)
                    throw new ValidationException("loại dụng cụ không hợp lệ");

                // Check if utensil exists (including soft-deleted)
                var existingUtensil = await _unitOfWork.Repository<Utensil>()
                    .FindAsync(u => u.Name == entity.Name);

                if (existingUtensil != null)
                {
                    if (!existingUtensil.IsDelete)
                    {
                        throw new ValidationException($"Dụng cụ này đã tồn tại");
                    }
                    else
                    {
                        // Reactivate and update the soft-deleted utensil
                        existingUtensil.IsDelete = false;
                        existingUtensil.Material = entity.Material;
                        existingUtensil.Description = entity.Description;
                        existingUtensil.ImageURL = entity.ImageURL;
                        existingUtensil.Price = entity.Price;
                        existingUtensil.Status = entity.Status;
                        existingUtensil.Quantity = entity.Quantity;
                        existingUtensil.UtensilTypeId = entity.UtensilTypeId;
                        existingUtensil.LastMaintainDate = DateTime.UtcNow;
                        existingUtensil.SetUpdateDate();
                        await _unitOfWork.CommitAsync();
                        return existingUtensil;
                    }
                }

                entity.LastMaintainDate = DateTime.UtcNow;
                _unitOfWork.Repository<Utensil>().Insert(entity);
                await _unitOfWork.CommitAsync();
                return entity;
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error creating utensil");
                }
            });
        }

        public async Task UpdateUtensilAsync(int id, Utensil entity)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var existingUtensil = await GetUtensilByIdAsync(id);

                // Validate basic properties
                ValidateUtensilBasicProperties(entity);

                // Validate UtensilType exists
                var utensilType = await _unitOfWork.Repository<UtensilType>()
                    .FindAsync(ut => ut.UtensilTypeId == entity.UtensilTypeId && !ut.IsDelete);

                if (utensilType == null)
                    throw new ValidationException("loại dụng cụ không hợp lệ");

                // Check if name is unique (excluding current entity)
                var nameExists = await _unitOfWork.Repository<Utensil>()
                    .AnyAsync(u => u.Name == entity.Name && u.UtensilId != id && !u.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Dụng cụ này đã tồn tại");

                // Update properties
                existingUtensil.Name = entity.Name;
                existingUtensil.Material = entity.Material;
                existingUtensil.Description = entity.Description;
                existingUtensil.ImageURL = entity.ImageURL;
                existingUtensil.Price = entity.Price;
                existingUtensil.Status = entity.Status;
                existingUtensil.Quantity = entity.Quantity;
                existingUtensil.UtensilTypeId = entity.UtensilTypeId;
                existingUtensil.SetUpdateDate();

                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error updating utensil with ID {UtensilId}", id);
                }
            });
        }

        public async Task DeleteUtensilAsync(int id)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var utensil = await GetUtensilByIdAsync(id);

                // Check if the utensil is referenced in any SellOrderDetails
                var isInUse = await _unitOfWork.Repository<SellOrderDetail>()
                    .AnyAsync(s => s.UtensilId == id && !s.IsDelete);

                if (isInUse)
                    throw new ValidationException("Dụng cụ này đang được sử dụng trong đơn hàng, không thể xóa");

                utensil.SoftDelete();
                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error deleting utensil with ID {UtensilId}", id);
                }
            });
        }

        public async Task UpdateUtensilStatusAsync(int id, bool status)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var utensil = await GetUtensilByIdAsync(id);
                utensil.Status = status;
                utensil.SetUpdateDate();
                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error updating status for utensil with ID {UtensilId}", id);
                }
            });
        }

        public async Task UpdateUtensilQuantityAsync(int id, int quantity)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var utensil = await GetUtensilByIdAsync(id);

                if (utensil.Quantity + quantity < 0)
                    throw new ValidationException("không được giảm xuống quá 0");

                utensil.Quantity += quantity;
                utensil.SetUpdateDate();
                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error updating quantity for utensil with ID {UtensilId}", id);
                }
            });
        }

        public async Task<bool> IsUtensilAvailableAsync(int id)
        {
            try
            {
                var utensil = await _unitOfWork.Repository<Utensil>()
                    .FindAsync(u => u.UtensilId == id && !u.IsDelete);

                return utensil != null && utensil.Status && utensil.Quantity > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking availability for utensil with ID {UtensilId}", id);
                throw;
            }
        }

        // Helper method to validate basic properties
        private void ValidateUtensilBasicProperties(Utensil entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Tên không được trống");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Chất liệu không được trống");

            if (entity.Price <= 0)
                throw new ValidationException("Giá phải lớn hơn 0");

            if (entity.Quantity < 0)
                throw new ValidationException("số lượng không được âm");
        }

        #endregion

        #region Utensil Type Methods

        public async Task<IEnumerable<UtensilType>> GetAllUtensilTypesAsync()
        {
            try
            {
                return await _unitOfWork.Repository<UtensilType>()
                    .FindAll(ut => !ut.IsDelete)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all utensil types");
                throw;
            }
        }

        public async Task<UtensilType> GetUtensilTypeByIdAsync(int id)
        {
            try
            {
                var utensilType = await _unitOfWork.Repository<UtensilType>()
                    .FindAsync(ut => ut.UtensilTypeId == id && !ut.IsDelete);

                if (utensilType == null)
                    throw new NotFoundException($"không tìm thấy dụng cụ");

                return utensilType;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil type with ID {UtensilTypeId}", id);
                throw;
            }
        }

        public async Task<UtensilType> CreateUtensilTypeAsync(string name)
        {
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ValidationException("Tên không được trống");

                // Check if name is unique
                var nameExists = await _unitOfWork.Repository<UtensilType>()
                    .AnyAsync(ut => ut.Name == name && !ut.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Dụng cụ này đã tồn tại");

                var utensilType = new UtensilType { Name = name };
                _unitOfWork.Repository<UtensilType>().Insert(utensilType);
                await _unitOfWork.CommitAsync();
                return utensilType;
            },
            ex =>
            {
                if (!(ex is ValidationException))
                {
                    _logger.LogError(ex, "Error creating utensil type with name {Name}", name);
                }
            });
        }

        public async Task DeleteUtensilTypeAsync(int id)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var type = await GetUtensilTypeByIdAsync(id);

                // Check if type is in use
                var isInUse = await _unitOfWork.Repository<Utensil>()
                    .AnyAsync(u => u.UtensilTypeId == id && !u.IsDelete);

                if (isInUse)
                    throw new ValidationException("loại này đang được sử dụng, không thể xoá");

                type.SoftDelete();
                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error deleting utensil type with ID {UtensilTypeId}", id);
                }
            });
        }


        public async Task<Dictionary<int, int>> GetUtensilCountsByTypesAsync(IEnumerable<int> typeIds)
        {
            try
            {
                var counts = await _unitOfWork.Repository<Utensil>()
                    .FindAll(u => !u.IsDelete && typeIds.Contains(u.UtensilTypeId))
                    .GroupBy(u => u.UtensilTypeId)
                    .Select(g => new { TypeId = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.TypeId, x => x.Count);

                // Ensure all requested type IDs are in the dictionary, even if they have no utensils
                foreach (var typeId in typeIds)
                {
                    if (!counts.ContainsKey(typeId))
                    {
                        counts[typeId] = 0;
                    }
                }

                return counts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil counts by types");
                throw;
            }
        }

        public async Task UpdateUtensilTypeAsync(int id, string name)
        {
            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                var type = await GetUtensilTypeByIdAsync(id);

                if (string.IsNullOrWhiteSpace(name))
                    throw new ValidationException("Tên không được trống");

                // Check if name is unique (excluding current type)
                var nameExists = await _unitOfWork.Repository<UtensilType>()
                    .AnyAsync(ut => ut.Name == name && ut.UtensilTypeId != id && !ut.IsDelete);

                if (nameExists)
                    throw new ValidationException($"Loại dụng cụ này đã tồn tại");

                type.Name = name;
                type.SetUpdateDate();
                await _unitOfWork.CommitAsync();
            },
            ex =>
            {
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Error updating utensil type with ID {UtensilTypeId}", id);
                }
            });
        }

        public async Task<int> GetTotalUtensilCountAsync()
        {
            try
            {
                return await _unitOfWork.Repository<Utensil>()
                    .FindAll(u => !u.IsDelete)
                    .CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving total utensil count");
                throw;
            }
        }

        public async Task<int> GetAvailableUtensilCountAsync()
        {
            try
            {
                return await _unitOfWork.Repository<Utensil>()
                    .FindAll(u => !u.IsDelete && u.Status && u.Quantity > 0)
                    .CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving available utensil count");
                throw;
            }
        }

        #endregion
    }
}
