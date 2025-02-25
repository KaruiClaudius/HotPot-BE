
using Azure.Core;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services
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

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == id && !u.IsDelete);

            if (user == null)
                throw new NotFoundException($"User with ID {id} not found");

            return user;
        }
        public async Task<User> CreateAsync(User entity)
        {
            try
            {
                // Check if user exists (including soft-deleted)
                var existingUser = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.Email == entity.Email);

                User resultUser;

                if (existingUser != null)
                {
                    if (!existingUser.IsDelete)
                    {
                        throw new ValidationException("Email already in use");
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(entity.Password);

                    // Reactivate the soft-deleted user
                    existingUser.IsDelete = false;
                    existingUser.Name = entity.Name;
                    existingUser.Password = hashedPassword;
                    existingUser.PhoneNumber = entity.PhoneNumber;
                    existingUser.Address = entity.Address;
                    existingUser.ImageURL = entity.ImageURL;
                    existingUser.RoleID = entity.RoleID;
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
                var existingUser = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == id);

                if (existingUser == null)
                    throw new NotFoundException($"User with ID {id} not found");

                // If role is changing, handle role-specific tables
                if (existingUser.RoleID != entity.RoleID)
                {
                    await HandleRoleChangeAsync(existingUser, entity.RoleID);
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
                    throw new NotFoundException($"User with ID {id} not found");

                // Soft delete role-specific entry
                var role = await _unitOfWork.Repository<Role>()
                    .FindAsync(r => r.RoleId == user.RoleID);

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
                        .FindAsync(c => c.UserID == userId && !c.IsDelete);

                case "staff":
                    return await _unitOfWork.Repository<Staff>()
                        .Include(s => s.WorkShifts)
                        .Include(s => s.ShippingOrders)
                        .FirstOrDefaultAsync(s => s.UserID == userId && !s.IsDelete);

                case "manager":
                    return await _unitOfWork.Repository<Manager>()
                        .Include(m => m.WorkShifts)
                        .FirstOrDefaultAsync(m => m.UserID == userId && !m.IsDelete);

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
                    .GetAll(u => u.RoleID == roleId && !u.IsDelete)
                    .Include(u => u.Role);

                // Now ToListAsync will work
                return await query.ToListAsync();
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
                throw new NotFoundException($"User with ID {id} not found");

            user.Password = PasswordTools.HashPassword(newPassword);
            user.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        private async Task HandleRoleChangeAsync(User user, int newRoleId)
        {
            // Get old and new role names
            var oldRole = await _unitOfWork.Repository<Role>()
                .FindAsync(r => r.RoleId == user.RoleID);
            var newRole = await _unitOfWork.Repository<Role>()
                .FindAsync(r => r.RoleId == newRoleId);

            if (oldRole == null || newRole == null)
                throw new ValidationException("Role not found");

            // Soft delete old role-specific entry
            await SoftDeleteRoleSpecificEntryAsync(user.UserId, oldRole.Name);

            // Create new role-specific entry
            user.RoleID = newRoleId;
            await CreateRoleSpecificEntryAsync(user);
        }

        private async Task SoftDeleteRoleSpecificEntryAsync(int userId, string roleName)
        {
            switch (roleName.ToLower())
            {
                case "customer":
                    var customer = await _unitOfWork.Repository<Customer>()
                        .FindAsync(c => c.UserID == userId);
                    if (customer != null)
                    {
                        customer.IsDelete = true;
                        customer.SetUpdateDate();
                    }
                    break;

                case "staff":
                    var staff = await _unitOfWork.Repository<Staff>()
                        .FindAsync(s => s.UserID == userId);
                    if (staff != null)
                    {
                        staff.IsDelete = true;
                        staff.SetUpdateDate();
                    }
                    break;

                case "manager":
                    var manager = await _unitOfWork.Repository<Manager>()
                        .FindAsync(m => m.UserID == userId);
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
                    .FindAsync(r => r.RoleId == user.RoleID);

                if (role == null)
                    throw new ValidationException($"Role with ID {user.RoleID} not found");

                // Create or reactivate role-specific record based on role
                switch (role.Name.ToLower())
                {
                    case "customer":
                        var existingCustomer = await _unitOfWork.Repository<Customer>()
                            .FindAsync(c => c.UserID == user.UserId);

                        if (existingCustomer != null)
                        {
                            existingCustomer.IsDelete = false;
                            existingCustomer.SetUpdateDate();
                        }
                        else
                        {
                            var customer = new Customer
                            {
                                UserID = user.UserId,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow
                            };
                            _unitOfWork.Repository<Customer>().Insert(customer);
                        }
                        break;

                    case "staff":
                        var existingStaff = await _unitOfWork.Repository<Staff>()
                            .FindAsync(s => s.UserID == user.UserId);

                        if (existingStaff != null)
                        {
                            existingStaff.IsDelete = false;
                            existingStaff.SetUpdateDate();
                        }
                        else
                        {
                            var staff = new Staff
                            {
                                UserID = user.UserId,
                                CreatedAt = DateTime.UtcNow,
                                UpdatedAt = DateTime.UtcNow
                            };
                            _unitOfWork.Repository<Staff>().Insert(staff);
                        }
                        break;

                    case "manager":
                        var existingManager = await _unitOfWork.Repository<Manager>()
                            .FindAsync(m => m.UserID == user.UserId);

                        if (existingManager != null)
                        {
                            existingManager.IsDelete = false;
                            existingManager.SetUpdateDate();
                        }
                        else
                        {
                            var manager = new Manager
                            {
                                UserID = user.UserId,
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
                throw new Exception($"Error creating role-specific entry for user", ex);
            }
        }
    }
}
