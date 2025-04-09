using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEquipmentReturnService _equipmentReturnService;
        private const int STAFF_ROLE_ID = 3; // Staff role ID

        public StaffService(
         IUnitOfWork unitOfWork,
         IEquipmentReturnService equipmentReturnService)
        {
            _unitOfWork = unitOfWork;
            _equipmentReturnService = equipmentReturnService;
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

        public async Task<List<StaffAvailableDto>> GetAvailableStaffAsync()
        {
            try
            {
                // Get current day of week
                var today = DateTime.Now.DayOfWeek;
                var workDay = MapDayOfWeekToWorkDays(today);

                // Get all users with staff role who are not deleted
                var staffUsers = await _unitOfWork.Repository<User>()
                    .AsQueryable(u => u.RoleId == STAFF_ROLE_ID && !u.IsDelete)
                    .Include(u => u.StaffWorkShifts)
                    .ToListAsync();

                // Get all active assignments in a single query
                var allActiveAssignments = await _unitOfWork.Repository<StaffPickupAssignment>()
                    .AsQueryable(a => a.CompletedDate == null)
                    .Select(a => new { a.StaffId, a.AssignedDate })
                    .ToListAsync();

                // Group assignments by staff ID
                var assignmentsByStaff = allActiveAssignments
                    .GroupBy(a => a.StaffId)
                    .ToDictionary(
                        g => g.Key,
                        g => new {
                            Count = g.Count(),
                            HasActiveOrder = g.Any(a => a.AssignedDate != null)
                        }
                    );

                // Map to DTOs and determine availability
                var staffDtos = new List<StaffAvailableDto>();
                foreach (var staff in staffUsers)
                {
                    // Check if staff is scheduled to work today
                    bool isAvailable = (staff.WorkDays.HasValue && (staff.WorkDays.Value & workDay) == workDay);

                    // Get assignment info for this staff
                    assignmentsByStaff.TryGetValue(staff.UserId, out var assignmentInfo);
                    int activeAssignments = assignmentInfo?.Count ?? 0;
                    bool hasActiveOrder = assignmentInfo?.HasActiveOrder ?? false;

                    // Define a threshold for maximum assignments (e.g., 5)
                    isAvailable = isAvailable && (activeAssignments < 5);

                    // Staff is not available if they're currently working on an order
                    isAvailable = isAvailable && !hasActiveOrder;

                    staffDtos.Add(new StaffAvailableDto
                    {
                        Id = staff.UserId,
                        Name = staff.Name,
                        Email = staff.Email ?? string.Empty,
                        Phone = staff.PhoneNumber ?? string.Empty,
                        IsAvailable = isAvailable,
                        AssignmentCount = activeAssignments
                    });
                }

                return staffDtos;
            }
            catch (Exception ex)
            {
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
     

        public async Task<bool> AssignStaffToPickupAsync(int staffId, int rentOrderDetailId, string notes = null)
        {
            // Get the execution strategy
            var strategy = _unitOfWork.CreateExecutionStrategy();

            // Execute everything in a retryable unit
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // Verify the staff member exists
                var staff = await _unitOfWork.Repository<User>()
                        .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                if (staff == null)
                    throw new NotFoundException($"Staff with ID {staffId} not found");

                // Verify the rent order detail exists
                var rentOrderDetail = await _unitOfWork.Repository<RentOrderDetail>()
                    .GetById(rentOrderDetailId);

                if (rentOrderDetail == null)
                    throw new NotFoundException($"Rent order detail with ID {rentOrderDetailId} not found");

                // Check if this rental is already assigned
                var existingAssignment = await _unitOfWork.Repository<StaffPickupAssignment>()
                    .FindAsync(a => a.OrderId == rentOrderDetailId && a.CompletedDate == null);

                if (existingAssignment != null)
                {
                    // Update existing assignment
                    existingAssignment.StaffId = staffId;
                    existingAssignment.Notes = notes;
                    existingAssignment.AssignedDate = DateTime.UtcNow;
                    existingAssignment.SetUpdateDate();

                    await _unitOfWork.Repository<StaffPickupAssignment>().UpdateDetached(existingAssignment);
                }
                else
                {
                    // Create new assignment
                    var assignment = new StaffPickupAssignment
                    {
                        OrderId = rentOrderDetailId,
                        StaffId = staffId,
                        AssignedDate = DateTime.UtcNow,
                        Notes = notes
                    };

                    _unitOfWork.Repository<StaffPickupAssignment>().Insert(assignment);
                }

                await _unitOfWork.CommitAsync();
                return true;
            });
        }

        public async Task<List<StaffPickupAssignmentDto>> GetStaffAssignmentsAsync(int staffId)
        {
            // Verify the staff member exists
            var staff = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {staffId} not found");

            // Get all assignments for this staff member
            var assignments = await _unitOfWork.Repository<StaffPickupAssignment>()
                .AsQueryable(a => a.StaffId == staffId && !a.IsDelete)
                .Include(a => a.Staff)
                .Include(a => a.RentOrder)
                    .ThenInclude(r => r.Order)
                        .ThenInclude(o => o.User)
                .Include(a => a.RentOrder.RentOrderDetails)
                    .ThenInclude(d => d.HotpotInventory)
                        .ThenInclude(h => h != null ? h.Hotpot : null)
                .ToListAsync();

            // Map to DTOs
            var assignmentDtos = assignments.Select(a => new StaffPickupAssignmentDto
            {
                AssignmentId = a.AssignmentId,
                OrderId = a.OrderId,
                StaffId = a.StaffId,
                StaffName = a.Staff?.Name,
                AssignedDate = a.AssignedDate,
                CompletedDate = a.CompletedDate,
                Notes = a.Notes,
                CustomerName = a.RentOrder?.Order?.User?.Name,
                CustomerAddress = a.RentOrder?.Order?.User?.Address,
                CustomerPhone = a.RentOrder?.Order?.User?.PhoneNumber,
                OrderCode = a.RentOrder?.Order?.OrderCode,
                RentalStartDate = a.RentOrder?.RentalStartDate,
                ExpectedReturnDate = a.RentOrder?.ExpectedReturnDate ?? DateTime.Now,
                // Get equipment summary from all details
                EquipmentSummary = GetEquipmentSummary(a.RentOrder?.RentOrderDetails)
            }).ToList();

            return assignmentDtos;
        }

        public async Task<PagedResult<StaffPickupAssignmentDto>> GetStaffAssignmentsPaginatedAsync(int staffId, bool pendingOnly, int pageNumber, int pageSize)
        {
            // Verify the staff member exists
            var staff = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {staffId} not found");

            // Get all assignments for this staff member
            var query = _unitOfWork.Repository<StaffPickupAssignment>()
                .AsQueryable(a => a.StaffId == staffId && !a.IsDelete);

            if (pendingOnly)
            {
                query = query.Where(a => a.CompletedDate == null);
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Get basic assignments first (without includes)
            var basicAssignments = await query
                .OrderBy(a => a.AssignedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map to DTOs
            var assignmentDtos = new List<StaffPickupAssignmentDto>();

            foreach (var a in basicAssignments)
            {
                // Create basic DTO
                var dto = new StaffPickupAssignmentDto
                {
                    AssignmentId = a.AssignmentId,
                    OrderId = a.OrderId,
                    StaffId = a.StaffId,
                    AssignedDate = a.AssignedDate,
                    CompletedDate = a.CompletedDate,
                    Notes = a.Notes,
                    EquipmentSummary = "Order details not available"
                };

                // Try to load staff
                var staffMember = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == a.StaffId && !u.IsDelete);

                if (staffMember != null)
                {
                    dto.StaffName = staffMember.Name;
                }

                // Try to load rent order and related entities
                var rentOrder = await _unitOfWork.Repository<RentOrder>()
                    .FindAsync(r => r.OrderId == a.OrderId && !r.IsDelete);

                if (rentOrder != null)
                {
                    dto.RentalStartDate = rentOrder.RentalStartDate;
                    dto.ExpectedReturnDate = rentOrder.ExpectedReturnDate;

                    // Try to load order
                    var order = await _unitOfWork.Repository<Order>()
                        .FindAsync(o => o.OrderId == rentOrder.OrderId && !o.IsDelete);

                    if (order != null)
                    {
                        dto.OrderCode = order.OrderCode;

                        // Try to load user
                        var user = await _unitOfWork.Repository<User>()
                            .FindAsync(u => u.UserId == order.UserId && !u.IsDelete);

                        if (user != null)
                        {
                            dto.CustomerName = user.Name;
                            dto.CustomerAddress = user.Address;
                            dto.CustomerPhone = user.PhoneNumber;
                        }
                    }

                    // Try to load rent order details using AsQueryable
                    var detailsQuery = _unitOfWork.Repository<RentOrderDetail>()
                        .AsQueryable(d => d.OrderId == rentOrder.OrderId && !d.IsDelete);

                    var details = await detailsQuery.ToListAsync();

                    if (details != null && details.Any())
                    {
                        // Load hotpot inventory and hotpot for each detail
                        foreach (var detail in details)
                        {
                            if (detail.HotpotInventoryId.HasValue)
                            {
                                var inventory = await _unitOfWork.Repository<HotPotInventory>()
                                    .FindAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId && !h.IsDelete);

                                if (inventory != null)
                                {
                                    detail.HotpotInventory = inventory;

                                    var hotpot = await _unitOfWork.Repository<Hotpot>()
                                        .FindAsync(h => h.HotpotId == inventory.HotpotId && !h.IsDelete);

                                    if (hotpot != null)
                                    {
                                        inventory.Hotpot = hotpot;
                                    }
                                }
                            }
                        }

                        dto.EquipmentSummary = GetEquipmentSummary(details);
                    }
                }

                assignmentDtos.Add(dto);
            }

            return new PagedResult<StaffPickupAssignmentDto>
            {
                Items = assignmentDtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<StaffPickupAssignmentDto>> GetAllCurrentAssignmentsAsync(int pageNumber = 1, int pageSize = 10)
        {
            // Log input parameters
            Console.WriteLine($"Requested page: {pageNumber}, page size: {pageSize}");

            // Get all current assignments (not completed)
            var query = _unitOfWork.Repository<StaffPickupAssignment>()
                .AsQueryable(a => a.CompletedDate == null && !a.IsDelete);

            // Check basic count before includes
            var basicCount = await query.CountAsync();
            Console.WriteLine($"Basic count before includes: {basicCount}");

            // Add includes
            query = query.Include(a => a.Staff)
                .Include(a => a.RentOrder)
                    .ThenInclude(r => r.Order)
                        .ThenInclude(o => o.User)
                .Include(a => a.RentOrder.RentOrderDetails)
                    .ThenInclude(d => d.HotpotInventory)
                        .ThenInclude(h => h != null ? h.Hotpot : null);

            // Get total count after includes
            var totalCount = await query.CountAsync();
            Console.WriteLine($"Total count after includes: {totalCount}");

            // Check if pagination parameters are valid
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            Console.WriteLine($"Total pages: {totalPages}, requested page: {pageNumber}");

            if (pageNumber > totalPages && totalCount > 0)
            {
                Console.WriteLine("Warning: Requested page exceeds available pages");
                // Option 1: Return empty result with correct metadata
                // Option 2: Reset to page 1 (implemented below)
                pageNumber = 1;
            }

            // Apply pagination with detailed logging
            Console.WriteLine($"Applying pagination: Skip {(pageNumber - 1) * pageSize}, Take {pageSize}");
            var assignments = await query
                .OrderBy(a => a.AssignedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            Console.WriteLine($"Retrieved {assignments.Count} assignments after pagination");

            // Map to DTOs with null checks
            var assignmentDtos = assignments.Select(a => new StaffPickupAssignmentDto
            {
                AssignmentId = a.AssignmentId,
                OrderId = a.OrderId,
                StaffId = a.StaffId,
                StaffName = a.Staff?.Name,
                AssignedDate = a.AssignedDate,
                CompletedDate = a.CompletedDate,
                Notes = a.Notes,
                CustomerName = a.RentOrder?.Order?.User?.Name,
                CustomerAddress = a.RentOrder?.Order?.User?.Address,
                CustomerPhone = a.RentOrder?.Order?.User?.PhoneNumber,
                OrderCode = a.RentOrder?.Order?.OrderCode,
                RentalStartDate = a.RentOrder?.RentalStartDate,
                ExpectedReturnDate = a.RentOrder?.ExpectedReturnDate ?? DateTime.Now,
                EquipmentSummary = GetEquipmentSummary(a.RentOrder?.RentOrderDetails)
            }).ToList();

            Console.WriteLine($"Mapped {assignmentDtos.Count} DTOs");

            return new PagedResult<StaffPickupAssignmentDto>
            {
                Items = assignmentDtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
                // TotalPages is calculated automatically
            };
        }

        private string GetEquipmentSummary(ICollection<RentOrderDetail> details)
        {
            Console.WriteLine("GetEquipmentSummary called");

            if (details == null)
            {
                Console.WriteLine("  Details collection is NULL");
                return "No equipment";
            }

            if (!details.Any())
            {
                Console.WriteLine("  Details collection is empty");
                return "No equipment";
            }

            Console.WriteLine($"  Processing {details.Count} details");
            var equipmentCounts = new Dictionary<string, int>();
            var skippedDetails = 0;

            foreach (var detail in details.Where(d => !d.IsDelete))
            {
                Console.WriteLine($"  Detail {detail.RentOrderDetailId}: HotpotInventoryId={detail.HotpotInventoryId}");

                string name;
                if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null)
                {
                    name = detail.HotpotInventory.Hotpot.Name;
                    Console.WriteLine($"    Found hotpot name: {name}");
                }
                else
                {
                    if (!detail.HotpotInventoryId.HasValue)
                        Console.WriteLine("    Skipped: HotpotInventoryId is null");
                    else if (detail.HotpotInventory == null)
                        Console.WriteLine("    Skipped: HotpotInventory is null");
                    else if (detail.HotpotInventory.Hotpot == null)
                        Console.WriteLine("    Skipped: Hotpot is null");

                    skippedDetails++;
                    continue;
                }

                if (equipmentCounts.ContainsKey(name))
                {
                    equipmentCounts[name] += detail.Quantity;
                    Console.WriteLine($"    Updated count for {name}: {equipmentCounts[name]}");
                }
                else
                {
                    equipmentCounts[name] = detail.Quantity;
                    Console.WriteLine($"    Added new entry for {name}: {detail.Quantity}");
                }
            }

            // Create a summary string
            var summary = string.Join(", ", equipmentCounts.Select(kv => $"{kv.Value}x {kv.Key}"));

            if (skippedDetails > 0)
            {
                Console.WriteLine($"  WARNING: Skipped {skippedDetails} details due to missing data");
            }

            Console.WriteLine($"  Final summary: {(string.IsNullOrEmpty(summary) ? "No equipment" : summary)}");
            return string.IsNullOrEmpty(summary) ? "No equipment" : summary;
        }

        private WorkDays MapDayOfWeekToWorkDays(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => WorkDays.Monday,
                DayOfWeek.Tuesday => WorkDays.Tuesday,
                DayOfWeek.Wednesday => WorkDays.Wednesday,
                DayOfWeek.Thursday => WorkDays.Thursday,
                DayOfWeek.Friday => WorkDays.Friday,
                DayOfWeek.Saturday => WorkDays.Saturday,
                DayOfWeek.Sunday => WorkDays.Sunday,
                _ => WorkDays.Monday // Default case
            };
        }
    }
}