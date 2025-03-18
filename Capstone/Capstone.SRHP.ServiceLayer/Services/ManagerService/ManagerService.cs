using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int MANAGER_ROLE_ID = 2; // Manager role ID

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetManagerByIdAsync(int userId)
        {
            var manager = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .Include(u => u.MangerWorkShifts)
                .FirstOrDefaultAsync(u => u.UserId == userId && u.RoleId == MANAGER_ROLE_ID && !u.IsDelete);

            if (manager == null)
                throw new NotFoundException($"Manager with ID {userId} not found");

            return manager;
        }

        public async Task<IEnumerable<User>> GetAllManagersAsync()
        {
            return await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .Include(u => u.MangerWorkShifts)
                .Where(u => u.RoleId == MANAGER_ROLE_ID && !u.IsDelete)
                .ToListAsync();
        }

        public async Task<User> CreateManagerAsync(User manager)
        {
            // Ensure the user has the manager role
            manager.RoleId = MANAGER_ROLE_ID;

            _unitOfWork.Repository<User>().Insert(manager);
            await _unitOfWork.CommitAsync();
            return manager;
        }

        public async Task UpdateManagerAsync(int userId, User managerUpdate)
        {
            var existingManager = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && u.RoleId == MANAGER_ROLE_ID);

            if (existingManager == null)
                throw new NotFoundException($"Manager with ID {userId} not found");

            // Update properties as needed
            existingManager.WorkDays = managerUpdate.WorkDays;
            existingManager.Name = managerUpdate.Name;
            existingManager.Email = managerUpdate.Email;
            existingManager.PhoneNumber = managerUpdate.PhoneNumber;
            existingManager.Address = managerUpdate.Address;
            existingManager.Note = managerUpdate.Note;
            existingManager.ImageURL = managerUpdate.ImageURL;
            existingManager.SetUpdateDate();

            // Using the approach from source [0] to update entity properties
            // This is a cleaner way to update multiple properties
            // _unitOfWork.Context.Entry(existingManager).CurrentValues.SetValues(managerUpdate);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteManagerAsync(int userId)
        {
            var manager = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && u.RoleId == MANAGER_ROLE_ID);

            if (manager == null)
                throw new NotFoundException($"Manager with ID {userId} not found");

            manager.SoftDelete();
            manager.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task AssignWorkShiftsAsync(int userId, IEnumerable<WorkShift> workShifts)
        {
            var manager = await _unitOfWork.Repository<User>()
                .Include(u => u.MangerWorkShifts)
                .FirstOrDefaultAsync(u => u.UserId == userId && u.RoleId == MANAGER_ROLE_ID);

            if (manager == null)
                throw new NotFoundException($"Manager with ID {userId} not found");

            // Verify that all work shifts have days that match the manager's work days
            if (manager.WorkDays.HasValue)
            {
                foreach (var shift in workShifts)
                {
                    if ((shift.DaysOfWeek & manager.WorkDays.Value) == 0)
                    {
                        throw new ValidationException($"Work shift with ID {shift.Id} has days that don't match the manager's work days");
                    }
                }
            }

            // Clear existing work shifts and add the new ones
            if (manager.MangerWorkShifts != null)
            {
                // Detach the manager from all current work shifts
                foreach (var shift in manager.MangerWorkShifts.ToList())
                {
                    shift.Managers.Remove(manager);
                }

                // Clear the manager's work shifts collection
                manager.MangerWorkShifts.Clear();

                // Add the new work shifts
                foreach (var shift in workShifts)
                {
                    manager.MangerWorkShifts.Add(shift);
                    if (!shift.Managers.Contains(manager))
                    {
                        shift.Managers.Add(manager);
                    }
                }
            }

            manager.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }
    }
}