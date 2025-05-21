using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffService> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IStaffAssignmentService _staffAssignmentService;

        private const int STAFF_ROLE_ID = 3; // Staff role ID
        private const int MANAGER_ROLE_ID = 2; // Manager role ID

        public StaffService(
         IUnitOfWork unitOfWork,
         ILogger<StaffService> logger,
         IStaffAssignmentService staffAssignmentService,
         ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _staffAssignmentService = staffAssignmentService;
            _currentUserService = currentUserService;
        }

        public async Task<User> GetStaffByIdAsync(int userId)
        {
            var staff = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .Include(u => u.StaffWorkShifts)
                .FirstOrDefaultAsync(u => u.UserId == userId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {userId} not found");

            return staff;
        }

        public async Task<IEnumerable<User>> GetAllStaffAsync()
        {
            return await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .Include(u => u.StaffWorkShifts)
                .Where(u => u.RoleId == STAFF_ROLE_ID && !u.IsDelete)
                .ToListAsync();
        }

        public async Task<List<StaffAvailableDto>> GetAvailableStaffForTaskAsync(StaffTaskType? taskType = null, int? orderId = null)
        {
            try
            {
                _logger.LogInformation("Getting available staff for task type: {TaskType}, orderId: {OrderId}", taskType, orderId);

                // Get current date
                var now = DateTime.Now;
                var today = now.DayOfWeek;
                var workDay = MapDayOfWeekToWorkDays(today);

                // Build query for staff users
                var staffQuery = _unitOfWork.Repository<User>()
                    .AsQueryable(u => u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                // Filter by staff type if task type is specified
                if (taskType.HasValue)
                {
                    if (taskType == StaffTaskType.Preparation)
                    {
                        // Only preparation staff can handle preparation tasks
                        staffQuery = staffQuery.Where(u => u.StaffType == StaffType.Preparation);
                    }
                    else if (taskType == StaffTaskType.Shipping)
                    {
                        // Both preparation and shipping staff can handle shipping tasks
                        staffQuery = staffQuery.Where(u => u.StaffType == StaffType.Preparation || u.StaffType == StaffType.Shipping);
                    }
                    else if (taskType == StaffTaskType.Pickup)
                    {
                        // Both preparation and shipping staff can handle pickup tasks
                        staffQuery = staffQuery.Where(u => u.StaffType == StaffType.Preparation || u.StaffType == StaffType.Shipping);
                    }
                }

                var staffUsers = await staffQuery.ToListAsync();

                // Get the specific order if orderId is provided
                Order specificOrder = null;
                if (orderId.HasValue)
                {
                    specificOrder = await _unitOfWork.Repository<Order>()
                        .AsQueryable()
                        .Include(o => o.ShippingOrder)
                        .FirstOrDefaultAsync(o => o.OrderId == orderId.Value && !o.IsDelete);

                    if (specificOrder == null)
                        throw new NotFoundException($"Order with ID {orderId.Value} not found");
                }

                // Get all active staff assignments (not completed)
                var activeAssignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.CompletedDate == null && !a.IsDelete)
                    .ToListAsync();

                // Group assignments by staff ID
                var assignmentsByStaff = activeAssignments
                    .GroupBy(a => a.StaffId)
                    .ToDictionary(
                        g => g.Key,
                        g => new
                        {
                            Assignments = g.ToList(),
                            Count = g.Count(),
                            OrderIds = g.Select(a => a.OrderId).Distinct().ToList(),
                            TaskTypes = g.Select(a => a.TaskType).Distinct().ToList()
                        }
                    );

                // Map to DTOs and determine availability
                var staffDtos = new List<StaffAvailableDto>();
                foreach (var staff in staffUsers)
                {
                    // Check if staff is scheduled to work today
                    bool isScheduledToday = (staff.WorkDays.HasValue && (staff.WorkDays.Value & workDay) == workDay);

                    // Get assignment info for this staff
                    assignmentsByStaff.TryGetValue(staff.UserId, out var assignmentInfo);
                    var staffAssignments = assignmentInfo?.Assignments ?? new List<StaffAssignment>();
                    int assignmentCount = assignmentInfo?.Count ?? 0;
                    var staffOrderIds = assignmentInfo?.OrderIds ?? new List<int>();
                    var staffTaskTypes = assignmentInfo?.TaskTypes ?? new List<StaffTaskType>();

                    // Default availability check - staff is available if:
                    // 1. They are scheduled to work today
                    // 2. They don't have too many active assignments (limit based on task type)
                    bool isAvailable = isScheduledToday &&
                                       IsStaffAvailableForMoreAssignments(staff.StaffType ?? StaffType.Preparation,
                                                                         staffTaskTypes,
                                                                         assignmentCount);

                    // Special handling for shipping task when the staff prepared the order
                    if (taskType == StaffTaskType.Shipping && specificOrder != null)
                    {
                        // Check if this staff has a preparation assignment for this order
                        bool preparedThisOrder = staffAssignments.Any(a =>
                            a.OrderId == specificOrder.OrderId && a.TaskType == StaffTaskType.Preparation);

                        // If this staff prepared the order and it's now Processed, they can ship it
                        // even if they have other active assignments
                        if (preparedThisOrder && specificOrder.Status == OrderStatus.Processed)
                        {
                            // Check if they're already assigned to other shipping tasks
                            bool alreadyShipping = staffAssignments.Any(a =>
                                a.TaskType == StaffTaskType.Shipping && a.OrderId != specificOrder.OrderId);

                            // They can ship this order if they're not already shipping something else
                            // and they are scheduled to work today
                            isAvailable = isScheduledToday && !alreadyShipping;
                        }
                    }

                    // Check if staff is eligible for the task type (if specified)
                    bool isEligible = true;
                    if (taskType.HasValue)
                    {
                        isEligible = IsStaffEligibleForTask(staff, taskType.Value);
                    }

                    // Check if staff is already assigned to this order for this task type
                    bool alreadyAssignedToTask = false;
                    if (orderId.HasValue && taskType.HasValue)
                    {
                        alreadyAssignedToTask = staffAssignments.Any(a =>
                            a.OrderId == orderId.Value && a.TaskType == taskType.Value);

                        // If already assigned, they're not available for this task
                        if (alreadyAssignedToTask)
                        {
                            isAvailable = false;
                        }
                    }

                    staffDtos.Add(new StaffAvailableDto
                    {
                        Id = staff.UserId,
                        Name = staff.Name,
                        Email = staff.Email ?? string.Empty,
                        Phone = staff.PhoneNumber ?? string.Empty,
                        StaffType = staff.StaffType ?? StaffType.Preparation,
                        IsAvailable = isAvailable,
                        IsEligible = isEligible,
                        AssignmentCount = assignmentCount,
                        WorkDays = staff.WorkDays,
                        // Check if this staff prepared the specific order
                        PreparedThisOrder = specificOrder != null &&
                            staffAssignments.Any(a => a.OrderId == specificOrder.OrderId && a.TaskType == StaffTaskType.Preparation),
                        ActiveOrderIds = staffOrderIds,
                        ScheduledForToday = isScheduledToday
                    });
                }

                return staffDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting available staff for task type {TaskType}", taskType);
                throw;
            }
        }

        public async Task<User> CreateStaffAsync(User staff)
        {
            staff.RoleId = STAFF_ROLE_ID;

            _unitOfWork.Repository<User>().Insert(staff);
            await _unitOfWork.CommitAsync();
            return staff;
        }

        public async Task UpdateStaffAsync(int userId, User staffUpdate)
        {
            var existingStaff = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && u.RoleId == STAFF_ROLE_ID);

            if (existingStaff == null)
                throw new NotFoundException($"Staff with ID {userId} not found");

            // Update properties as needed
            existingStaff.WorkDays = staffUpdate.WorkDays;
            existingStaff.Name = staffUpdate.Name;
            existingStaff.Email = staffUpdate.Email;
            existingStaff.PhoneNumber = staffUpdate.PhoneNumber;
            existingStaff.Address = staffUpdate.Address;
            existingStaff.Note = staffUpdate.Note;
            existingStaff.ImageURL = staffUpdate.ImageURL;
            existingStaff.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteStaffAsync(int userId)
        {
            var staff = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == userId && u.RoleId == STAFF_ROLE_ID);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {userId} not found");

            staff.SoftDelete();
            staff.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        // Pickup Service Methods

        public async Task<bool> AssignStaffToPickupAsync(int staffId, int rentOrderDetailId, int? vehicleId = null, string notes = null)
        {
            try
            {
                _logger.LogInformation("Assigning staff {StaffId} to pickup for rent order detail {RentOrderDetailId} with vehicle {VehicleId}",
                    staffId, rentOrderDetailId, vehicleId);

                // Verify the staff member exists
                var staff = await _unitOfWork.Repository<User>()
                        .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                if (staff == null)
                    throw new NotFoundException($"Staff with ID {staffId} not found");

                // Verify the rent order detail exists and get its OrderId
                var rentOrderDetail = await _unitOfWork.Repository<RentOrderDetail>()
                    .GetById(rentOrderDetailId);

                if (rentOrderDetail == null)
                    throw new NotFoundException($"Rent order detail with ID {rentOrderDetailId} not found");

                // Get the OrderId from the RentOrderDetail
                int orderId = rentOrderDetail.OrderId;

                // Verify the vehicle exists and is available if provided
                if (vehicleId.HasValue)
                {
                    var vehicle = await _unitOfWork.Repository<Vehicle>()
                        .FindAsync(v => v.VehicleId == vehicleId.Value && !v.IsDelete);

                    if (vehicle == null)
                        throw new NotFoundException($"Vehicle with ID {vehicleId.Value} not found");

                    if (vehicle.Status != VehicleStatus.Available)
                        throw new ValidationException($"Vehicle with ID {vehicleId.Value} is not available (current status: {vehicle.Status})");
                }

                // Get the current manager ID
                int managerId = await GetCurrentManagerIdAsync();

                // Use the unified staff assignment service
                await _staffAssignmentService.AssignStaffToTaskAsync(
                    orderId,
                    staffId,
                    managerId,
                    StaffTaskType.Pickup,
                    vehicleId);

                // If notes are provided, update the rent order with the notes
                if (!string.IsNullOrWhiteSpace(notes))
                {
                    var rentOrder = await _unitOfWork.Repository<RentOrder>()
                        .FindAsync(ro => ro.OrderId == orderId && !ro.IsDelete);

                    if (rentOrder != null)
                    {
                        rentOrder.RentalNotes = notes;
                        rentOrder.SetUpdateDate();
                        await _unitOfWork.CommitAsync();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning staff {StaffId} to pickup for rent order detail {RentOrderDetailId} with vehicle {VehicleId}",
                    staffId, rentOrderDetailId, vehicleId);
                throw;
            }
        }

        public async Task<List<StaffPickupAssignmentDto>> GetStaffAssignmentsAsync(int staffId)
        {
            try
            {
                _logger.LogInformation("Getting pickup assignments for staff {StaffId}", staffId);

                // Use the unified staff assignment service to get assignments
                var assignments = await _staffAssignmentService.GetStaffAssignmentsAsync(staffId, StaffTaskType.Pickup);

                // Map to the old DTO format for backward compatibility
                return assignments.Select(a => new StaffPickupAssignmentDto
                {
                    AssignmentId = a.AssignmentId,
                    OrderId = a.OrderId,
                    StaffId = a.StaffId,
                    StaffName = a.StaffName,
                    AssignedDate = a.AssignedDate,
                    CompletedDate = a.CompletedDate,
                    CustomerName = a.CustomerName,
                    CustomerAddress = a.CustomerAddress,
                    CustomerPhone = a.CustomerPhone,
                    OrderCode = a.OrderCode,
                    RentalStartDate = a.RentalDetails?.RentalStartDate,
                    ExpectedReturnDate = a.RentalDetails?.ExpectedReturnDate ?? DateTime.Now,
                    EquipmentSummary = a.RentalDetails?.EquipmentSummary ?? "No equipment details"
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting pickup assignments for staff {StaffId}", staffId);
                throw;
            }
        }

        public async Task<PagedResult<StaffPickupAssignmentDto>> GetStaffAssignmentsPaginatedAsync(
         int staffId, bool pendingOnly, int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation("Getting paginated pickup assignments for staff {StaffId}, pendingOnly {PendingOnly}",
                    staffId, pendingOnly);

                // Use the unified staff assignment service to get paginated assignments
                var pagedAssignments = await _staffAssignmentService.GetStaffAssignmentsPaginatedAsync(
                    staffId,
                    StaffTaskType.Pickup,
                    pendingOnly ? true : null, // Convert pendingOnly to activeOnly
                    pageNumber,
                    pageSize);

                // Map to the old DTO format for backward compatibility
                var mappedItems = pagedAssignments.Items.Select(a => new StaffPickupAssignmentDto
                {
                    AssignmentId = a.AssignmentId,
                    OrderId = a.OrderId,
                    StaffId = a.StaffId,
                    StaffName = a.StaffName,
                    AssignedDate = a.AssignedDate,
                    CompletedDate = a.CompletedDate,
                    CustomerName = a.CustomerName,
                    CustomerAddress = a.CustomerAddress,
                    CustomerPhone = a.CustomerPhone,
                    OrderCode = a.OrderCode,
                    RentalStartDate = a.RentalDetails?.RentalStartDate,
                    ExpectedReturnDate = a.RentalDetails?.ExpectedReturnDate ?? DateTime.Now,
                    EquipmentSummary = a.RentalDetails?.EquipmentSummary ?? "No equipment details"
                }).ToList();

                return new PagedResult<StaffPickupAssignmentDto>
                {
                    Items = mappedItems,
                    TotalCount = pagedAssignments.TotalCount,
                    PageNumber = pagedAssignments.PageNumber,
                    PageSize = pagedAssignments.PageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting paginated pickup assignments for staff {StaffId}", staffId);
                throw;
            }
        }

        public async Task<PagedResult<StaffPickupAssignmentDto>> GetAllCurrentAssignmentsAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Getting all current pickup assignments");

                // Use the unified staff assignment service to get all current assignments
                var pagedAssignments = await _staffAssignmentService.GetAllCurrentAssignmentsAsync(
                    StaffTaskType.Pickup,
                    pageNumber,
                    pageSize);

                // Map to the old DTO format for backward compatibility
                var mappedItems = pagedAssignments.Items.Select(a => new StaffPickupAssignmentDto
                {
                    AssignmentId = a.AssignmentId,
                    OrderId = a.OrderId,
                    StaffId = a.StaffId,
                    StaffName = a.StaffName,
                    AssignedDate = a.AssignedDate,
                    CompletedDate = a.CompletedDate,
                    CustomerName = a.CustomerName,
                    CustomerAddress = a.CustomerAddress,
                    CustomerPhone = a.CustomerPhone,
                    OrderCode = a.OrderCode,
                    RentalStartDate = a.RentalDetails?.RentalStartDate,
                    ExpectedReturnDate = a.RentalDetails?.ExpectedReturnDate ?? DateTime.Now,
                    EquipmentSummary = a.RentalDetails?.EquipmentSummary ?? "No equipment details",
                    // Map vehicle information
                    VehicleId = a.RentalDetails?.VehicleId,
                    VehicleName = a.RentalDetails?.VehicleName,
                    VehicleType = a.RentalDetails?.VehicleType
                }).ToList();

                return new PagedResult<StaffPickupAssignmentDto>
                {
                    Items = mappedItems,
                    TotalCount = pagedAssignments.TotalCount,
                    PageNumber = pagedAssignments.PageNumber,
                    PageSize = pagedAssignments.PageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all current pickup assignments");
                throw;
            }
        }

        // Helper method to check if a staff member is eligible for a specific task
        private bool IsStaffEligibleForTask(User staff, StaffTaskType taskType)
        {
            var staffType = staff.StaffType ?? StaffType.Preparation;

            return (taskType, staffType) switch
            {
                // Preparation staff can do all tasks
                (_, StaffType.Preparation) => true,

                // Shipping staff can only do shipping and pickup tasks
                (StaffTaskType.Shipping, StaffType.Shipping) => true,
                (StaffTaskType.Pickup, StaffType.Shipping) => true,

                // All other combinations are not eligible
                _ => false
            };
        }

        // Helper method to map DayOfWeek to WorkDays enum
        private WorkDays MapDayOfWeekToWorkDays(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Sunday => WorkDays.Sunday,
                DayOfWeek.Monday => WorkDays.Monday,
                DayOfWeek.Tuesday => WorkDays.Tuesday,
                DayOfWeek.Wednesday => WorkDays.Wednesday,
                DayOfWeek.Thursday => WorkDays.Thursday,
                DayOfWeek.Friday => WorkDays.Friday,
                DayOfWeek.Saturday => WorkDays.Saturday,
                _ => WorkDays.None
            };
        }
        private async Task<int> GetCurrentManagerIdAsync()
        {
            try
            {
                // Get the current user
                var currentUser = await _currentUserService.GetCurrentUserAsync();

                // Verify the user is a manager
                if (currentUser.RoleId != MANAGER_ROLE_ID)
                {
                    throw new UnauthorizedException("Current user is not authorized to make staff assignments");
                }

                return currentUser.UserId;
            }
            catch (UnauthorizedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting current manager ID");
                throw new UnauthorizedException("Failed to authenticate manager");
            }
        }
        private bool IsStaffAvailableForMoreAssignments(StaffType staffType, List<StaffTaskType> currentTaskTypes, int assignmentCount)
        {
            // Define limits for different staff types and task combinations
            const int MAX_PREPARATION_TASKS = 50;
            const int MAX_SHIPPING_TASKS = 50;
            const int MAX_PICKUP_TASKS = 50;
            const int MAX_TOTAL_TASKS = 100;

            // Check total assignment limit
            if (assignmentCount >= MAX_TOTAL_TASKS)
                return false;

            // Check task-specific limits
            int preparationCount = currentTaskTypes.Count(t => t == StaffTaskType.Preparation);
            int shippingCount = currentTaskTypes.Count(t => t == StaffTaskType.Shipping);
            int pickupCount = currentTaskTypes.Count(t => t == StaffTaskType.Pickup);

            // Apply limits based on staff type
            if (staffType == StaffType.Preparation)
            {
                // Preparation staff can do all tasks but with limits
                if (preparationCount >= MAX_PREPARATION_TASKS)
                    return false;

                if (shippingCount >= MAX_SHIPPING_TASKS)
                    return false;

                if (pickupCount >= MAX_PICKUP_TASKS)
                    return false;
            }
            else if (staffType == StaffType.Shipping)
            {
                // Shipping staff can only do shipping and pickup tasks
                if (shippingCount >= MAX_SHIPPING_TASKS)
                    return false;

                if (pickupCount >= MAX_PICKUP_TASKS)
                    return false;
            }

            return true;
        }
    }
}