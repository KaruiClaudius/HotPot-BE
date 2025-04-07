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

                // Map to DTOs and determine availability
                var staffDtos = new List<StaffAvailableDto>();
                foreach (var staff in staffUsers)
                {
                    // Check if staff is scheduled to work today
                    bool isAvailable = (staff.WorkDays.HasValue && (staff.WorkDays.Value & workDay) == workDay );

                    // Check if staff has too many active assignments
                    if (isAvailable)
                    {
                        var activeAssignments = await _unitOfWork.Repository<StaffPickupAssignment>()
                            .CountAsync(a => a.StaffId == staff.UserId && a.CompletedDate == null);

                        // Define a threshold for maximum assignments (e.g., 5)
                        isAvailable = activeAssignments < 5;
                    }

                    // Check if staff currently has an active order in progress
                    if (isAvailable)
                    {
                        var currentlyActiveOrder = await _unitOfWork.Repository<StaffPickupAssignment>()
                            .AnyAsync(a => a.StaffId == staff.UserId &&
                                          a.CompletedDate == null &&
                                          a.AssignedDate != null);

                        // Staff is not available if they're currently working on an order
                        isAvailable = !currentlyActiveOrder;
                    }

                    staffDtos.Add(new StaffAvailableDto
                    {
                        Id = staff.UserId,
                        Name = staff.Name,
                        Email = staff.Email ?? string.Empty,
                        Phone = staff.PhoneNumber ?? string.Empty,
                        IsAvailable = isAvailable
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
                    .ThenInclude(d => d.Utensil)
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

        public async Task<PagedResult<StaffPickupAssignmentDto>> GetAllCurrentAssignmentsAsync(int pageNumber = 1, int pageSize = 10)
        {
            // Get all current assignments (not completed)
            var query = _unitOfWork.Repository<StaffPickupAssignment>()
                .AsQueryable(a => a.CompletedDate == null && !a.IsDelete)
                .Include(a => a.Staff)
                .Include(a => a.RentOrder)
                    .ThenInclude(r => r.Order)
                        .ThenInclude(o => o.User)
                .Include(a => a.RentOrder.RentOrderDetails)
                    .ThenInclude(d => d.Utensil)
                .Include(a => a.RentOrder.RentOrderDetails)
                    .ThenInclude(d => d.HotpotInventory)
                        .ThenInclude(h => h != null ? h.Hotpot : null);

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply pagination
            var assignments = await query
                .OrderBy(a => a.AssignedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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

            return new PagedResult<StaffPickupAssignmentDto>
            {
                Items = assignmentDtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        private string GetEquipmentSummary(ICollection<RentOrderDetail> details)
        {
            if (details == null || !details.Any())
                return "No equipment";

            var equipmentCounts = new Dictionary<string, int>();

            foreach (var detail in details.Where(d => !d.IsDelete))
            {
                string name;
                if (detail.UtensilId.HasValue && detail.Utensil != null)
                {
                    name = detail.Utensil.Name;
                }
                else if (detail.HotpotInventoryId.HasValue && detail.HotpotInventory?.Hotpot != null)
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