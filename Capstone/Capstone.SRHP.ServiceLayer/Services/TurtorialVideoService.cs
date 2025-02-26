using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TurtorialVideoService> _logger;

        public TurtorialVideoService(IUnitOfWork unitOfWork, ILogger<TurtorialVideoService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<TurtorialVideo>> GetAllAsync()
        {
            return await _unitOfWork.Repository<TurtorialVideo>()
                .FindList(tv => !tv.IsDelete);
        }

        public async Task<TurtorialVideo> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<TurtorialVideo>()
                .FindAsync(tv => tv.TurtorialVideoId == id && !tv.IsDelete);
        }

        public async Task<IEnumerable<TurtorialVideo>> GetByHotpotTypeAsync(int hotpotTypeId)
        {
            // Get all tutorial videos used by hotpots of a specific type
            var hotpots = await _unitOfWork.Repository<Hotpot>()
                .FindList(h => h.HotpotTypeID == hotpotTypeId && !h.IsDelete);

            var tutorialVideoIds = hotpots
                .Where(h => h.TurtorialVideoID > 0)  
                .Select(h => h.TurtorialVideoID)
                .Distinct();

            var tutorialVideos = new List<TurtorialVideo>();

            foreach (var videoId in tutorialVideoIds)
            {
                var video = await GetByIdAsync(videoId);
                if (video != null)
                {
                    tutorialVideos.Add(video);
                }
            }

            return tutorialVideos;
        }

        public async Task<TurtorialVideo> CreateAsync(TurtorialVideo tutorialVideo)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(tutorialVideo.Name))
            {
                throw new ValidationException("Tutorial video name is required");
            }

            if (string.IsNullOrWhiteSpace(tutorialVideo.VideoURL))
            {
                throw new ValidationException("Tutorial video URL is required");
            }

            _unitOfWork.Repository<TurtorialVideo>().Insert(tutorialVideo);
            await _unitOfWork.CommitAsync();

            return tutorialVideo;
        }

        public async Task UpdateAsync(int id, TurtorialVideo tutorialVideo)
        {
            var existingVideo = await GetByIdAsync(id);
            if (existingVideo == null)
            {
                throw new NotFoundException($"Tutorial video with ID {id} not found");
            }

            // Update only the properties that are provided
            if (!string.IsNullOrWhiteSpace(tutorialVideo.Name))
            {
                existingVideo.Name = tutorialVideo.Name;
            }

            if (!string.IsNullOrWhiteSpace(tutorialVideo.VideoURL))
            {
                existingVideo.VideoURL = tutorialVideo.VideoURL;
            }

            if (tutorialVideo.Description != null)
            {
                existingVideo.Description = tutorialVideo.Description;
            }

            existingVideo.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tutorialVideo = await GetByIdAsync(id);
            if (tutorialVideo == null)
            {
                throw new NotFoundException($"Tutorial video with ID {id} not found");
            }

            // Check if any hotpots are using this tutorial video
            if (await IsInUseAsync(id))
            {
                throw new ValidationException("Cannot delete tutorial video that is in use by hotpots");
            }

            tutorialVideo.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsInUseAsync(int id)
        {
            return await _unitOfWork.Repository<Hotpot>()
                .AnyAsync(h => h.TurtorialVideoID == id && !h.IsDelete);
        }
    }
}
