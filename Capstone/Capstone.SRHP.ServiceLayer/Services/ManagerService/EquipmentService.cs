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

        public async Task<DamageDevice> LogEquipmentFailureAsync(DamageDevice conditionLog)
        {
            // Validate foreign keys before attempting to save
            if (conditionLog.HotPotInventoryId.HasValue)
            {
                var hotPotExists = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .AnyAsync(h => h.HotPotInventoryId == conditionLog.HotPotInventoryId.Value);

                if (!hotPotExists)
                {
                    throw new InvalidOperationException($"Hot Pot with ID {conditionLog.HotPotInventoryId.Value} does not exist.");
                }
            }

            if (conditionLog.UtensilId.HasValue)
            {
                var utensilExists = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .AnyAsync(u => u.UtensilId == conditionLog.UtensilId.Value);

                if (!utensilExists)
                {
                    throw new InvalidOperationException($"Utensil with ID {conditionLog.UtensilId.Value} does not exist.");
                }
            }

            // Ensure at least one equipment type is specified
            if (!conditionLog.HotPotInventoryId.HasValue && !conditionLog.UtensilId.HasValue)
            {
                throw new InvalidOperationException("Either HotPotInventoryId or UtensilId must be specified.");
            }

            // Set default values
            conditionLog.LoggedDate = DateTime.UtcNow;
            conditionLog.Status = MaintenanceStatus.Pending;

            // If ScheduleType isn't set, default to Emergency for failures
            if (conditionLog.ScheduleType == 0)
            {
                conditionLog.ScheduleType = MaintenanceScheduleType.Emergency;
            }

            _unitOfWork.Repository<DamageDevice>().Insert(conditionLog);
            await _unitOfWork.CommitAsync();

            return conditionLog;
        }

        public async Task<DamageDevice> UpdateResolutionTimelineAsync(int conditionLogId, MaintenanceStatus status, DateTime estimatedResolutionTime, string message)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .FindAsync(c => c.ConditionLogId == conditionLogId);

            if (conditionLog == null)
                throw new KeyNotFoundException($"Condition log with ID {conditionLogId} not found");

            conditionLog.Status = status;
            conditionLog.Description = message;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return conditionLog;
        }

        public async Task<DamageDevice> GetConditionLogByIdAsync(int conditionLogId)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.ConditionLogId == conditionLogId)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DamageDevice>> GetActiveConditionLogsAsync()
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .GetAll(c => c.Status != MaintenanceStatus.Completed)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .OrderByDescending(c => c.LoggedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<DamageDevice>> GetConditionLogsByStatusAsync(MaintenanceStatus status)
        {
            return await _unitOfWork.Repository<DamageDevice>()
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

            var affectedCustomerIds = new HashSet<int>();

            // Check for customers who have submitted replacement requests for this condition log
            if (conditionLog.ReplacementRequests != null && conditionLog.ReplacementRequests.Any())
            {
                foreach (var request in conditionLog.ReplacementRequests)
                {
                    if (request.CustomerId > 0)
                        affectedCustomerIds.Add(request.CustomerId);
                }
            }

            // Check for customers with active orders using the affected equipment
            if (conditionLog.HotPotInventoryId.HasValue)
            {
                // Get customers who have orders with this hot pot inventory
                var hotPotCustomers = await _unitOfWork.Repository<OrderDetail>()
                    .AsQueryable(od => od.HotpotInventoryId == conditionLog.HotPotInventoryId)
                    .Include(od => od.Order)
                    .Select(od => od.Order.User.Customer.CustomerId)
                    .Distinct()
                    .ToListAsync();

                foreach (var customerId in hotPotCustomers)
                {
                    affectedCustomerIds.Add(customerId);
                }
            }

            if (conditionLog.UtensilId.HasValue)
            {
                // Get customers who have orders with this utensil
                var utensilCustomers = await _unitOfWork.Repository<OrderDetail>()
                    .AsQueryable(od => od.UtensilId == conditionLog.UtensilId)
                    .Include(od => od.Order)
                    .Select(od => od.Order.User.Customer.CustomerId)
                    .Distinct()
                    .ToListAsync();

                foreach (var customerId in utensilCustomers)
                {
                    affectedCustomerIds.Add(customerId);
                }
            }

            return affectedCustomerIds;
        }

        public async Task<bool> AssignStaffToResolutionAsync(int conditionLogId, int staffId)
        {
            // First check if the staff exists
            var staff = await _unitOfWork.Repository<Staff>()
                .FindAsync(s => s.StaffId == staffId);

            if (staff == null)
                return false;

            // Then get the condition log with its replacement requests
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.ConditionLogId == conditionLogId)
                .Include(c => c.ReplacementRequests)
                .FirstOrDefaultAsync();

            if (conditionLog == null)
                return false;

            // Update the condition log status
            conditionLog.Status = MaintenanceStatus.InProgress;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            // Create a replacement request if none exists to track the staff assignment
            if (conditionLog.ReplacementRequests == null || !conditionLog.ReplacementRequests.Any())
            {
                var replacementRequest = new ReplacementRequest
                {
                    RequestReason = $"Maintenance for condition log #{conditionLogId}",
                    Status = ReplacementRequestStatus.InProgress,
                    RequestDate = DateTime.UtcNow,
                    ConditionLogId = conditionLogId,
                    AssignedStaffId = staffId,
                    EquipmentType = conditionLog.HotPotInventoryId.HasValue ?
                        EquipmentType.HotPot : EquipmentType.Utensil,
                    HotPotInventoryId = conditionLog.HotPotInventoryId,
                    UtensilId = conditionLog.UtensilId
                };

                await _unitOfWork.Repository<ReplacementRequest>().InsertAsync(replacementRequest);
            }
            else
            {
                // Update existing replacement requests to assign the staff
                foreach (var request in conditionLog.ReplacementRequests)
                {
                    request.AssignedStaffId = staffId;
                    request.Status = ReplacementRequestStatus.InProgress;
                    request.ReviewDate = DateTime.UtcNow;
                    request.ReviewNotes = $"Assigned to staff #{staffId} for resolution";
                }
            }

            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> MarkAsResolvedAsync(int conditionLogId, string resolutionNotes)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
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
