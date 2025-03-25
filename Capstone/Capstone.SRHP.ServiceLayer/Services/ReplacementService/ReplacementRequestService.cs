using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ReplacementService
{
    public class ReplacementRequestService : IReplacementRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        private const int CUSTOMER_ROLE_ID = 4; // Customer role ID
        private const int STAFF_ROLE_ID = 3;    // Staff role ID

        public ReplacementRequestService(
            IUnitOfWork unitOfWork,
            INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        #region Manager Methods

        public async Task<IEnumerable<ReplacementRequest>> GetAllReplacementRequestsAsync()
        {
            return await _unitOfWork.Repository<ReplacementRequest>()
                .GetAll()
                .Include(r => r.Customer)
                .Include(r => r.AssignedStaff)
                .Include(r => r.ConditionLog)
                .Include(r => r.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(r => r.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ReplacementRequest>> GetReplacementRequestsByStatusAsync(ReplacementRequestStatus status)
        {
            return await _unitOfWork.Repository<ReplacementRequest>()
                .GetAll(r => r.Status == status)
                .Include(r => r.Customer)
                .Include(r => r.AssignedStaff)
                .Include(r => r.ConditionLog)
                .Include(r => r.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(r => r.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();
        }

        public async Task<ReplacementRequest> GetReplacementRequestByIdAsync(int requestId)
        {
            return await _unitOfWork.Repository<ReplacementRequest>()
                .AsQueryable()
                .Where(r => r.ReplacementRequestId == requestId)
                .Include(r => r.Customer)
                .Include(r => r.AssignedStaff)
                .Include(r => r.ConditionLog)
                .Include(r => r.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(r => r.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .FirstOrDefaultAsync();
        }

        public async Task<ReplacementRequest> ReviewReplacementRequestAsync(int requestId, bool isApproved, string reviewNotes)
        {
            var request = await _unitOfWork.Repository<ReplacementRequest>()
                .FindAsync(r => r.ReplacementRequestId == requestId);

            if (request == null)
                throw new NotFoundException($"Replacement request with ID {requestId} not found");

            if (request.Status != ReplacementRequestStatus.Pending)
                throw new ValidationException("Only pending requests can be reviewed");

            request.Status = isApproved ? ReplacementRequestStatus.Approved : ReplacementRequestStatus.Rejected;
            request.ReviewDate = DateTime.UtcNow;
            request.ReviewNotes = reviewNotes;
            request.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            // Load related entities for notification
            if (request.CustomerId > 0)
            {
                request.Customer = await _unitOfWork.Repository<User>()
                    .AsQueryable()
                    .Where(u => u.UserId == request.CustomerId && u.RoleId == CUSTOMER_ROLE_ID)
                    .FirstOrDefaultAsync();
            }

            if (request.HotPotInventoryId.HasValue)
            {
                request.HotPotInventory = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Where(h => h.HotPotInventoryId == request.HotPotInventoryId.Value)
                    .Include(h => h.Hotpot)
                    .FirstOrDefaultAsync();
            }

            if (request.UtensilId.HasValue)
            {
                request.Utensil = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .Where(u => u.UtensilId == request.UtensilId.Value)
                    .Include(u => u.UtensilType)
                    .FirstOrDefaultAsync();
            }

            // Notify customer about the review decision
            await _notificationService.NotifyCustomerAboutReplacementAsync(request);

            // Notify managers about the status change
            await _notificationService.NotifyReplacementStatusChangeAsync(request);

            return request;
        }

        public async Task<ReplacementRequest> AssignStaffToReplacementAsync(int requestId, int staffId)
        {
            var request = await _unitOfWork.Repository<ReplacementRequest>()
                .FindAsync(r => r.ReplacementRequestId == requestId);

            if (request == null)
                throw new NotFoundException($"Replacement request with ID {requestId} not found");

            if (request.Status != ReplacementRequestStatus.Approved)
                throw new ValidationException("Only approved requests can be assigned to staff");

            // Verify staff exists (user with staff role)
            var staff = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {staffId} not found");

            request.AssignedStaffId = staffId;
            request.Status = ReplacementRequestStatus.InProgress;
            request.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            // Load related entities for notification
            request.AssignedStaff = staff;

            if (request.CustomerId > 0)
            {
                request.Customer = await _unitOfWork.Repository<User>()
                    .AsQueryable()
                    .Where(u => u.UserId == request.CustomerId && u.RoleId == CUSTOMER_ROLE_ID)
                    .FirstOrDefaultAsync();
            }

            if (request.HotPotInventoryId.HasValue)
            {
                request.HotPotInventory = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Where(h => h.HotPotInventoryId == request.HotPotInventoryId.Value)
                    .Include(h => h.Hotpot)
                    .FirstOrDefaultAsync();
            }

            if (request.UtensilId.HasValue)
            {
                request.Utensil = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .Where(u => u.UtensilId == request.UtensilId.Value)
                    .Include(u => u.UtensilType)
                    .FirstOrDefaultAsync();
            }

            // Notify customer about the assignment
            await _notificationService.NotifyCustomerAboutReplacementAsync(request);

            // Notify managers about the status change
            await _notificationService.NotifyReplacementStatusChangeAsync(request);

            return request;
        }

        public async Task<ReplacementRequest> MarkReplacementAsCompletedAsync(int requestId, string completionNotes)
        {
            var request = await _unitOfWork.Repository<ReplacementRequest>()
                .FindAsync(r => r.ReplacementRequestId == requestId);

            if (request == null)
                throw new NotFoundException($"Replacement request with ID {requestId} not found");

            if (request.Status != ReplacementRequestStatus.InProgress)
                throw new ValidationException("Only in-progress requests can be marked as completed");

            request.Status = ReplacementRequestStatus.Completed;
            request.CompletionDate = DateTime.UtcNow;
            request.AdditionalNotes = (request.AdditionalNotes ?? "") + "\nCompletion Notes: " + completionNotes;
            request.SetUpdateDate();

            // Create a condition log entry for the replacement
            var conditionLog = new DamageDevice
            {
                Name = "Equipment Replacement",
                Description = $"Equipment replaced. Reason: {request.RequestReason}. Notes: {completionNotes}",
                Status = MaintenanceStatus.Completed,
                LoggedDate = DateTime.UtcNow
            };

            // Set the appropriate equipment ID based on the equipment type
            if (request.EquipmentType == EquipmentType.HotPot && request.HotPotInventoryId.HasValue)
            {
                conditionLog.HotPotInventoryId = request.HotPotInventoryId.Value;
            }
            else if (request.EquipmentType == EquipmentType.Utensil && request.UtensilId.HasValue)
            {
                conditionLog.UtensilId = request.UtensilId.Value;
            }

            _unitOfWork.Repository<DamageDevice>().Insert(conditionLog);
            await _unitOfWork.CommitAsync();

            // Update the request with the condition log ID
            request.DamageDeviceId = conditionLog.DamageDeviceId;
            await _unitOfWork.CommitAsync();

            // Load related entities for notification
            if (request.CustomerId > 0)
            {
                request.Customer = await _unitOfWork.Repository<User>()
                    .AsQueryable()
                    .Where(u => u.UserId == request.CustomerId && u.RoleId == CUSTOMER_ROLE_ID)
                    .FirstOrDefaultAsync();
            }

            if (request.AssignedStaffId.HasValue)
            {
                request.AssignedStaff = await _unitOfWork.Repository<User>()
                    .AsQueryable()
                    .Where(u => u.UserId == request.AssignedStaffId.Value && u.RoleId == STAFF_ROLE_ID)
                    .FirstOrDefaultAsync();
            }

            if (request.HotPotInventoryId.HasValue)
            {
                request.HotPotInventory = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Where(h => h.HotPotInventoryId == request.HotPotInventoryId.Value)
                    .Include(h => h.Hotpot)
                    .FirstOrDefaultAsync();
            }

            if (request.UtensilId.HasValue)
            {
                request.Utensil = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .Where(u => u.UtensilId == request.UtensilId.Value)
                    .Include(u => u.UtensilType)
                    .FirstOrDefaultAsync();
            }

            // Notify customer about completion
            await _notificationService.NotifyCustomerAboutReplacementAsync(request);

            // Notify managers about the status change
            await _notificationService.NotifyReplacementStatusChangeAsync(request);

            return request;
        }

        #endregion

        #region Staff Methods

        public async Task<IEnumerable<ReplacementRequest>> GetAssignedReplacementRequestsAsync(int staffId)
        {
            // Verify staff exists (user with staff role)
            var staff = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {staffId} not found");

            return await _unitOfWork.Repository<ReplacementRequest>()
                .GetAll(r => r.AssignedStaffId == staffId)
                .Include(r => r.Customer)
                .Include(r => r.ConditionLog)
                .Include(r => r.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(r => r.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();
        }

        public async Task<ReplacementRequest> UpdateReplacementStatusAsync(int requestId, ReplacementRequestStatus status, string notes)
        {
            var request = await _unitOfWork.Repository<ReplacementRequest>()
                .FindAsync(r => r.ReplacementRequestId == requestId);

            if (request == null)
                throw new NotFoundException($"Replacement request with ID {requestId} not found");

            // Validate status transitions
            if (status == ReplacementRequestStatus.Completed && request.Status != ReplacementRequestStatus.InProgress)
                throw new ValidationException("Only in-progress requests can be marked as completed");

            if (status == ReplacementRequestStatus.InProgress && request.Status != ReplacementRequestStatus.Approved)
                throw new ValidationException("Only approved requests can be marked as in-progress");

            request.Status = status;
            request.AdditionalNotes = (request.AdditionalNotes ?? "") + "\n" + notes;
            request.SetUpdateDate();

            if (status == ReplacementRequestStatus.Completed)
            {
                request.CompletionDate = DateTime.UtcNow;
            }

            await _unitOfWork.CommitAsync();

            return request;
        }

        #endregion

        #region Customer Methods

        public async Task<ReplacementRequest> CreateReplacementRequestAsync(ReplacementRequest request)
        {
            // Validate the request
            if (request.EquipmentType == EquipmentType.HotPot && !request.HotPotInventoryId.HasValue)
                throw new ValidationException("HotPot inventory ID is required for HotPot equipment type");

            if (request.EquipmentType == EquipmentType.Utensil && !request.UtensilId.HasValue)
                throw new ValidationException("Utensil ID is required for Utensil equipment type");

            // Verify customer exists (user with customer role)
            var customer = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == request.CustomerId && u.RoleId == CUSTOMER_ROLE_ID && !u.IsDelete);

            if (customer == null)
                throw new NotFoundException($"Customer with ID {request.CustomerId} not found");

            // Set default values
            request.Status = ReplacementRequestStatus.Pending;
            request.RequestDate = DateTime.UtcNow;
            request.CreatedAt = DateTime.UtcNow;

            _unitOfWork.Repository<ReplacementRequest>().Insert(request);
            await _unitOfWork.CommitAsync();

            // Load related entities for notification
            request.Customer = customer;

            if (request.HotPotInventoryId.HasValue)
            {
                request.HotPotInventory = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Where(h => h.HotPotInventoryId == request.HotPotInventoryId.Value)
                    .Include(h => h.Hotpot)
                    .FirstOrDefaultAsync();
            }

            if (request.UtensilId.HasValue)
            {
                request.Utensil = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .Where(u => u.UtensilId == request.UtensilId.Value)
                    .Include(u => u.UtensilType)
                    .FirstOrDefaultAsync();
            }

            // Notify managers about the new request
            await _notificationService.NotifyNewReplacementRequestAsync(request);

            return request;
        }

        public async Task<IEnumerable<ReplacementRequest>> GetCustomerReplacementRequestsAsync(int customerId)
        {
            // Verify customer exists (user with customer role)
            var customer = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == customerId && u.RoleId == CUSTOMER_ROLE_ID && !u.IsDelete);

            if (customer == null)
                throw new NotFoundException($"Customer with ID {customerId} not found");

            return await _unitOfWork.Repository<ReplacementRequest>()
                .GetAll(r => r.CustomerId == customerId)
                .Include(r => r.AssignedStaff)
                .Include(r => r.ConditionLog)
                .Include(r => r.HotPotInventory)
                    .ThenInclude(h => h != null ? h.Hotpot : null)
                .Include(r => r.Utensil)
                    .ThenInclude(u => u != null ? u.UtensilType : null)
                .OrderByDescending(r => r.RequestDate)
                .ToListAsync();
        }

        public async Task<ReplacementRequest> CancelReplacementRequestAsync(int requestId, int customerId)
        {
            // Verify customer exists (user with customer role)
            var customer = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == customerId && u.RoleId == CUSTOMER_ROLE_ID && !u.IsDelete);

            if (customer == null)
                throw new NotFoundException($"Customer with ID {customerId} not found");

            var request = await _unitOfWork.Repository<ReplacementRequest>()
                .FindAsync(r => r.ReplacementRequestId == requestId && r.CustomerId == customerId);

            if (request == null)
                throw new NotFoundException($"Replacement request with ID {requestId} not found for customer {customerId}");

            if (request.Status != ReplacementRequestStatus.Pending)
                throw new ValidationException("Only pending requests can be cancelled");

            request.Status = ReplacementRequestStatus.Cancelled;
            request.SetUpdateDate();
            request.AdditionalNotes = (request.AdditionalNotes ?? "") + "\nCancelled by customer.";

            await _unitOfWork.CommitAsync();

            return request;
        }
        #endregion

    }
}