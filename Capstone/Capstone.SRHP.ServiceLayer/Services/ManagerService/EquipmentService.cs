using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
   public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ConditionLog> LogEquipmentFailureAsync(ConditionLog conditionLog)
        {
            conditionLog.LoggedDate = DateTime.UtcNow;
            conditionLog.Status = MaintenanceStatus.Pending;

            _unitOfWork.Repository<ConditionLog>().Insert(conditionLog);
            await _unitOfWork.CommitAsync();

            return conditionLog;
        }

        public async Task<ConditionLog> UpdateResolutionTimelineAsync(int conditionLogId, MaintenanceStatus status, DateTime estimatedResolutionTime, string message)
        {
            var conditionLog = await _unitOfWork.Repository<ConditionLog>()
                .FindAsync(c => c.ConditionLogId == conditionLogId);

            if (conditionLog == null)
                throw new KeyNotFoundException($"Condition log with ID {conditionLogId} not found");

            conditionLog.Status = status;
            conditionLog.Description = message;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return conditionLog;
        }

        public async Task<ConditionLog> GetConditionLogByIdAsync(int conditionLogId)
        {
            return await _unitOfWork.Repository<ConditionLog>()
                .AsQueryable(c => c.ConditionLogId == conditionLogId)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ConditionLog>> GetActiveConditionLogsAsync()
        {
            return await _unitOfWork.Repository<ConditionLog>()
                .GetAll(c => c.Status != MaintenanceStatus.Completed)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .OrderByDescending(c => c.LoggedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ConditionLog>> GetConditionLogsByStatusAsync(MaintenanceStatus status)
        {
            return await _unitOfWork.Repository<ConditionLog>()
                .GetAll(c => c.Status == status)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .OrderByDescending(c => c.LoggedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<int>> GetAffectedCustomerIdsAsync(int conditionLogId)
        {
            var conditionLog = await GetConditionLogByIdAsync(conditionLogId);
            if (conditionLog == null)
                return new List<int>();

            // This is a simplified example. In a real application, you would determine
            // which customers are affected by the equipment failure based on your business logic.
            // For example, customers who have active orders using the affected equipment.

            // For demonstration purposes, we'll return an empty list
            return new List<int>();
        }

        public async Task<bool> AssignStaffToResolutionAsync(int conditionLogId, int staffId)
        {
            var conditionLog = await _unitOfWork.Repository<ConditionLog>()
                .FindAsync(c => c.ConditionLogId == conditionLogId);

            if (conditionLog == null)
                return false;

            // In a real application, you would have a relationship between ConditionLog and Staff
            // For this example, we'll just update the status
            conditionLog.Status = MaintenanceStatus.InProgress;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> MarkAsResolvedAsync(int conditionLogId, string resolutionNotes)
        {
            var conditionLog = await _unitOfWork.Repository<ConditionLog>()
                .FindAsync(c => c.ConditionLogId == conditionLogId);

            if (conditionLog == null)
                return false;

            conditionLog.Status = MaintenanceStatus.Completed;
            conditionLog.Description = resolutionNotes;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
