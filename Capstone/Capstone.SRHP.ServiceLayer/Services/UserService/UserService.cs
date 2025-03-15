
using Azure.Core;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .Where(u => !u.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<User>> GetUsersAsync(
     string searchTerm = null,
     int? roleId = null,
     bool? isActive = null,
     DateTime? createdAfter = null,
     DateTime? createdBefore = null,
     int pageNumber = 1,
     int pageSize = 10,
     string sortBy = "Name",
     bool ascending = true)
        {
            // Start with a base query that includes all related entities
            var query = _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .Include(u => u.Customer)
                .Include(u => u.Staff)
                .Include(u => u.Manager)
                .AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(u =>
                    u.Name.ToLower().Contains(searchTerm) ||
                    u.Email.ToLower().Contains(searchTerm) ||
                    (u.PhoneNumber != null && u.PhoneNumber.Contains(searchTerm)));
            }

            if (roleId.HasValue)
            {
                query = query.Where(u => u.RoleId == roleId.Value);
            }

            if (isActive.HasValue)
            {
                query = query.Where(u => u.IsDelete != isActive.Value);
            }

            if (createdAfter.HasValue)
            {
                query = query.Where(u => u.CreatedAt >= createdAfter.Value);
            }

            if (createdBefore.HasValue)
            {
                query = query.Where(u => u.CreatedAt <= createdBefore.Value);
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

            // Return paged result
            return new PagedResult<User>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private IQueryable<User> ApplySorting(IQueryable<User> query, string sortBy, bool ascending)
        {
            // Default to sorting by Name if sortBy is invalid
            switch (sortBy?.ToLower())
            {
                case "userid":
                    return ascending ? query.OrderBy(u => u.UserId) : query.OrderByDescending(u => u.UserId);
                case "email":
                    return ascending ? query.OrderBy(u => u.Email) : query.OrderByDescending(u => u.Email);
                case "roleid":
                case "role":
                    return ascending ? query.OrderBy(u => u.RoleId) : query.OrderByDescending(u => u.RoleId);
                case "createdat":
                case "created":
                    return ascending ? query.OrderBy(u => u.CreatedAt) : query.OrderByDescending(u => u.CreatedAt);
                case "updatedat":
                case "updated":
                    return ascending ? query.OrderBy(u => u.UpdatedAt) : query.OrderByDescending(u => u.UpdatedAt);
                case "name":
                default:
                    return ascending ? query.OrderBy(u => u.Name) : query.OrderByDescending(u => u.Name);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .Include(u=> u.Customer)
                .Include(u=>u.Manager)
                .Include(u=>u.Staff)
                .FirstOrDefaultAsync(u => u.UserId == id && !u.IsDelete);

            if (user == null)
                throw new NotFoundException($"Không tìm thấy tài khoản");

            return user;
        }
        public async Task<User> CreateAsync(User entity)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(entity.PhoneNumber))
                {
                    entity.PhoneNumber = NormalizePhoneNumber(entity.PhoneNumber);
                }

                // Check if user exists (including soft-deleted)
                var existingUser = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.PhoneNumber == entity.PhoneNumber);

                User resultUser;

                if (existingUser != null)
                {
                    if (!existingUser.IsDelete)
                    {
                        throw new ValidationException("SĐT đã tồn tại");
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(entity.Password);

                    // Reactivate the soft-deleted user
                    existingUser.IsDelete = false;
                    existingUser.Name = entity.Name;
                    existingUser.Password = hashedPassword;
                    existingUser.PhoneNumber = entity.PhoneNumber;
                    existingUser.Address = entity.Address;
                    existingUser.ImageURL = entity.ImageURL;
                    existingUser.RoleId = entity.RoleId;
                    existingUser.SetUpdateDate();
                    await _unitOfWork.CommitAsync();

                    // Reactivate role-specific entry
                    await CreateRoleSpecificEntryAsync(existingUser);
                    resultUser = existingUser;
                }
                else
                {
                    // Create new user
                    _unitOfWork.Repository<User>().Insert(entity);
                    await _unitOfWork.CommitAsync();

                    // Create role-specific entry
                    await CreateRoleSpecificEntryAsync(entity);
                    resultUser = entity;
                }

                return resultUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task UpdateAsync(int id, User entity)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(entity.PhoneNumber))
                {
                    entity.PhoneNumber = NormalizePhoneNumber(entity.PhoneNumber);
                }

                var existingUser = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == id);

                if (existingUser == null)
                    throw new NotFoundException($"Không tìm thấy tài khoản");

                // If role is changing, handle role-specific tables
                if (existingUser.RoleId != entity.RoleId)
                {
                    await HandleRoleChangeAsync(existingUser, entity.RoleId);
                }

                // Update user properties
                existingUser.Name = entity.Name;
                existingUser.PhoneNumber = entity.PhoneNumber;
                existingUser.Address = entity.Address;
                existingUser.ImageURL = entity.ImageURL;
                existingUser.SetUpdateDate();

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var user = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == id);

                if (user == null)
                    throw new NotFoundException($"Không tìm thấy tài khoản");

                // Soft delete role-specific entry
                var role = await _unitOfWork.Repository<Role>()
                    .FindAsync(r => r.RoleId == user.RoleId);

                if (role != null)
                {
                    await SoftDeleteRoleSpecificEntryAsync(id, role.Name);
                }

                // Soft delete user
                user.SoftDelete();
                user.SetUpdateDate();

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDelete);
        }

        public async Task<object> GetRoleSpecificDataAsync(int userId)
        {
            var user = await GetByIdAsync(userId);
            if (user?.Role == null) return null;

            switch (user.Role.Name.ToLower())
            {
                case "customer":
                    return await _unitOfWork.Repository<Customer>()
                        .FindAsync(c => c.UserId == userId && !c.IsDelete);

                case "staff":
                    return await _unitOfWork.Repository<Staff>()
                        .Include(s => s.WorkShifts)
                        .Include(s => s.ShippingOrders)
                        .FirstOrDefaultAsync(s => s.UserId == userId && !s.IsDelete);

                case "manager":
                    return await _unitOfWork.Repository<Manager>()
                        .Include(m => m.WorkShifts)
                        .FirstOrDefaultAsync(m => m.UserId == userId && !m.IsDelete);

                default:
                    return null;
            }
        }

        public async Task<IEnumerable<User>> GetByRoleAsync(int roleId)
        {
            try
            {
                // Use the repository method that returns an EF Core queryable
                var query = _unitOfWork.Repository<User>()
                    .GetAll(u => u.RoleId == roleId && !u.IsDelete)
                    .Include(u => u.Role);

                // Now ToListAsync will work
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Role> GetByRoleNameAsync(string roleNAme)
        {
            try
            {
                var query = await _unitOfWork.Repository<Role>()
                    .FindAsync(u => u.Name == roleNAme && !u.IsDelete);

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _unitOfWork.Repository<User>()
                .AnyAsync(u => u.Email == email && !u.IsDelete);
        }

        public async Task UpdatePasswordAsync(int id, string newPassword)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
                throw new NotFoundException($"Không tìm thấy tài khoản");

            user.Password = PasswordTools.HashPassword(newPassword);
            user.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        private string NormalizePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return phoneNumber;

            // Trim any whitespace
            phoneNumber = phoneNumber.Trim();

            // Remove the "+84" prefix (with or without space)
            if (phoneNumber.StartsWith("+84"))
            {
                // Check if there's a space after +84
                if (phoneNumber.Length > 3 && phoneNumber[3] == ' ')
                    phoneNumber = phoneNumber.Substring(4);
                else
                    phoneNumber = phoneNumber.Substring(3);
            }
            // Remove the "0" prefix
            else if (phoneNumber.StartsWith("0"))
            {
                phoneNumber = phoneNumber.Substring(1);
            }

            // Remove any remaining spaces or non-digit characters
            phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            return phoneNumber;
        }

        private async Task HandleRoleChangeAsync(User user, int newRoleId)
        {
            // Get old and new role names
            var oldRole = await _unitOfWork.Repository<Role>()
                .FindAsync(r => r.RoleId == user.RoleId);
            var newRole = await _unitOfWork.Repository<Role>()
                .FindAsync(r => r.RoleId == newRoleId);

            if (oldRole == null || newRole == null)
                throw new ValidationException("Không tìm thấy Role");

            // Soft delete old role-specific entry
            await SoftDeleteRoleSpecificEntryAsync(user.UserId, oldRole.Name);

            // Create new role-specific entry
            user.RoleId = newRoleId;
            await CreateRoleSpecificEntryAsync(user);
        }

        private async Task SoftDeleteRoleSpecificEntryAsync(int userId, string roleName)
        {
            switch (roleName.ToLower())
            {
                case "customer":
                    var customer = await _unitOfWork.Repository<Customer>()
                        .FindAsync(c => c.UserId == userId);
                    if (customer != null)
                    {
                        customer.IsDelete = true;
                        customer.SetUpdateDate();
                    }
                    break;

                case "staff":
                    var staff = await _unitOfWork.Repository<Staff>()
                        .FindAsync(s => s.UserId == userId);
                    if (staff != null)
                    {
                        staff.IsDelete = true;
                        staff.SetUpdateDate();
                    }
                    break;

                case "manager":
                    var manager = await _unitOfWork.Repository<Manager>()
                        .FindAsync(m => m.UserId == userId);
                    if (manager != null)
                    {
                        manager.IsDelete = true;
                        manager.SetUpdateDate();
                    }
                    break;
            }
        }

        private async Task CreateRoleSpecificEntryAsync(User user)
        {
            try
            {
                var role = await _unitOfWork.Repository<Role>()
                    .FindAsync(r => r.RoleId == user.RoleId);

                if (role == null)
                    throw new ValidationException($"Không tìm thấy Role của user {user.Name}");

                // Create or reactivate role-specific record based on role
                switch (role.Name.ToLower())
                {
                    case "customer":
                        var existingCustomer = await _unitOfWork.Repository<Customer>()
                            .FindAsync(c => c.UserId == user.UserId);

                        if (existingCustomer != null)
                        {
                            existingCustomer.IsDelete = false;
                            existingCustomer.SetUpdateDate();
                        }
                        else
                        {
                            var customer = new Customer
                            {
                                UserId = user.UserId,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow
                            };
                            _unitOfWork.Repository<Customer>().Insert(customer);
                        }
                        break;

                    case "staff":
                        var existingStaff = await _unitOfWork.Repository<Staff>()
                            .FindAsync(s => s.UserId == user.UserId);

                        if (existingStaff != null)
                        {
                            existingStaff.IsDelete = false;
                            existingStaff.SetUpdateDate();
                        }
                        else
                        {
                            var staff = new Staff
                            {
                                UserId = user.UserId,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow
                            };
                            _unitOfWork.Repository<Staff>().Insert(staff);
                        }
                        break;

                    case "manager":
                        var existingManager = await _unitOfWork.Repository<Manager>()
                            .FindAsync(m => m.UserId == user.UserId);

                        if (existingManager != null)
                        {
                            existingManager.IsDelete = false;
                            existingManager.SetUpdateDate();
                        }
                        else
                        {
                            var manager = new Manager
                            {
                                UserId = user.UserId,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow
                            };
                            _unitOfWork.Repository<Manager>().Insert(manager);
                        }
                        break;
                }

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mục nhập dành riêng cho role cho người dùng", ex);
            }
        }
    }
}
