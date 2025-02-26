using System;
using System.Collections.Generic;
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

        public ScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<WorkShift> GetWorkShiftByIdAsync(int shiftId)
        {
            return await _unitOfWork.Repository<WorkShift>()
                .AsQueryable(w => w.Id == shiftId)
                .Include(w => w.Staff)
                    .ThenInclude(s => s.User)
                .Include(w => w.Manager)
                    .ThenInclude(m => m.User)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetAllWorkShiftsAsync(DateTime? startDate = null, DateTime? endDate = null, int pageNumber = 1, int pageSize = 10)
        {
            var query = _unitOfWork.Repository<WorkShift>().GetAll();

            if (startDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime <= endDate.Value);
            }

            return await query
                .Include(w => w.Staff)
                    .ThenInclude(s => s.User)
                .Include(w => w.Manager)
                    .ThenInclude(m => m.User)
                .OrderBy(w => w.ShiftTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetStaffWorkShiftsAsync(int staffId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _unitOfWork.Repository<WorkShift>()
                .GetAll(w => w.StaffID == staffId);

            if (startDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime <= endDate.Value);
            }

            return await query
                .Include(w => w.Manager)
                    .ThenInclude(m => m.User)
                .OrderBy(w => w.ShiftTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkShift>> GetManagerAssignedShiftsAsync(int managerId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _unitOfWork.Repository<WorkShift>()
                .GetAll(w => w.ManagerID == managerId);

            if (startDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime <= endDate.Value);
            }

            return await query
                .Include(w => w.Staff)
                    .ThenInclude(s => s.User)
                .OrderBy(w => w.ShiftTime)
                .ToListAsync();
        }

        public async Task<WorkShift> CreateWorkShiftAsync(WorkShift workShift)
        {
            // Verify staff exists
            var staff = await _unitOfWork.Repository<Staff>()
                .FindAsync(s => s.StaffId == workShift.StaffID);

            if (staff == null)
                throw new KeyNotFoundException($"Staff with ID {workShift.StaffID} not found");

            // Verify manager exists
            var manager = await _unitOfWork.Repository<Manager>()
                .FindAsync(m => m.ManagerId == workShift.ManagerID);

            if (manager == null)
                throw new KeyNotFoundException($"Manager with ID {workShift.ManagerID} not found");

            workShift.CreatedAt = DateTime.UtcNow;

            _unitOfWork.Repository<WorkShift>().Insert(workShift);
            await _unitOfWork.CommitAsync();

            // Load related entities for the response
            return await GetWorkShiftByIdAsync(workShift.Id);
        }

        public async Task<WorkShift> UpdateWorkShiftAsync(int shiftId, DateTime shiftTime, AttendanceStatus? status)
        {
            var workShift = await _unitOfWork.Repository<WorkShift>()
                .FindAsync(w => w.Id == shiftId);

            if (workShift == null)
                throw new KeyNotFoundException($"Work shift with ID {shiftId} not found");

            workShift.ShiftTime = shiftTime;
            workShift.Status = status;
            workShift.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            // Load related entities for the response
            return await GetWorkShiftByIdAsync(shiftId);
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

        public async Task<int> GetTotalWorkShiftsCountAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _unitOfWork.Repository<WorkShift>().GetAll();

            if (startDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(w => w.ShiftTime <= endDate.Value);
            }

            return await query.CountAsync();
        }
    }
}
