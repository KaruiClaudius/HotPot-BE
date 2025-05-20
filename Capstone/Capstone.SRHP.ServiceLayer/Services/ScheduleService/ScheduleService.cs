using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int STAFF_ROLE_ID = 3; // Staff role ID
        private const int MANAGER_ROLE_ID = 2; // Manager role ID

        public ScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<WorkShift> GetWorkShiftByIdAsync(int shiftId)
        {
            return await _unitOfWork.Repository<WorkShift>()
                .AsQueryable(w => w.WorkShiftId == shiftId)
                .Include(w => w.Staff)
                .Include(w => w.Managers)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetAllWorkShiftsAsync()
        {
            return await _unitOfWork.Repository<WorkShift>().GetAll()
                .Include(w => w.Staff)
                .Include(w => w.Managers)
                .OrderBy(w => w.ShiftStartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetStaffWorkShiftsAsync(int staffId)
        {
            try
            {
                Console.WriteLine($"GetStaffWorkShiftsAsync: staffId = {staffId}");

                var staff = await _unitOfWork.Repository<User>()
                    .FindAsync(s => s.UserId == staffId && s.RoleId == STAFF_ROLE_ID);

                if (staff == null)
                {
                    Console.WriteLine($"Staff with ID {staffId} not found");
                    throw new KeyNotFoundException($"Staff with ID {staffId} not found");
                }

                Console.WriteLine($"Staff found: {staff.Name}");

                // Get all work shifts associated with this staff member
                var shifts = await _unitOfWork.Repository<WorkShift>().GetAll()
                    .Include(w => w.Staff)
                    .Where(w => w.Staff.Any(s => s.UserId == staffId))
                    .OrderBy(w => w.ShiftStartTime)
                    .ToListAsync();

                Console.WriteLine($"Shifts count: {shifts.Count}");
                foreach (var shift in shifts)
                {
                    Console.WriteLine($"Shift ID: {shift.WorkShiftId}, Name: {shift.ShiftName}");
                    Console.WriteLine($"Staff count in shift: {shift.Staff?.Count ?? 0}");
                }

                return shifts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetStaffWorkShiftsAsync: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<IEnumerable<WorkShift>> GetManagerWorkShiftsAsync(int managerId)
        {
            var manager = await _unitOfWork.Repository<User>()
                .FindAsync(m => m.UserId == managerId && m.RoleId == MANAGER_ROLE_ID);

            if (manager == null)
                throw new KeyNotFoundException($"Manager with ID {managerId} not found");

            // Get all work shifts associated with this manager
            return await _unitOfWork.Repository<WorkShift>().GetAll()
                .Include(w => w.Managers)
                .Where(w => w.Managers.Any(m => m.UserId == managerId))
                .OrderBy(w => w.ShiftStartTime)
                .ToListAsync();
        }

        public async Task<WorkShift> CreateWorkShiftAsync(WorkShift workShift)
        {
            workShift.CreatedAt = DateTime.UtcNow.AddHours(7);
            _unitOfWork.Repository<WorkShift>().Insert(workShift);
            await _unitOfWork.CommitAsync();
            return workShift;
        }

        public async Task<WorkShift> UpdateWorkShiftAsync(int shiftId, TimeSpan startTime, TimeSpan endTime, string shiftName)
        {
            var workShift = await _unitOfWork.Repository<WorkShift>()
                .FindAsync(w => w.WorkShiftId == shiftId);

            if (workShift == null)
                throw new KeyNotFoundException($"Work shift with ID {shiftId} not found");

            workShift.ShiftStartTime = startTime;
            workShift.ShiftEndTime = endTime;
            workShift.ShiftName = shiftName;
            workShift.UpdatedAt = DateTime.UtcNow.AddHours(7);

            await _unitOfWork.CommitAsync();
            return workShift;
        }

        public async Task<bool> DeleteWorkShiftAsync(int shiftId)
        {
            var workShift = await _unitOfWork.Repository<WorkShift>()
                .FindAsync(w => w.WorkShiftId == shiftId);

            if (workShift == null)
                return false;

            _unitOfWork.Repository<WorkShift>().Delete(workShift);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<User> AssignStaffWorkDaysAsync(int staffId, WorkDays workDays)
        {
            var staff = await _unitOfWork.Repository<User>()
                .FindAsync(s => s.UserId == staffId && s.RoleId == STAFF_ROLE_ID);

            if (staff == null)
                throw new KeyNotFoundException($"Staff with ID {staffId} not found");

            staff.WorkDays = workDays;
            staff.UpdatedAt = DateTime.UtcNow.AddHours(7);

            await _unitOfWork.CommitAsync();
            return staff;
        }
      

        public async Task<User> AssignManagerToWorkShiftsAsync(int managerId, WorkDays workDays, IEnumerable<int> workShiftIds)
        {
            var manager = await _unitOfWork.Repository<User>()
                .AsQueryable(m => m.UserId == managerId && m.RoleId == MANAGER_ROLE_ID)
                .Include(m => m.MangerWorkShifts)
                .FirstOrDefaultAsync();

            if (manager == null)
                throw new KeyNotFoundException($"Manager with ID {managerId} not found");

            // Clear existing work shifts
            manager.MangerWorkShifts.Clear();

            // Add new work shifts
            foreach (var shiftId in workShiftIds)
            {
                var workShift = await _unitOfWork.Repository<WorkShift>()
                    .AsQueryable(w => w.WorkShiftId == shiftId)
                    .Include(w => w.Managers)
                    .FirstOrDefaultAsync();

                if (workShift != null)
                {
                    manager.MangerWorkShifts.Add(workShift);
                    if (!workShift.Managers.Contains(manager))
                    {
                        workShift.Managers.Add(manager);
                    }
                }
            }

            manager.WorkDays = workDays;
            manager.UpdatedAt = DateTime.UtcNow.AddHours(7);
            await _unitOfWork.CommitAsync();
            return manager;
        }
    }
}