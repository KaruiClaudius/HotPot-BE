using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Staff> GetStaffByIdAsync(int staffId)
        {
            var staff = await _unitOfWork.Repository<Staff>()
                .Include(s => s.User)
                .Include(s => s.WorkShifts)
                .FirstOrDefaultAsync(s => s.StaffId == staffId && !s.IsDelete);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {staffId} not found");

            return staff;
        }

        public async Task<Staff> GetStaffByUserIdAsync(int userId)
        {
            var staff = await _unitOfWork.Repository<Staff>()
                .Include(s => s.User)
                .Include(s => s.WorkShifts)
                .FirstOrDefaultAsync(s => s.UserId == userId && !s.IsDelete);

            if (staff == null)
                throw new NotFoundException($"Staff with User ID {userId} not found");

            return staff;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _unitOfWork.Repository<Staff>()
                .Include(s => s.User)
                .Include(s => s.WorkShifts)
                .Where(s => !s.IsDelete)
                .ToListAsync();
        }

        public async Task<Staff> CreateStaffAsync(Staff staff)
        {
            _unitOfWork.Repository<Staff>().Insert(staff);
            await _unitOfWork.CommitAsync();
            return staff;
        }

        public async Task UpdateStaffAsync(int staffId, Staff staff)
        {
            var existingStaff = await _unitOfWork.Repository<Staff>()
                .FindAsync(s => s.StaffId == staffId);

            if (existingStaff == null)
                throw new NotFoundException($"Staff with ID {staffId} not found");

            // Update properties as needed
            existingStaff.WorkDays = staff.WorkDays;
            existingStaff.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteStaffAsync(int staffId)
        {
            var staff = await _unitOfWork.Repository<Staff>()
                .FindAsync(s => s.StaffId == staffId);

            if (staff == null)
                throw new NotFoundException($"Staff with ID {staffId} not found");

            staff.SoftDelete();
            staff.SetUpdateDate();

            await _unitOfWork.CommitAsync();
        }
    }
}
