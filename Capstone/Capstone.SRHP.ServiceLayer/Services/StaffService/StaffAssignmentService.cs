using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffAssignmentService : IStaffAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffAssignmentService> _logger;
        private const int STAFF_ROLE_ID = 3; // Staff role ID

        public StaffAssignmentService(
            IUnitOfWork unitOfWork,
            ILogger<StaffAssignmentService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<StaffAssignmentResponse> AssignStaffToTaskAsync(
             int orderId,
             int staffId,
             int managerId,
             StaffTaskType taskType,
             int? vehicleId = null)
        {
            try
            {
                _logger.LogInformation("Assigning staff {StaffId} to order {OrderId} for task type {TaskType}",
                    staffId, orderId, taskType);

                // Get the order
                var order = await _unitOfWork.Repository<Order>()
                    .GetAll(o => o.OrderId == orderId && !o.IsDelete)
                    .FirstOrDefaultAsync();

                if (order == null)
                {
                    throw new NotFoundException($"Order with ID {orderId} not found.");
                }

                // Get the staff member
                var staff = await _unitOfWork.Repository<User>()
                    .GetAll(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete)
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync();

                if (staff == null)
                {
                    throw new NotFoundException($"Staff with ID {staffId} not found or is not a staff member.");
                }

                // Get the manager
                var manager = await _unitOfWork.Repository<User>()
                    .GetAll(u => u.UserId == managerId)
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Role.Name == "Manager");

                if (manager == null)
                {
                    throw new NotFoundException($"Manager with ID {managerId} not found or is not a manager.");
                }

                // Check staff eligibility based on task type
                if (taskType == StaffTaskType.Preparation && staff.StaffType != StaffType.Preparation)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not authorized for order preparation. Only preparation staff can prepare orders.");
                }
                else if (taskType == StaffTaskType.Shipping &&
                         staff.StaffType != StaffType.Preparation &&
                         staff.StaffType != StaffType.Shipping)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not authorized for shipping. Staff type: {staff.StaffType}");
                }

                // Check staff availability on current day
                var today = DateTime.Now.DayOfWeek;
                var currentDay = MapDayOfWeekToWorkDays(today);

                // Check if staff is available on the current day
                if ((staff.WorkDays & currentDay) == 0)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not available on {today}. Staff works on: {staff.WorkDays}");
                }

                // Check for existing active assignment
                var existingAssignment = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(sa => sa.OrderId == orderId && sa.StaffId == staffId &&
                                 sa.TaskType == taskType && sa.CompletedDate == null)
                    .FirstOrDefaultAsync();

                if (existingAssignment != null)
                {
                    throw new BusinessException($"Staff {staffId} is already actively assigned to task {taskType} for order {orderId}.");
                }

                // Create the new assignment
                var newAssignment = new StaffAssignment
                {
                    OrderId = orderId,
                    StaffId = staffId,
                    ManagerId = managerId,
                    TaskType = taskType,
                    AssignedDate = DateTime.UtcNow.AddHours(7),
                };

                await _unitOfWork.Repository<StaffAssignment>().InsertAsync(newAssignment);

                // Handle task-specific logic
                StaffAssignmentResponse response = new StaffAssignmentResponse
                {
                    OrderId = order.OrderId,
                    OrderCode = order.OrderCode,
                    StaffId = staffId,
                    StaffName = staff.Name,
                    AssignedAt = DateTime.UtcNow.AddHours(7),
                    TaskType = taskType,
                    AssignmentId = newAssignment.StaffAssignmentId
                };

                if (taskType == StaffTaskType.Preparation)
                {
                    // Update order with preparation staff
                    order.PreparationStaffId = staffId;
                    order.Status = OrderStatus.Processing;
                    order.SetUpdateDate();

                    response.Status = order.Status;
                }
                else if (taskType == StaffTaskType.Shipping)
                {
                    // Validate order status for shipping
                    if (order.Status != OrderStatus.Processed)
                    {
                        throw new ValidationException($"Order with ID {orderId} is not ready for shipping. Current status: {order.Status}");
                    }

                    // Handle shipping assignment
                    ShippingOrder shippingOrder;

                    // Check if shipping order already exists
                    var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                        .FindAsync(so => so.OrderId == orderId && !so.IsDelete);

                    if (existingShippingOrder != null)
                    {
                        _logger.LogInformation("Updating existing shipping order {ShippingOrderId} for order {OrderId}",
                            existingShippingOrder.ShippingOrderId, orderId);

                        // Update existing shipping order
                        existingShippingOrder.StaffId = staffId;

                        if (vehicleId.HasValue)
                        {
                            // Validate vehicle if provided
                            var vehicle = await _unitOfWork.Repository<Vehicle>()
                                .FindAsync(v => v.VehicleId == vehicleId.Value && !v.IsDelete);

                            if (vehicle == null)
                                throw new NotFoundException($"Vehicle with ID {vehicleId.Value} not found");

                            if (vehicle.Status != VehicleStatus.Available)
                                throw new ValidationException($"Vehicle with ID {vehicleId.Value} is not available (current status: {vehicle.Status})");

                            existingShippingOrder.VehicleId = vehicleId;

                            // Update vehicle status
                            vehicle.Status = VehicleStatus.InUse;
                            vehicle.SetUpdateDate();

                            // Add vehicle details to response
                            response.VehicleId = vehicle.VehicleId;
                            response.VehicleName = vehicle.Name;
                            response.VehicleType = vehicle.Type;
                        }

                        existingShippingOrder.SetUpdateDate();
                        shippingOrder = existingShippingOrder;
                    }
                    else
                    {
                        _logger.LogInformation("Creating new shipping order for order {OrderId}", orderId);

                        // Estimate order size
                        var orderSize = await EstimateOrderSizeAsync(order.OrderCode);

                        // Create new shipping order
                        shippingOrder = new ShippingOrder
                        {
                            OrderId = order.OrderId,
                            StaffId = staffId,
                            VehicleId = vehicleId,
                            OrderSize = orderSize,
                            IsDelivered = false,
                            CreatedAt = DateTime.UtcNow.AddHours(7)
                        };

                        if (vehicleId.HasValue)
                        {
                            // Validate vehicle if provided
                            var vehicle = await _unitOfWork.Repository<Vehicle>()
                                .FindAsync(v => v.VehicleId == vehicleId.Value && !v.IsDelete);

                            if (vehicle == null)
                                throw new NotFoundException($"Vehicle with ID {vehicleId.Value} not found");

                            if (vehicle.Status != VehicleStatus.Available)
                                throw new ValidationException($"Vehicle with ID {vehicleId.Value} is not available (current status: {vehicle.Status})");

                            // Update vehicle status
                            vehicle.Status = VehicleStatus.InUse;
                            vehicle.SetUpdateDate();

                            // Add vehicle details to response
                            response.VehicleId = vehicle.VehicleId;
                            response.VehicleName = vehicle.Name;
                            response.VehicleType = vehicle.Type;
                        }

                        _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);

                        response.OrderSize = orderSize;
                    }

                    // Add shipping details to response
                    response.Status = order.Status;
                    response.ShippingOrderId = shippingOrder.ShippingOrderId;
                    response.IsDelivered = shippingOrder.IsDelivered;
                }
                else if (taskType == StaffTaskType.Pickup)
                {
                    // Handle pickup assignment
                    // Check if this is a rent order
                    var rentOrder = await _unitOfWork.Repository<RentOrder>()
                        .FindAsync(ro => ro.OrderId == orderId && !ro.IsDelete);

                    if (rentOrder == null)
                    {
                        throw new ValidationException($"Order with ID {orderId} is not a rental order and cannot be assigned for pickup.");
                    }

                    // Add rental details to response
                    response.RentalStartDate = rentOrder.RentalStartDate;
                    response.ExpectedReturnDate = rentOrder.ExpectedReturnDate;
                }

                // Save all changes
                await _unitOfWork.CommitAsync();

                _logger.LogInformation($"Staff {staffId} assigned to task {taskType} for order {orderId} by manager {managerId}.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning staff {StaffId} to order {OrderId} for task type {TaskType}",
                    staffId, orderId, taskType);
                throw;
            }
        }

        public async Task<bool> CompleteAssignmentAsync(int assignmentId)
        {
            try
            {
                _logger.LogInformation("Completing assignment {AssignmentId}", assignmentId);

                var assignment = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(sa => sa.StaffAssignmentId == assignmentId && !sa.IsDelete)
                    .Include(sa => sa.Order)
                    .FirstOrDefaultAsync();

                if (assignment == null)
                {
                    throw new NotFoundException($"Assignment with ID {assignmentId} not found.");
                }

                if (assignment.CompletedDate.HasValue)
                {
                    throw new BusinessException($"Assignment with ID {assignmentId} is already completed.");
                }

                // Mark the assignment as completed
                assignment.CompletedDate = DateTime.UtcNow.AddHours(7);
                assignment.SetUpdateDate();

                // Handle task-specific completion logic
                if (assignment.TaskType == StaffTaskType.Preparation)
                {
                    // Update order status to Processed when preparation is complete
                    assignment.Order.Status = OrderStatus.Processed;
                    assignment.Order.SetUpdateDate();
                }
                else if (assignment.TaskType == StaffTaskType.Shipping)
                {
                    // Update shipping order and order status
                    var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                        .FindAsync(so => so.OrderId == assignment.OrderId && !so.IsDelete);

                    if (shippingOrder != null)
                    {
                        shippingOrder.IsDelivered = true;
                        shippingOrder.SetUpdateDate();

                        // Update vehicle status if applicable
                        if (shippingOrder.VehicleId.HasValue)
                        {
                            var vehicle = await _unitOfWork.Repository<Vehicle>()
                                .FindAsync(v => v.VehicleId == shippingOrder.VehicleId.Value);

                            if (vehicle != null)
                            {
                                vehicle.Status = VehicleStatus.Available;
                                vehicle.SetUpdateDate();
                            }
                        }
                    }

                    // Update order status
                    assignment.Order.Status = OrderStatus.Delivered;
                    assignment.Order.SetUpdateDate();
                }
                else if (assignment.TaskType == StaffTaskType.Pickup)
                {
                    // Handle pickup completion logic
                    // You might want to update the rental status or create a return record
                    var rentOrder = await _unitOfWork.Repository<RentOrder>()
                        .FindAsync(ro => ro.OrderId == assignment.OrderId);

                    if (rentOrder != null)
                    {
                        rentOrder.ActualReturnDate = DateTime.UtcNow.AddHours(7);
                        rentOrder.SetUpdateDate();
                    }
                    assignment.Order.Status = OrderStatus.Completed;
                    assignment.Order.SetUpdateDate();
                }

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing assignment {AssignmentId}", assignmentId);
                throw;
            }
        }

        public async Task<List<StaffAssignmentDto>> GetStaffAssignmentsAsync(int staffId, StaffTaskType? taskType = null)
        {
            try
            {
                _logger.LogInformation("Getting assignments for staff {StaffId}, task type {TaskType}", staffId, taskType);

                // Verify the staff member exists
                var staff = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                if (staff == null)
                    throw new NotFoundException($"Staff with ID {staffId} not found");

                // Build query for assignments
                var query = _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.StaffId == staffId && !a.IsDelete);

                // Filter by task type if specified
                if (taskType.HasValue)
                {
                    query = query.Where(a => a.TaskType == taskType.Value);
                }

                // Include related entities
                var assignments = await query
                    .Include(a => a.Staff)
                    .Include(a => a.Manager)
                    .Include(a => a.Order)
                        .ThenInclude(o => o.User)
                    .Include(a => a.Order.RentOrder)
                        .ThenInclude(r => r != null ? r.RentOrderDetails : null)
                            .ThenInclude(d => d != null ? d.HotpotInventory : null)
                                .ThenInclude(h => h != null ? h.Hotpot : null)
                    .Include(a => a.Order.ShippingOrder)
                        .ThenInclude(so => so != null ? so.Vehicle : null)
                    .OrderByDescending(a => a.AssignedDate)
                    .ToListAsync();

                // Map to DTOs
                var assignmentDtos = new List<StaffAssignmentDto>();

                foreach (var assignment in assignments)
                {
                    var dto = new StaffAssignmentDto
                    {
                        AssignmentId = assignment.StaffAssignmentId,
                        OrderId = assignment.OrderId,
                        StaffId = assignment.StaffId,
                        StaffName = assignment.Staff?.Name,
                        ManagerId = assignment.ManagerId,
                        ManagerName = assignment.Manager?.Name,
                        TaskType = assignment.TaskType,
                        AssignedDate = assignment.AssignedDate,
                        CompletedDate = assignment.CompletedDate,
                        IsActive = assignment.IsActive,
                        OrderCode = assignment.Order?.OrderCode,
                        OrderStatus = assignment.Order?.Status ?? OrderStatus.Pending,
                        CustomerName = assignment.Order?.User?.Name,
                        CustomerAddress = assignment.Order?.User?.Address,
                        CustomerPhone = assignment.Order?.User?.PhoneNumber
                    };

                    // Add task-specific details
                    if (assignment.TaskType == StaffTaskType.Shipping && assignment.Order?.ShippingOrder != null)
                    {
                        dto.ShippingDetails = new ShippingDetailsDto
                        {
                            ShippingOrderId = assignment.Order.ShippingOrder.ShippingOrderId,
                            IsDelivered = assignment.Order.ShippingOrder.IsDelivered,
                            VehicleId = assignment.Order.ShippingOrder.VehicleId,
                            VehicleName = assignment.Order.ShippingOrder.Vehicle?.Name,
                            VehicleType = assignment.Order.ShippingOrder.Vehicle?.Type,
                            OrderSize = assignment.Order.ShippingOrder.OrderSize
                        };
                    }
                    else if (assignment.TaskType == StaffTaskType.Pickup && assignment.Order?.RentOrder != null)
                    {
                        dto.RentalDetails = new RentalDetailsDto
                        {
                            RentalStartDate = assignment.Order.RentOrder.RentalStartDate,
                            ExpectedReturnDate = assignment.Order.RentOrder.ExpectedReturnDate,
                            EquipmentSummary = GetEquipmentSummary(assignment.Order.RentOrder.RentOrderDetails)
                        };
                    }

                    assignmentDtos.Add(dto);
                }

                return assignmentDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting assignments for staff {StaffId}", staffId);
                throw;
            }
        }

        public async Task<PagedResult<StaffAssignmentDto>> GetStaffAssignmentsPaginatedAsync(
            int staffId,
            StaffTaskType? taskType = null,
            bool? activeOnly = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Getting paginated assignments for staff {StaffId}, task type {TaskType}, activeOnly {ActiveOnly}, page {Page}, size {Size}",
                    staffId, taskType, activeOnly, pageNumber, pageSize);

                // Verify the staff member exists
                var staff = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                if (staff == null)
                    throw new NotFoundException($"Staff with ID {staffId} not found");

                // Build query for assignments
                var query = _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.StaffId == staffId && !a.IsDelete);

                // Filter by task type if specified
                if (taskType.HasValue)
                {
                    query = query.Where(a => a.TaskType == taskType.Value);
                }

                // Filter by active status if specified
                if (activeOnly.HasValue)
                {
                    if (activeOnly.Value)
                    {
                        query = query.Where(a => a.CompletedDate == null);
                    }
                    else
                    {
                        query = query.Where(a => a.CompletedDate != null);
                    }
                }

                // Get total count before pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var pagedAssignments = await query
                    .Include(a => a.Staff)
                    .Include(a => a.Manager)
                    .Include(a => a.Order)
                        .ThenInclude(o => o.User)
                    .OrderByDescending(a => a.AssignedDate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs
                var assignmentDtos = new List<StaffAssignmentDto>();

                foreach (var assignment in pagedAssignments)
                {
                    var dto = new StaffAssignmentDto
                    {
                        AssignmentId = assignment.StaffAssignmentId,
                        OrderId = assignment.OrderId,
                        StaffId = assignment.StaffId,
                        StaffName = assignment.Staff?.Name,
                        ManagerId = assignment.ManagerId,
                        ManagerName = assignment.Manager?.Name,
                        TaskType = assignment.TaskType,
                        AssignedDate = assignment.AssignedDate,
                        CompletedDate = assignment.CompletedDate,
                        IsActive = assignment.IsActive,
                        OrderCode = assignment.Order?.OrderCode,
                        OrderStatus = assignment.Order?.Status ?? OrderStatus.Pending,
                        CustomerName = assignment.Order?.User?.Name,
                        CustomerAddress = assignment.Order?.User?.Address,
                        CustomerPhone = assignment.Order?.User?.PhoneNumber
                    };

                    // Load task-specific details separately to avoid excessive includes
                    if (assignment.TaskType == StaffTaskType.Shipping)
                    {
                        var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                            .GetAll(so => so.OrderId == assignment.OrderId && !so.IsDelete)
                            .Include(so => so.Vehicle)
                            .FirstOrDefaultAsync();

                        if (shippingOrder != null)
                        {
                            dto.ShippingDetails = new ShippingDetailsDto
                            {
                                ShippingOrderId = shippingOrder.ShippingOrderId,
                                IsDelivered = shippingOrder.IsDelivered,
                                VehicleId = shippingOrder.VehicleId,
                                VehicleName = shippingOrder.Vehicle?.Name,
                                VehicleType = shippingOrder.Vehicle?.Type,
                                OrderSize = shippingOrder.OrderSize
                            };
                        }
                    }
                    else if (assignment.TaskType == StaffTaskType.Pickup)
                    {
                        var rentOrder = await _unitOfWork.Repository<RentOrder>()
                            .GetAll(ro => ro.OrderId == assignment.OrderId && !ro.IsDelete)
                            .Include(ro => ro.RentOrderDetails)
                                .ThenInclude(d => d.HotpotInventory)
                                    .ThenInclude(h => h.Hotpot)
                            .FirstOrDefaultAsync();

                        if (rentOrder != null)
                        {
                            dto.RentalDetails = new RentalDetailsDto
                            {
                                RentalStartDate = rentOrder.RentalStartDate,
                                ExpectedReturnDate = rentOrder.ExpectedReturnDate,
                                EquipmentSummary = GetEquipmentSummary(rentOrder.RentOrderDetails)
                            };
                        }
                    }

                    assignmentDtos.Add(dto);
                }

                return new PagedResult<StaffAssignmentDto>
                {
                    Items = assignmentDtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting paginated assignments for staff {StaffId}", staffId);
                throw;
            }
        }

        public async Task<PagedResult<StaffAssignmentDto>> GetAllCurrentAssignmentsAsync(
           StaffTaskType? taskType = null,
           int pageNumber = 1,
           int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Getting all current assignments, task type {TaskType}, page {Page}, size {Size}",
                    taskType, pageNumber, pageSize);

                // Build query for active assignments
                var query = _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.CompletedDate == null && !a.IsDelete);

                // Filter by task type if specified
                if (taskType.HasValue)
                {
                    query = query.Where(a => a.TaskType == taskType.Value);
                }

                // Get total count before pagination
                var totalCount = await query.CountAsync();

                // Apply pagination
                var pagedAssignments = await query
                    .Include(a => a.Staff)
                    .Include(a => a.Manager)
                    .Include(a => a.Order)
                        .ThenInclude(o => o.User)
                    .OrderBy(a => a.AssignedDate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Map to DTOs
                var assignmentDtos = new List<StaffAssignmentDto>();

                foreach (var assignment in pagedAssignments)
                {
                    var dto = new StaffAssignmentDto
                    {
                        AssignmentId = assignment.StaffAssignmentId,
                        OrderId = assignment.OrderId,
                        StaffId = assignment.StaffId,
                        StaffName = assignment.Staff?.Name,
                        ManagerId = assignment.ManagerId,
                        ManagerName = assignment.Manager?.Name,
                        TaskType = assignment.TaskType,
                        AssignedDate = assignment.AssignedDate,
                        CompletedDate = assignment.CompletedDate,
                        IsActive = assignment.IsActive,
                        OrderCode = assignment.Order?.OrderCode,
                        OrderStatus = assignment.Order?.Status ?? OrderStatus.Pending,
                        CustomerName = assignment.Order?.User?.Name,
                        CustomerAddress = assignment.Order?.User?.Address,
                        CustomerPhone = assignment.Order?.User?.PhoneNumber
                    };

                    // Load task-specific details separately to avoid excessive includes
                    if (assignment.TaskType == StaffTaskType.Shipping)
                    {
                        var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                            .GetAll(so => so.OrderId == assignment.OrderId && !so.IsDelete)
                            .Include(so => so.Vehicle)
                            .FirstOrDefaultAsync();

                        if (shippingOrder != null)
                        {
                            dto.ShippingDetails = new ShippingDetailsDto
                            {
                                ShippingOrderId = shippingOrder.ShippingOrderId,
                                IsDelivered = shippingOrder.IsDelivered,
                                VehicleId = shippingOrder.VehicleId,
                                VehicleName = shippingOrder.Vehicle?.Name,
                                VehicleType = shippingOrder.Vehicle?.Type,
                                OrderSize = shippingOrder.OrderSize
                            };
                        }
                    }
                    else if (assignment.TaskType == StaffTaskType.Pickup)
                    {
                        var rentOrder = await _unitOfWork.Repository<RentOrder>()
                            .GetAll(ro => ro.OrderId == assignment.OrderId && !ro.IsDelete)
                            .Include(ro => ro.RentOrderDetails)
                                .ThenInclude(d => d.HotpotInventory)
                                    .ThenInclude(h => h.Hotpot)
                            .FirstOrDefaultAsync();

                        if (rentOrder != null)
                        {
                            dto.RentalDetails = new RentalDetailsDto
                            {
                                RentalStartDate = rentOrder.RentalStartDate,
                                ExpectedReturnDate = rentOrder.ExpectedReturnDate,
                                EquipmentSummary = GetEquipmentSummary(rentOrder.RentOrderDetails)
                            };
                        }
                    }

                    assignmentDtos.Add(dto);
                }

                return new PagedResult<StaffAssignmentDto>
                {
                    Items = assignmentDtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all current assignments");
                throw;
            }
        }

        public async Task<PagedResult<StaffAssignmentHistoryDto>> GetStaffAssignmentHistoryAsync(
     StaffAssignmentHistoryFilterRequest filter, int managerId)
        {
            try
            {
                _logger.LogInformation($"Getting staff assignment history for manager ID: {managerId}");

                // Start with all staff assignments that aren't deleted and belong to this manager
                var query = _unitOfWork.Repository<StaffAssignment>()
                    .AsQueryable()
                    .Where(sa => !sa.IsDelete && sa.ManagerId == managerId);

                // Apply filters
                if (filter.StartDate.HasValue)
                {
                    query = query.Where(sa => sa.AssignedDate >= filter.StartDate.Value);
                }

                if (filter.EndDate.HasValue)
                {
                    // Add one day to include the end date fully
                    var endDatePlusOne = filter.EndDate.Value.AddDays(1);
                    query = query.Where(sa => sa.AssignedDate < endDatePlusOne);
                }

                if (filter.TaskType.HasValue)
                {
                    query = query.Where(sa => sa.TaskType == filter.TaskType.Value);
                }

                if (filter.IsActive.HasValue)
                {
                    query = query.Where(sa => sa.CompletedDate == null == filter.IsActive.Value);
                }

                if (filter.StaffId.HasValue)
                {
                    query = query.Where(sa => sa.StaffId == filter.StaffId.Value);
                }

                if (!string.IsNullOrWhiteSpace(filter.StaffName))
                {
                    query = query.Where(sa => sa.Staff.Name.Contains(filter.StaffName));
                }

                // Add filter for OrderCode
                if (!string.IsNullOrWhiteSpace(filter.OrderCode))
                {
                    query = query.Where(sa => sa.Order.OrderCode.Contains(filter.OrderCode));
                }

                // Include related data
                query = query
                    .Include(sa => sa.Staff)
                    .Include(sa => sa.Order)
                        .ThenInclude(o => o.User)
                    .OrderByDescending(sa => sa.AssignedDate);

                // Get all matching assignments
                var allAssignments = await query.ToListAsync();

                // Group assignments by OrderId and TaskType for preparation tasks
                var groupedAssignments = new List<StaffAssignment>();
                var processedOrderTaskTypes = new HashSet<string>(); // Track processed order-tasktype combinations

                foreach (var assignment in allAssignments)
                {
                    // Create a unique key for each order-tasktype combination
                    string key = $"{assignment.OrderId}-{assignment.TaskType}";

                    // For preparation tasks, we want to group them
                    if (assignment.TaskType == StaffTaskType.Preparation)
                    {
                        // If this is the first time we're seeing this order-tasktype combination
                        if (!processedOrderTaskTypes.Contains(key))
                        {
                            // Add it to our processed set
                            processedOrderTaskTypes.Add(key);
                            // Add the assignment to our result list
                            groupedAssignments.Add(assignment);
                        }
                        // Otherwise, we've already included this order-tasktype, so skip
                    }
                    else
                    {
                        // For non-preparation tasks, include all assignments
                        groupedAssignments.Add(assignment);
                    }
                }

                // Apply pagination after grouping
                var totalCount = groupedAssignments.Count;
                var pageNumber = filter.PageNumber ?? 1;
                var pageSize = filter.PageSize ?? 10;

                var pagedAssignments = groupedAssignments
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // Map to DTOs with additional staff information
                var assignmentDtos = new List<StaffAssignmentHistoryDto>();

                foreach (var assignment in pagedAssignments)
                {
                    var dto = MapToStaffAssignmentHistoryDto(assignment);

                    // If this is a preparation task, find all other staff assigned to this order
                    if (assignment.TaskType == StaffTaskType.Preparation)
                    {
                        // Find all other preparation assignments for this order
                        var additionalStaff = allAssignments
                            .Where(a => a.OrderId == assignment.OrderId &&
                                   a.TaskType == StaffTaskType.Preparation &&
                                   a.StaffAssignmentId != assignment.StaffAssignmentId)
                            .Select(a => new StaffInfo
                            {
                                StaffId = a.StaffId,
                                StaffName = a.Staff?.Name,
                                AssignedDate = a.AssignedDate,
                                CompletedDate = a.CompletedDate
                            })
                            .ToList();

                        dto.AdditionalPreparationStaff = additionalStaff;
                    }

                    assignmentDtos.Add(dto);
                }

                return new PagedResult<StaffAssignmentHistoryDto>
                {
                    Items = assignmentDtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving staff assignment history");
                throw;
            }
        }

        private StaffAssignmentHistoryDto MapToStaffAssignmentHistoryDto(StaffAssignment assignment)
        {
            return new StaffAssignmentHistoryDto
            {
                StaffAssignmentId = assignment.StaffAssignmentId,
                StaffId = assignment.StaffId,
                StaffName = assignment.Staff?.Name,
                OrderId = assignment.OrderId,
                OrderCode = assignment.Order?.OrderCode,
                CustomerName = assignment.Order?.User?.Name,
                TaskType = assignment.TaskType,
                TaskTypeName = assignment.TaskType.ToString(),
                AssignedDate = assignment.AssignedDate,
                CompletedDate = assignment.CompletedDate,
                IsActive = assignment.IsActive,
                OrderStatus = assignment.Order?.Status ?? OrderStatus.Pending,
                OrderStatusName = (assignment.Order?.Status ?? OrderStatus.Pending).ToString(),
                AdditionalPreparationStaff = new List<StaffInfo>() // Will be populated in the main method
            };
        }


        private async Task<OrderSize> EstimateOrderSizeAsync(string orderCode)
        {
            try
            {
                _logger.LogInformation("Estimating size for order {OrderId}", orderCode);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderCode == orderCode && !o.IsDelete)
                    .Include(o => o.SellOrder.SellOrderDetails)
                    .Include(o => o.RentOrder.RentOrderDetails)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderCode} not found");

                // Define business rules for order size estimation
                bool isLarge = false;

                // Rule 1: If order has more than 2 rental items, it's considered large
                if (order.HasRentItems &&
                    order.RentOrder?.RentOrderDetails?.Any() == true &&
                    order.RentOrder.RentOrderDetails.Count() > 2)
                {
                    isLarge = true;
                }

                // Rule 2: If order has at least 10 total sell items AND at least 2 combo items, it's considered large
                const int LARGE_ORDER_ITEM_THRESHOLD = 10;

                if (order.HasSellItems &&
                    order.SellOrder?.SellOrderDetails != null)
                {
                    // Check if total quantity is at least 10
                    int totalQuantity = order.SellOrder.SellOrderDetails.Sum(d => d.Quantity);

                    // Check if there are at least 2 combo items
                    int comboItemCount = order.SellOrder.SellOrderDetails
                        .Where(d => d.ComboId.HasValue)
                        .Sum(d => d.Quantity);

                    if (totalQuantity >= LARGE_ORDER_ITEM_THRESHOLD && comboItemCount >= 2)
                    {
                        isLarge = true;
                    }
                }

                return isLarge ? OrderSize.Large : OrderSize.Small;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error estimating size for order {OrderId}", orderCode);
                throw;
            }
        }

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

        private string GetEquipmentSummary(ICollection<RentOrderDetail> details)
        {
            if (details == null || !details.Any())
            {
                return "No equipment";
            }

            var equipmentCounts = new Dictionary<string, int>();

            foreach (var detail in details.Where(d => !d.IsDelete))
            {
                string name;
                if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null)
                {
                    name = detail.HotpotInventory.Hotpot.Name;
                }
                else
                {
                    continue;
                }

                if (equipmentCounts.ContainsKey(name))
                {
                    equipmentCounts[name] += detail.Quantity;
                }
                else
                {
                    equipmentCounts[name] = detail.Quantity;
                }
            }

            // Create a summary string
            var summary = string.Join(", ", equipmentCounts.Select(kv => $"{kv.Value}x {kv.Key}"));
            return string.IsNullOrEmpty(summary) ? "No equipment" : summary;
        }

    }
}