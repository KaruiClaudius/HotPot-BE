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
            //existingManager.WorkDays = managerUpdate.WorkDays;
            //existingManager.Name = managerUpdate.Name;
            //existingManager.Email = managerUpdate.Email;
            //existingManager.PhoneNumber = managerUpdate.PhoneNumber;
            //existingManager.Address = managerUpdate.Address;
            //existingManager.Note = managerUpdate.Note;
            //existingManager.ImageURL = managerUpdate.ImageURL;
            //existingManager.SetUpdateDate();

            // Using the approach from source [0] to update entity properties
            // This is a cleaner way to update multiple properties
             _unitOfWork.Context.Entry(existingManager).CurrentValues.SetValues(managerUpdate);

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

        //public async Task AssignWorkShiftsAsync(int userId, IEnumerable<WorkShift> workShifts)
        //{
        //    var manager = await _unitOfWork.Repository<User>()
        //        .AsQueryable(u => u.UserId == userId && u.RoleId == MANAGER_ROLE_ID)
        //        .Include(u => u.MangerWorkShifts)
        //        .FirstOrDefaultAsync();

        //    if (manager == null)
        //        throw new NotFoundException($"Manager with ID {userId} not found");

        //    // Initialize the collection if it's null
        //    if (manager.MangerWorkShifts == null)
        //    {
        //        manager.MangerWorkShifts = new List<WorkShift>();
        //    }

        //    // Get the current work shifts to properly handle the relationship
        //    var currentWorkShifts = manager.MangerWorkShifts.ToList();

        //    // Remove manager from work shifts that are no longer associated
        //    foreach (var shift in currentWorkShifts)
        //    {
        //        if (!workShifts.Any(ws => ws.WorkShiftId == shift.WorkShiftId))
        //        {
        //            // Remove the manager from this shift's Managers collection
        //            if (shift.Managers != null)
        //            {
        //                shift.Managers.Remove(manager);
        //            }

        //            // Remove the shift from the manager's collection
        //            manager.MangerWorkShifts.Remove(shift);
        //        }
        //    }

        //    // Add manager to new work shifts
        //    foreach (var shift in workShifts)
        //    {
        //        // Check if the shift is already in the manager's collection
        //        if (!manager.MangerWorkShifts.Any(ws => ws.WorkShiftId == shift.WorkShiftId))
        //        {
        //            // Add the shift to the manager's collection
        //            manager.MangerWorkShifts.Add(shift);

        //            // Add the manager to the shift's Managers collection
        //            if (shift.Managers == null)
        //            {
        //                shift.Managers = new List<User>();
        //            }

        //            if (!shift.Managers.Contains(manager))
        //            {
        //                shift.Managers.Add(manager);
        //            }
        //        }
        //    }

        //    manager.SetUpdateDate();
        //    await _unitOfWork.CommitAsync();
        //}
    }
}