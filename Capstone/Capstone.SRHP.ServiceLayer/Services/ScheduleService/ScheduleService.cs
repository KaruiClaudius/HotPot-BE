using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .AsQueryable(w => w.Id == shiftId)
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
            var staff = await _unitOfWork.Repository<User>()
                .FindAsync(s => s.UserId == staffId && s.RoleId == STAFF_ROLE_ID);

            if (staff == null)
                throw new KeyNotFoundException($"Staff with ID {staffId} not found");

            return await _unitOfWork.Repository<WorkShift>().GetAll()
                .Where(w => (w.DaysOfWeek & staff.WorkDays) != 0)
                .Include(w => w.Managers)
                .OrderBy(w => w.ShiftStartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetManagerWorkShiftsAsync(int managerId)
        {
            var manager = await _unitOfWork.Repository<User>()
                .FindAsync(m => m.UserId == managerId && m.RoleId == MANAGER_ROLE_ID);

            if (manager == null)
                throw new KeyNotFoundException($"Manager with ID {managerId} not found");

            return await _unitOfWork.Repository<WorkShift>().GetAll()
                .Where(w => (w.DaysOfWeek & manager.WorkDays) != 0)
                .Include(w => w.Staff)
                .OrderBy(w => w.ShiftStartTime)
                .ToListAsync();
        }

        public async Task<WorkShift> CreateWorkShiftAsync(WorkShift workShift)
        {
            workShift.CreatedAt = DateTime.UtcNow;
            _unitOfWork.Repository<WorkShift>().Insert(workShift);
            await _unitOfWork.CommitAsync();
            return workShift;
        }

        public async Task<WorkShift> UpdateWorkShiftAsync(int shiftId, TimeSpan shiftStartTime, WorkDays daysOfWeek, AttendanceStatus? status)
        {
            var workShift = await _unitOfWork.Repository<WorkShift>()
                .FindAsync(w => w.Id == shiftId);

            if (workShift == null)
                throw new KeyNotFoundException($"Work shift with ID {shiftId} not found");

            workShift.ShiftStartTime = shiftStartTime;
            workShift.DaysOfWeek = daysOfWeek;
            workShift.Status = status;
            workShift.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
            return workShift;
        }

        public async Task<bool> DeleteWorkShiftAsync(int shiftId)
        {
            var workShift = await _unitOfWork.Repository<WorkShift>()
                .FindAsync(w => w.Id == shiftId);

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
            staff.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
            return staff;
        }

        public async Task<User> AssignManagerWorkDaysAndShiftsAsync(int managerId, WorkDays workDays, IEnumerable<WorkShift> workShifts)
        {
            var manager = await _unitOfWork.Repository<User>()
                .FindAsync(m => m.UserId == managerId && m.RoleId == MANAGER_ROLE_ID);

            if (manager == null)
                throw new KeyNotFoundException($"Manager with ID {managerId} not found");

            manager.WorkDays = workDays;
            manager.UpdatedAt = DateTime.UtcNow;

            // Verify that all work shifts have days that match the manager's work days
            foreach (var shift in workShifts)
            {
                if ((shift.DaysOfWeek & workDays) == 0)
                {
                    throw new ValidationException($"Work shift with ID {shift.Id} has days that don't match the manager's work days");
                }
            }

            // Clear existing work shifts and add the new ones
            if (manager.MangerWorkShifts != null)
            {
                // Detach the manager from all current work shifts
                foreach (var shift in manager.MangerWorkShifts.ToList())
                {
                    shift.Managers.Remove(manager);
                }

                // Clear the manager's work shifts collection
                manager.MangerWorkShifts.Clear();

                // Add the new work shifts
                foreach (var shift in workShifts)
                {
                    manager.MangerWorkShifts.Add(shift);
                    if (!shift.Managers.Contains(manager))
                    {
                        shift.Managers.Add(manager);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
            return manager;
        }
    }
}