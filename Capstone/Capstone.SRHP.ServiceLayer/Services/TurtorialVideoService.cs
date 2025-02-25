using Capstone.HPTY.ModelLayer.Entities;
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
    public class TurtorialVideoService : ITurtorialVideoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TurtorialVideoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TurtorialVideo>> GetAllAsync()
        {
            return await _unitOfWork.Repository<TurtorialVideo>()
                .Include(tv => tv.Hotpot)
                .Where(tv => !tv.IsDelete)
                .ToListAsync();
        }

        public async Task<TurtorialVideo?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<TurtorialVideo>()
                .Include(tv => tv.Hotpot)
                .FirstOrDefaultAsync(tv => tv.TurtorialVideoId == id && !tv.IsDelete);
        }

        public async Task<TurtorialVideo> CreateAsync(TurtorialVideo entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Video name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.VideoURL))
                throw new ValidationException("Video URL cannot be empty");

            if (!Uri.TryCreate(entity.VideoURL, UriKind.Absolute, out _))
                throw new ValidationException("Invalid video URL format");

            // Check if video exists (including soft-deleted)
            var existingVideo = await _unitOfWork.Repository<TurtorialVideo>()
                .FindAsync(v => v.VideoURL == entity.VideoURL);

            if (existingVideo != null)
            {
                if (!existingVideo.IsDelete)
                {
                    throw new ValidationException("Video URL already exists");
                }
                else
                {
                    // Reactivate and update the soft-deleted video
                    existingVideo.IsDelete = false;
                    existingVideo.Name = entity.Name;
                    existingVideo.Description = entity.Description;
                    existingVideo.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingVideo;
                }
            }

            _unitOfWork.Repository<TurtorialVideo>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, TurtorialVideo entity)
        {
            var existingVideo = await GetByIdAsync(id);
            if (existingVideo == null)
                throw new NotFoundException($"Tutorial video with ID {id} not found");

            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ValidationException("Tutorial video name cannot be empty");

            if (string.IsNullOrWhiteSpace(entity.VideoURL))
                throw new ValidationException("Video URL cannot be empty");

            // Validate URL format
            if (!Uri.TryCreate(entity.VideoURL, UriKind.Absolute, out _))
                throw new ValidationException("Invalid video URL format");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<TurtorialVideo>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var video = await GetByIdAsync(id);
            if (video == null)
                throw new NotFoundException($"Tutorial video with ID {id} not found");

            // Check if video is used by any hotpots
            var hotpots = await _unitOfWork.Repository<Hotpot>()
                .FindAsync(h => h.TurtorialVideoID == id && !h.IsDelete);

            if (hotpots != null)
                throw new ValidationException("Cannot delete tutorial video that is associated with hotpots");

            video.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TurtorialVideo>> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Search name cannot be empty");

            return await _unitOfWork.Repository<TurtorialVideo>()
                .FindAll(tv => tv.Name.Contains(name) && !tv.IsDelete)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hotpot>> GetAssociatedHotpotsAsync(int videoId)
        {
            var video = await GetByIdAsync(videoId);
            if (video == null)
                throw new NotFoundException($"Tutorial video with ID {videoId} not found");

            return await _unitOfWork.Repository<Hotpot>()
                .FindAll(h => h.TurtorialVideoID == videoId && !h.IsDelete)
                .ToListAsync();
        }
    }
}
