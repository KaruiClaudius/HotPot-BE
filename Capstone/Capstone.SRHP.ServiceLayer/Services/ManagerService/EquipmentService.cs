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
        private const int CUSTOMER_ROLE_ID = 4; // Customer role ID
        private const int STAFF_ROLE_ID = 3;    // Staff role ID
        public EquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DamageDevice> LogEquipmentFailureAsync(DamageDevice damageDevice)
        {
            // Validate foreign keys before attempting to save
            if (damageDevice.HotPotInventoryId.HasValue)
            {
                var hotPotExists = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .AnyAsync(h => h.HotPotInventoryId == damageDevice.HotPotInventoryId.Value);

                if (!hotPotExists)
                {
                    throw new InvalidOperationException($"Hot Pot with ID {damageDevice.HotPotInventoryId.Value} does not exist.");
                }
            }

            if (damageDevice.UtensilId.HasValue)
            {
                var utensilExists = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .AnyAsync(u => u.UtensilId == damageDevice.UtensilId.Value);

                if (!utensilExists)
                {
                    throw new InvalidOperationException($"Utensil with ID {damageDevice.UtensilId.Value} does not exist.");
                }
            }

            // Ensure at least one equipment type is specified
            if (!damageDevice.HotPotInventoryId.HasValue && !damageDevice.UtensilId.HasValue)
            {
                throw new InvalidOperationException("Either HotPotInventoryId or UtensilId must be specified.");
            }

            // Set default values
            damageDevice.LoggedDate = DateTime.UtcNow;
            damageDevice.Status = MaintenanceStatus.Pending;


            _unitOfWork.Repository<DamageDevice>().Insert(damageDevice);
            await _unitOfWork.CommitAsync();

            return damageDevice;
        }

        public async Task<DamageDevice> UpdateResolutionTimelineAsync(int damageDeviceId, MaintenanceStatus status, DateTime estimatedResolutionTime, string message)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .FindAsync(c => c.DamageDeviceId == damageDeviceId);

            if (conditionLog == null)
                throw new KeyNotFoundException($"Condition log with ID {damageDeviceId} not found");

            conditionLog.Status = status;
            conditionLog.Description = message;
            conditionLog.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return conditionLog;
        }

        public async Task<DamageDevice> GetConditionLogByIdAsync(int damageDeviceId)
        {
            return await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.DamageDeviceId == damageDeviceId)
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

        public async Task<IEnumerable<int>> GetAffectedCustomerIdsAsync(int damageDeviceId)
        {
            var damageDevice = await GetConditionLogByIdAsync(damageDeviceId);
            if (damageDevice == null)
                return new List<int>();

            var affectedCustomerIds = new HashSet<int>();

            // Check for customers who have submitted replacement requests for this condition log
            if (damageDevice.ReplacementRequests != null && damageDevice.ReplacementRequests.Any())
            {
                foreach (var request in damageDevice.ReplacementRequests)
                {
                    if (request.CustomerId > 0)
                        affectedCustomerIds.Add(request.CustomerId);
                }
            }

            // Check for customers with active orders using the affected equipment
            if (damageDevice.HotPotInventoryId.HasValue)
            {
                // Get customers who have orders with this hot pot inventory in sell order details
                var hotPotSellCustomers = await _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable()
                    .Where(od => od.HotpotInventoryId == damageDevice.HotPotInventoryId)
                    .Include(od => od.RentOrder)
                        .ThenInclude(o => o.Order)
                        .ThenInclude(o => o.User)
                    .Where(od => od.RentOrder.Order.User.RoleId == CUSTOMER_ROLE_ID)
                    .Select(od => od.RentOrder.Order.UserId)
                    .Distinct()
                    .ToListAsync();

                foreach (var customerId in hotPotSellCustomers)
                {
                    affectedCustomerIds.Add(customerId);
                }

                // Get customers who have orders with this hot pot inventory in rent order details
                var hotPotRentCustomers = await _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable()
                    .Where(rd => rd.HotpotInventoryId == damageDevice.HotPotInventoryId)
                    .Include(rd => rd.RentOrder)
                        .ThenInclude(r=> r.Order)                     
                        .ThenInclude(o => o.User)
                    .Where(rd => rd.RentOrder.Order.User.RoleId == CUSTOMER_ROLE_ID)
                    .Select(rd => rd.RentOrder.Order.UserId)
                    .Distinct()
                    .ToListAsync();

                foreach (var customerId in hotPotRentCustomers)
                {
                    affectedCustomerIds.Add(customerId);
                }
            }

            if (damageDevice.UtensilId.HasValue)
            {
                // Get customers who have orders with this utensil in sell order details
                var utensilSellCustomers = await _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable()
                    .Where(od => od.UtensilId == damageDevice.UtensilId)
                    .Include(od => od.RentOrder)
                        .ThenInclude(od => od.Order)
                        .ThenInclude(o => o.User)
                    .Where(od => od.RentOrder.Order.User.RoleId == CUSTOMER_ROLE_ID)
                    .Select(od => od.RentOrder.Order.UserId)
                    .Distinct()
                    .ToListAsync();

                foreach (var customerId in utensilSellCustomers)
                {
                    affectedCustomerIds.Add(customerId);
                }

                // Get customers who have orders with this utensil in rent order details
                var utensilRentCustomers = await _unitOfWork.Repository<RentOrderDetail>()
                    .AsQueryable()
                    .Where(rd => rd.UtensilId == damageDevice.UtensilId)
                    .Include(rd => rd.RentOrder)
                        .ThenInclude(rd => rd.Order)
                        .ThenInclude(o => o.User)
                    .Where(rd => rd.RentOrder.Order.User.RoleId == CUSTOMER_ROLE_ID)
                    .Select(rd => rd.RentOrder.Order.UserId)
                    .Distinct()
                    .ToListAsync();

                foreach (var customerId in utensilRentCustomers)
                {
                    affectedCustomerIds.Add(customerId);
                }
            }

            return affectedCustomerIds;
        }

        public async Task<bool> AssignStaffToResolutionAsync(int conditionLogId, int staffId)
        {
            try
            {
                // First check if the staff exists (user with staff role)
                var staff = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                if (staff == null)
                    return false;

                // Then get the condition log with its replacement requests
                var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                    .AsQueryable()
                    .Where(c => c.DamageDeviceId == conditionLogId)
                    .Include(c => c.ReplacementRequests)
                    .FirstOrDefaultAsync();

                if (conditionLog == null)
                    return false;

                // Update the condition log status
                conditionLog.Status = MaintenanceStatus.InProgress;
                conditionLog.SetUpdateDate();

                // Create a replacement request if none exists to track the staff assignment
                if (conditionLog.ReplacementRequests == null || !conditionLog.ReplacementRequests.Any())
                {
                    var replacementRequest = new ReplacementRequest
                    {
                        RequestReason = $"Maintenance for condition log #{conditionLogId}",
                        Status = ReplacementRequestStatus.InProgress,
                        RequestDate = DateTime.UtcNow,
                        DamageDeviceId = conditionLogId,
                        AssignedStaffId = staffId,
                        EquipmentType = conditionLog.HotPotInventoryId.HasValue ?
                            EquipmentType.HotPot : EquipmentType.Utensil,
                        HotPotInventoryId = conditionLog.HotPotInventoryId,
                        UtensilId = conditionLog.UtensilId,
                        CreatedAt = DateTime.UtcNow
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
                        request.SetUpdateDate();
                    }
                }

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> MarkAsResolvedAsync(int conditionLogId, string resolutionNotes)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .FindAsync(c => c.DamageDeviceId == conditionLogId);

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
