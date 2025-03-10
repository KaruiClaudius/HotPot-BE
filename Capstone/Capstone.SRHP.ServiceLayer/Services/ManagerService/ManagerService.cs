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

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Manager> GetManagerByIdAsync(int managerId)
        {
            var manager = await _unitOfWork.Repository<Manager>()
                .Include(m => m.User)
                .Include(m => m.WorkShifts)
                .FirstOrDefaultAsync(m => m.ManagerId == managerId && !m.IsDelete);

            if (manager == null)
                throw new NotFoundException($"Manager with ID {managerId} not found");

            return manager;
        }

        public async Task<Manager> GetManagerByUserIdAsync(int userId)
        {
            var manager = await _unitOfWork.Repository<Manager>()
                .Include(m => m.User)
                .Include(m => m.WorkShifts)
                .FirstOrDefaultAsync(m => m.UserID == userId && !m.IsDelete);

            if (manager == null)
                throw new NotFoundException($"Manager with User ID {userId} not found");

            return manager;
        }

        public async Task<IEnumerable<Manager>> GetAllManagersAsync()
        {
            return await _unitOfWork.Repository<Manager>()
                .Include(m => m.User)
                .Include(m => m.WorkShifts)
                .Where(m => !m.IsDelete)
                .ToListAsync();
        }

        public async Task<Manager> CreateManagerAsync(Manager manager)
        {
            _unitOfWork.Repository<Manager>().Insert(manager);
            await _unitOfWork.CommitAsync();
            return manager;
        }

        public async Task UpdateManagerAsync(int managerId, Manager manager)
        {
            var existingManager = await _unitOfWork.Repository<Manager>()
                .FindAsync(m => m.ManagerId == managerId);

            if (existingManager == null)
                throw new NotFoundException($"Manager with ID {managerId} not found");

            // Update properties as needed
            existingManager.WorkDays = manager.WorkDays;
            existingManager.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteManagerAsync(int managerId)
        {
            var manager = await _unitOfWork.Repository<Manager>()
                .FindAsync(m => m.ManagerId == managerId);

            if (manager == null)
                throw new NotFoundException($"Manager with ID {managerId} not found");

            manager.SoftDelete();
            manager.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }
    }
}
