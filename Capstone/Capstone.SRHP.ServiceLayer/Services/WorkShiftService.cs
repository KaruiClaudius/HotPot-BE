using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services
{
    public class WorkShiftService : IWorkShiftService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkShiftService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<WorkShift>> GetAllAsync()
        {
            return await _unitOfWork.Repository<WorkShift>()
                .Include(ws => ws.Staff)
                .Include(ws => ws.Manager)
                .Where(ws => !ws.IsDelete)
                .ToListAsync();
        }

        public async Task<WorkShift?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<WorkShift>()
                .Include(ws => ws.Staff)
                .Include(ws => ws.Manager)
                .FirstOrDefaultAsync(ws => ws.Id == id && !ws.IsDelete);
        }

        public async Task<WorkShift> CreateAsync(WorkShift entity)
        {
            //if (entity.ShiftTime < DateTime.UtcNow)
            //    throw new ValidationException("Cannot create shifts in the past");

            //// Check if shift exists (including soft-deleted)
            //var existingShift = await _unitOfWork.Repository<WorkShift>()
            //    .FindAsync(w => w.ShiftTime == entity.ShiftTime);

            //if (existingShift != null)
            //{
            //    if (!existingShift.IsDelete)
            //    {
            //        throw new ValidationException("A shift already exists for this time");
            //    }
            //    else
            //    {
            //        // Reactivate and update the soft-deleted shift
            //        existingShift.IsDelete = false;
            //        existingShift.Staff = entity.Staff ?? new List<Staff>();
            //        existingShift.Manager = entity.Manager ?? new List<Manager>();
            //        existingShift.SetUpdateDate();
            //        await _unitOfWork.CommitAsync();
            //        return existingShift;
            //    }
            //}

            //entity.Staff ??= new List<Staff>();
            //entity.Manager ??= new List<Manager>();

            //_unitOfWork.Repository<WorkShift>().Insert(entity);
            //await _unitOfWork.CommitAsync();
            //return entity;
            return null;
        }

        public async Task UpdateAsync(int id, WorkShift entity)
        {
            var existingShift = await GetByIdAsync(id);
            if (existingShift == null)
                throw new NotFoundException($"WorkShift with ID {id} not found");

            if (entity.ShiftTime < DateTime.UtcNow)
                throw new ValidationException("Cannot update shifts to past times");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<WorkShift>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shift = await GetByIdAsync(id);
            if (shift == null)
                throw new NotFoundException($"WorkShift with ID {id} not found");

            shift.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetCurrentShiftsAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await _unitOfWork.Repository<WorkShift>()
                .Include(ws => ws.Staff)
                .Include(ws => ws.Manager)
                .Where(ws => !ws.IsDelete && ws.ShiftTime.Date == today)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetUpcomingShiftsAsync()
        {
            var now = DateTime.UtcNow;
            return await _unitOfWork.Repository<WorkShift>()
                .Include(ws => ws.Staff)
                .Include(ws => ws.Manager)
                .Where(ws => !ws.IsDelete && ws.ShiftTime > now)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetByDateAsync(DateTime date)
        {
            return await _unitOfWork.Repository<WorkShift>()
                .Include(ws => ws.Staff)
                .Include(ws => ws.Manager)
                .Where(ws => !ws.IsDelete && ws.ShiftTime.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Staff>> GetStaffInShiftAsync(int shiftId)
        {
            //var shift = await GetByIdAsync(shiftId);
            //if (shift == null)
            //    throw new NotFoundException($"WorkShift with ID {shiftId} not found");

            //return shift.Staff?.(s => !s.IsDelete).ToList() ?? new List<Staff>();
            return null;
        }

        public async Task<IEnumerable<Manager>> GetManagersInShiftAsync(int shiftId)
        {
            //var shift = await GetByIdAsync(shiftId);
            //if (shift == null)
            //    throw new NotFoundException($"WorkShift with ID {shiftId} not found");

            //return shift.Managers?.Where(m => !m.IsDelete).ToList() ?? new List<Manager>();
            return null;
        }

        public async Task AssignStaffToShiftAsync(int shiftId, int staffId)
        {
            //var shift = await GetByIdAsync(shiftId);
            //if (shift == null)
            //    throw new NotFoundException($"WorkShift with ID {shiftId} not found");

            //var staff = await _unitOfWork.Repository<Staff>()
            //    .FindAsync(s => s.StaffId == staffId && !s.IsDelete);

            //if (staff == null)
            //    throw new NotFoundException($"Staff with ID {staffId} not found");

            //if (shift.Staff?.Any(s => s.Id == staffId) == true)
            //    throw new ValidationException("Staff is already assigned to this shift");

            //shift.Staff ??= new List<Staff>();
            //shift.Staff.Add(staff);
            //await _unitOfWork.CommitAsync();

        }

        public async Task AssignManagerToShiftAsync(int shiftId, int managerId)
        {
            //var shift = await GetByIdAsync(shiftId);
            //if (shift == null)
            //    throw new NotFoundException($"WorkShift with ID {shiftId} not found");

            //var manager = await _unitOfWork.Repository<Manager>()
            //    .FindAsync(m => m.Id == managerId && !m.IsDelete);

            //if (manager == null)
            //    throw new NotFoundException($"Manager with ID {managerId} not found");

            //if (shift.Managers?.Any(m => m.Id == managerId) == true)
            //    throw new ValidationException("Manager is already assigned to this shift");

            //shift.Managers ??= new List<Manager>();
            //shift.Managers.Add(manager);
            //await _unitOfWork.CommitAsync();
        }

        public async Task RemoveStaffFromShiftAsync(int shiftId, int staffId)
        {
            //var shift = await GetByIdAsync(shiftId);
            //if (shift == null)
            //    throw new NotFoundException($"WorkShift with ID {shiftId} not found");

            //var staff = shift.Staff?.FirstOrDefault(s => s.Id == staffId);
            //if (staff == null)
            //    throw new ValidationException("Staff is not assigned to this shift");

            //shift.Staff?.Remove(staff);
            //await _unitOfWork.CommitAsync();
        }

        public async Task RemoveManagerFromShiftAsync(int shiftId, int managerId)
        {
            //var shift = await GetByIdAsync(shiftId);
            //if (shift == null)
            //    throw new NotFoundException($"WorkShift with ID {shiftId} not found");

            //var manager = shift.Managers?.FirstOrDefault(m => m.Id == managerId);
            //if (manager == null)
            //    throw new ValidationException("Manager is not assigned to this shift");

            //shift.Managers?.Remove(manager);
            //await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAttendanceStatusAsync(int shiftId, AttendanceStatus status)
        {
            var shift = await GetByIdAsync(shiftId);
            if (shift == null)
                throw new NotFoundException($"WorkShift with ID {shiftId} not found");

            shift.Status = status;
            shift.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }
    }
}
