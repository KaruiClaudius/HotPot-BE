using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.UserService
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Role>()
                .Include(r => r.Users)
                .Where(r => !r.IsDelete)
                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Role>()
                .Include(r => r.Users)
                .FirstOrDefaultAsync(r => r.RoleId == id && !r.IsDelete);
        }

        public async Task<Role> CreateAsync(Role entity)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Role name cannot be empty");

            // Check for duplicate names
            var existingRole = await _unitOfWork.Repository<Role>()
                .FindAsync(r => r.Name == entity.Name && !r.IsDelete);

            if (existingRole != null)
                throw new ValidationException($"Role with name '{entity.Name}' already exists");

            // Initialize collections
            entity.Users ??= new List<User>();

            _unitOfWork.Repository<Role>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, Role entity)
        {
            var existingRole = await GetByIdAsync(id);
            if (existingRole == null)
                throw new NotFoundException($"Role with ID {id} not found");

            // Validate name
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Role name cannot be empty");

            // Check for duplicate names (excluding current role)
            var duplicateRole = await _unitOfWork.Repository<Role>()
                .FindAsync(r => r.Name == entity.Name && r.RoleId != id && !r.IsDelete);

            if (duplicateRole != null)
                throw new ValidationException($"Role with name '{entity.Name}' already exists");

            // Prevent modification of system roles
            if (IsSystemRole(existingRole.Name) && existingRole.Name != entity.Name)
                throw new ValidationException($"Cannot modify system role name: {existingRole.Name}");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<Role>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await GetByIdAsync(id);
            if (role == null)
                throw new NotFoundException($"Role with ID {id} not found");

            // Prevent deletion of system roles
            if (IsSystemRole(role.Name))
                throw new ValidationException($"Cannot delete system role: {role.Name}");

            // Check if role is in use
            if (await IsRoleInUseAsync(id))
                throw new ValidationException("Cannot delete role that is assigned to users");

            role.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Role name cannot be empty");

            return await _unitOfWork.Repository<Role>()
                        .Include(r => r.Users)
                        .FirstOrDefaultAsync(r => r.Name == name && !r.IsDelete);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(int roleId)
        {
            var role = await GetByIdAsync(roleId);
            if (role == null)
                throw new NotFoundException($"Role with ID {roleId} not found");

            return role.Users?.Where(u => !u.IsDelete).ToList() ?? new List<User>();
        }

        public async Task<bool> IsRoleInUseAsync(int roleId)
        {
            var role = await GetByIdAsync(roleId);
            return role?.Users?.Any(u => !u.IsDelete) == true;
        }

        //public async Task UpdatePermissionsAsync(int roleId, IEnumerable<string> permissions)
        //{
        //    var role = await GetByIdAsync(roleId);
        //    if (role == null)
        //        throw new NotFoundException($"Role with ID {roleId} not found");

        //    // Prevent modification of system role permissions
        //    if (IsSystemRole(role.Name))
        //        throw new ValidationException($"Cannot modify system role permissions: {role.Name}");

        //    // Update permissions logic here
        //    // This depends on how you store permissions in your Role entity
        //    // For example, if you store them as a comma-separated string:
        //    role.Permissions = string.Join(",", permissions);

        //    role.SetUpdateDate();
        //    await _unitOfWork.CommitAsync();
        //}

        private bool IsSystemRole(string roleName)
        {
            var systemRoles = new[] { "Admin", "Manager", "Staff" };
            return systemRoles.Contains(roleName, StringComparer.OrdinalIgnoreCase);
        }
    }
}
