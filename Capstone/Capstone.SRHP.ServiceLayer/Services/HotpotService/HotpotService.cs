using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.HotpotService
{
    public class HotpotService : IHotpotService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotpotService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Hotpot>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Hotpot>()
                .Include(h => h.HotpotType)
                .Include(h => h.TurtorialVideo)
                .Where(h => !h.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<Hotpot>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<Hotpot>()
                .Include(h => h.HotpotType)
                .Include(h => h.TurtorialVideo)
                .Where(h => !h.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(h => h.HotpotId) // Ensure consistent ordering
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Hotpot>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Hotpot?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Hotpot>()
                .Include(h => h.HotpotType)
                .Include(h => h.TurtorialVideo)
                .FirstOrDefaultAsync(h => h.HotpotId == id && !h.IsDelete);
        }

        public async Task<Hotpot> CreateAsync(Hotpot entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Hotpot name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Hotpot material cannot be empty");

            if (entity.Size <= 0)
                throw new ValidationException("Size must be greater than 0");

            if (entity.Price <= 0)
                throw new ValidationException("Price must be greater than 0");

            if (entity.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            // Validate HotpotType exists
            var hotpotType = await _unitOfWork.Repository<HotpotType>()
                .FindAsync(ht => ht.HotpotTypeId == entity.HotpotTypeID && !ht.IsDelete);

            if (hotpotType == null)
                throw new ValidationException("Invalid hotpot type");

            // Validate TurtorialVideo exists if provided
            if (entity.TurtorialVideoID != 0)
            {
                var video = await _unitOfWork.Repository<TurtorialVideo>()
                    .FindAsync(tv => tv.TurtorialVideoId == entity.TurtorialVideoID && !tv.IsDelete);

                if (video == null)
                    throw new ValidationException("Invalid tutorial video");
            }

            entity.LastMaintainDate = DateTime.UtcNow;
            _unitOfWork.Repository<Hotpot>().Insert(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task UpdateAsync(int id, Hotpot entity)
        {
            var existingHotpot = await GetByIdAsync(id);
            if (existingHotpot == null)
                throw new NotFoundException($"Hotpot with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Hotpot name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.Material))
                throw new ValidationException("Hotpot material cannot be empty");

            if (entity.Size <= 0)
                throw new ValidationException("Size must be greater than 0");

            if (entity.Price <= 0)
                throw new ValidationException("Price must be greater than 0");

            if (entity.Quantity < 0)
                throw new ValidationException("Quantity cannot be negative");

            // Validate HotpotType exists
            var hotpotType = await _unitOfWork.Repository<HotpotType>()
                .FindAsync(ht => ht.HotpotTypeId == entity.HotpotTypeID && !ht.IsDelete);

            if (hotpotType == null)
                throw new ValidationException("Invalid hotpot type");

            // Validate TurtorialVideo exists if provided
            if (entity.TurtorialVideoID != 0)
            {
                var video = await _unitOfWork.Repository<TurtorialVideo>()
                    .FindAsync(tv => tv.TurtorialVideoId == entity.TurtorialVideoID && !tv.IsDelete);

                if (video == null)
                    throw new ValidationException("Invalid tutorial video");
            }

            entity.SetUpdateDate();
            await _unitOfWork.Repository<Hotpot>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotpot = await GetByIdAsync(id);
            if (hotpot == null)
                throw new NotFoundException($"Hotpot with ID {id} not found");

            hotpot.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Hotpot>> GetAvailableHotpotsAsync()
        {
            return await _unitOfWork.Repository<Hotpot>()
                .Include(h => h.HotpotType)
                .Where(h => !h.IsDelete && h.Status && h.Quantity > 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hotpot>> GetByTypeAsync(int typeId)
        {
            return await _unitOfWork.Repository<Hotpot>()
                .Include(h => h.HotpotType)
                .Where(h => h.HotpotTypeID == typeId && !h.IsDelete)
                .ToListAsync();
        }

        public async Task UpdateStatusAsync(int id, bool status)
        {
            var hotpot = await GetByIdAsync(id);
            if (hotpot == null)
                throw new NotFoundException($"Hotpot with ID {id} not found");

            hotpot.Status = status;
            hotpot.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateQuantityAsync(int id, int quantity)
        {
            var hotpot = await GetByIdAsync(id);
            if (hotpot == null)
                throw new NotFoundException($"Hotpot with ID {id} not found");

            if (hotpot.Quantity + quantity < 0)
                throw new ValidationException("Cannot reduce quantity below 0");

            hotpot.Quantity += quantity;
            hotpot.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsAvailableAsync(int id)
        {
            var hotpot = await GetByIdAsync(id);
            return hotpot != null && hotpot.Status && hotpot.Quantity > 0;
        }
        public async Task<IEnumerable<Hotpot>> GetByTutorialVideoAsync(int tutorialVideoId)
        {
            return await _unitOfWork.Repository<Hotpot>()
                .FindList(h => h.TurtorialVideoID == tutorialVideoId && !h.IsDelete);
        }

        public async Task<int> GetCountByTutorialVideoAsync(int tutorialVideoId)
        {
            var hotpots = await GetByTutorialVideoAsync(tutorialVideoId);
            return hotpots.Count();
        }

        public async Task<Dictionary<int, int>> GetCountsByTutorialVideosAsync(IEnumerable<int> videoIds)
        {
            var counts = await _unitOfWork.Repository<Hotpot>()
                .FindAll(h => !h.IsDelete && videoIds.Contains(h.TurtorialVideoID))
                .GroupBy(h => h.TurtorialVideoID)
                .Select(g => new { VideoId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.VideoId, x => x.Count);

            // Ensure all requested video IDs are in the dictionary, even if they have no hotpots
            foreach (var videoId in videoIds)
            {
                if (!counts.ContainsKey(videoId))
                {
                    counts[videoId] = 0;
                }
            }

            return counts;
        }
    }
}
