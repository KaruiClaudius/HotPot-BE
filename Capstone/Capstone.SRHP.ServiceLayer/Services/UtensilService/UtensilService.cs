using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.UtensilService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.UtensilService
{
    public class UtensilService : IUtensilService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UtensilService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            var query = _unitOfWork.Repository<Utensil>()
                .Include(u => u.UtensilType)
                .Where(u => !u.IsDelete);

            // Apply filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(u =>
                    u.Name.ToLower().Contains(searchTerm) ||
                    u.Description.ToLower().Contains(searchTerm) ||
                    u.Material.ToLower().Contains(searchTerm));
            }

            if (typeId.HasValue)
            {
                query = query.Where(u => u.UtensilTypeID == typeId.Value);
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
            var utensil = await _unitOfWork.Repository<Utensil>()
                .Include(u => u.UtensilType)
                .FirstOrDefaultAsync(u => u.UtensilId == id && !u.IsDelete);

            if (utensil == null)
                throw new NotFoundException($"Không tìm thấy công cụ");

            return utensil;
        }

        public async Task<Utensil> CreateUtensilAsync(Utensil entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Tên không được trống");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Chất liệu không được trống");

            if (entity.Price <= 0)
                throw new ValidationException("Giá phải lớn hơn 0");

            if (entity.Quantity < 0)
                throw new ValidationException("số lượng không được âm");

            // Validate UtensilType exists
            var utensilType = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.UtensilTypeId == entity.UtensilTypeID && !ut.IsDelete);

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
                    existingUtensil.UtensilTypeID = entity.UtensilTypeID;
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
        }

        public async Task UpdateUtensilAsync(int id, Utensil entity)
        {
            var existingUtensil = await GetUtensilByIdAsync(id);

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Tên không được trống");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Chất liệu không được trống");

            if (entity.Price <= 0)
                throw new ValidationException("Giá phải lớn hơn 0");

            if (entity.Quantity < 0)
                throw new ValidationException("số lượng không được âm");

            // Validate UtensilType exists
            var utensilType = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.UtensilTypeId == entity.UtensilTypeID && !ut.IsDelete);

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
            existingUtensil.UtensilTypeID = entity.UtensilTypeID;
            existingUtensil.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUtensilAsync(int id)
        {
            var utensil = await GetUtensilByIdAsync(id);
            utensil.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateUtensilStatusAsync(int id, bool status)
        {
            var utensil = await GetUtensilByIdAsync(id);
            utensil.Status = status;
            utensil.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateUtensilQuantityAsync(int id, int quantity)
        {
            var utensil = await GetUtensilByIdAsync(id);

            if (utensil.Quantity + quantity < 0)
                throw new ValidationException("không được giảm xuống quá 0");

            utensil.Quantity += quantity;
            utensil.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsUtensilAvailableAsync(int id)
        {
            var utensil = await _unitOfWork.Repository<Utensil>()
                .FindAsync(u => u.UtensilId == id && !u.IsDelete);

            return utensil != null && utensil.Status && utensil.Quantity > 0;
        }

        #endregion

        #region Utensil Type Methods

        public async Task<IEnumerable<UtensilType>> GetAllUtensilTypesAsync()
        {
            return await _unitOfWork.Repository<UtensilType>()
                .FindAll(ut => !ut.IsDelete)
                .ToListAsync();
        }

        public async Task<UtensilType> GetUtensilTypeByIdAsync(int id)
        {
            var utensilType = await _unitOfWork.Repository<UtensilType>()
                .FindAsync(ut => ut.UtensilTypeId == id && !ut.IsDelete);

            if (utensilType == null)
                throw new NotFoundException($"không tìm thấy dụng cụ");

            return utensilType;
        }

        public async Task<UtensilType> CreateUtensilTypeAsync(string name)
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
        }

        public async Task DeleteUtensilTypeAsync(int id)
        {
            var type = await GetUtensilTypeByIdAsync(id);

            // Check if type is in use
            var isInUse = await _unitOfWork.Repository<Utensil>()
                .AnyAsync(u => u.UtensilTypeID == id && !u.IsDelete);

            if (isInUse)
                throw new ValidationException("loại này đang được sử dụng, không thể xoá");

            type.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<Dictionary<int, int>> GetUtensilCountsByTypesAsync(IEnumerable<int> typeIds)
        {
            var counts = await _unitOfWork.Repository<Utensil>()
                .FindAll(u => !u.IsDelete && typeIds.Contains(u.UtensilTypeID))
                .GroupBy(u => u.UtensilTypeID)
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

        #endregion
    }
}
