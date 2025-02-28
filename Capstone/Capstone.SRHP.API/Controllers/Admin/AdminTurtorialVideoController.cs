using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using Capstone.HPTY.ServiceLayer.DTOs.Video;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/tutorial-videos")]
    [Authorize(Roles = "Admin")]
    public class AdminTurtorialVideoController : ControllerBase
    {
        private readonly ITurtorialVideoService _tutorialVideoService;
        private readonly IHotpotService _hotpotService;
        private readonly ILogger<AdminTurtorialVideoController> _logger;

        public AdminTurtorialVideoController(
            ITurtorialVideoService tutorialVideoService,
            IHotpotService hotpotService,
            ILogger<AdminTurtorialVideoController> logger)
        {
            _tutorialVideoService = tutorialVideoService;
            _hotpotService = hotpotService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<TurtorialVideoDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<TurtorialVideoDto>>>> GetAllTutorialVideos(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Page number and page size must be greater than 0"
                    });
                }

                _logger.LogInformation($"Admin retrieving tutorial videos - Page {pageNumber}, Size {pageSize}");
                var pagedVideos = await _tutorialVideoService.GetPagedAsync(pageNumber, pageSize);
                var videoDtos = new List<TurtorialVideoDto>();

                // Get all video IDs from the current page
                var videoIds = pagedVideos.Items.Select(v => v.TurtorialVideoId).ToList();

                // Get all videos in use status in a single query
                var videosInUseStatus = await _tutorialVideoService.GetVideosInUseStatusAsync(videoIds);

                // Get all hotpot counts in a single query
                var hotpotCounts = await _hotpotService.GetCountsByTutorialVideosAsync(videoIds);

                foreach (var video in pagedVideos.Items)
                {
                    var isInUse = videosInUseStatus.ContainsKey(video.TurtorialVideoId) ?
                        videosInUseStatus[video.TurtorialVideoId] : false;

                    var hotpotCount = isInUse && hotpotCounts.ContainsKey(video.TurtorialVideoId) ?
                        hotpotCounts[video.TurtorialVideoId] : 0;

                    videoDtos.Add(new TurtorialVideoDto
                    {
                        TurtorialVideoId = video.TurtorialVideoId,
                        Name = video.Name,
                        VideoURL = video.VideoURL,
                        Description = video.Description,
                        HotpotCount = hotpotCount,
                        CreatedAt = video.CreatedAt,
                        UpdatedAt = video.UpdatedAt
                    });
                }

                var result = new PagedResult<TurtorialVideoDto>
                {
                    Items = videoDtos,
                    PageNumber = pagedVideos.PageNumber,
                    PageSize = pagedVideos.PageSize,
                    TotalCount = pagedVideos.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<TurtorialVideoDto>>
                {
                    Success = true,
                    Message = "Tutorial videos retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tutorial videos");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve tutorial videos"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<TurtorialVideoDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<TurtorialVideoDetailDto>>> GetTutorialVideoById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving tutorial video with ID: {VideoId}", id);
                var video = await _tutorialVideoService.GetByIdAsync(id);

                if (video == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Tutorial video with ID {id} not found"
                    });
                }

                var hotpots = await _hotpotService.GetByTutorialVideoAsync(id);
                var hotpotDtos = hotpots.Select(h => new HotpotDto
                {
                    HotpotId = h.HotpotId,
                    Name = h.Name,
                    Material = h.Material,
                    Size = h.Size,
                    Description = h.Description,
                    ImageURL = h.ImageURL,
                    Price = h.Price,
                    Status = h.Status,
                    Quantity = h.Quantity,
                    HotpotTypeID = h.HotpotTypeID,
                    HotpotTypeName = h.HotpotType?.Name,
                    TurtorialVideoID = h.TurtorialVideoID,
                    TurtorialVideoName = video.Name
                }).ToList();

                var videoDto = new TurtorialVideoDetailDto
                {
                    TurtorialVideoId = video.TurtorialVideoId,
                    Name = video.Name,
                    VideoURL = video.VideoURL,
                    Description = video.Description,
                    HotpotCount = hotpotDtos.Count,
                    CreatedAt = video.CreatedAt,
                    UpdatedAt = video.UpdatedAt,
                    Hotpots = hotpotDtos
                };

                return Ok(new ApiResponse<TurtorialVideoDetailDto>
                {
                    Success = true,
                    Message = "Tutorial video retrieved successfully",
                    Data = videoDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tutorial video with ID: {VideoId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve tutorial video"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<TurtorialVideoDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<TurtorialVideoDto>>> CreateTutorialVideo([FromBody] TurtorialVideoRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new tutorial video: {VideoName}", request.Name);

                var tutorialVideo = new TurtorialVideo
                {
                    Name = request.Name,
                    VideoURL = request.VideoURL,
                    Description = request.Description
                };

                var createdVideo = await _tutorialVideoService.CreateAsync(tutorialVideo);

                var videoDto = new TurtorialVideoDto
                {
                    TurtorialVideoId = createdVideo.TurtorialVideoId,
                    Name = createdVideo.Name,
                    VideoURL = createdVideo.VideoURL,
                    Description = createdVideo.Description,
                    HotpotCount = 0,
                    CreatedAt = createdVideo.CreatedAt,
                    UpdatedAt = createdVideo.UpdatedAt
                };

                return CreatedAtAction(
                    nameof(GetTutorialVideoById),
                    new { id = createdVideo.TurtorialVideoId },
                    new ApiResponse<TurtorialVideoDto>
                    {
                        Success = true,
                        Message = "Tutorial video created successfully",
                        Data = videoDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating tutorial video: {VideoName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating tutorial video: {VideoName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create tutorial video"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<TurtorialVideoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<TurtorialVideoDto>>> UpdateTutorialVideo(int id, [FromBody] TurtorialVideoRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating tutorial video with ID: {VideoId}", id);

                var tutorialVideo = new TurtorialVideo
                {
                    Name = request.Name,
                    VideoURL = request.VideoURL,
                    Description = request.Description
                };

                await _tutorialVideoService.UpdateAsync(id, tutorialVideo);

                var updatedVideo = await _tutorialVideoService.GetByIdAsync(id);
                var hotpotCount = await _hotpotService.GetCountByTutorialVideoAsync(id);

                var videoDto = new TurtorialVideoDto
                {
                    TurtorialVideoId = updatedVideo.TurtorialVideoId,
                    Name = updatedVideo.Name,
                    VideoURL = updatedVideo.VideoURL,
                    Description = updatedVideo.Description,
                    HotpotCount = hotpotCount,
                    CreatedAt = updatedVideo.CreatedAt,
                    UpdatedAt = updatedVideo.UpdatedAt
                };

                return Ok(new ApiResponse<TurtorialVideoDto>
                {
                    Success = true,
                    Message = "Tutorial video updated successfully",
                    Data = videoDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating tutorial video with ID: {VideoId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Tutorial video not found with ID: {VideoId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating tutorial video with ID: {VideoId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update tutorial video"
                });
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteTutorialVideo(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting tutorial video with ID: {VideoId}", id);

                // Check if the tutorial video exists
                var video = await _tutorialVideoService.GetByIdAsync(id);
                if (video == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Tutorial video with ID {id} not found"
                    });
                }

                // Check if any hotpots are using this tutorial video
                if (await _tutorialVideoService.IsInUseAsync(id))
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Cannot delete tutorial video that is in use by hotpots"
                    });
                }

                await _tutorialVideoService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Tutorial video deleted successfully",
                    Data = $"Tutorial video '{video.Name}' with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting tutorial video with ID: {VideoId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Tutorial video not found with ID: {VideoId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting tutorial video with ID: {VideoId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete tutorial video"
                });
            }
        }

        [HttpGet("hotpot-type/{hotpotTypeId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<TurtorialVideoDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<TurtorialVideoDto>>>> GetTutorialVideosByHotpotType(int hotpotTypeId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving tutorial videos for hotpot type with ID: {HotpotTypeId}", hotpotTypeId);

                var videos = await _tutorialVideoService.GetByHotpotTypeAsync(hotpotTypeId);
                var videoDtos = new List<TurtorialVideoDto>();

                foreach (var video in videos)
                {
                    var hotpotCount = await _hotpotService.GetCountByTutorialVideoAsync(video.TurtorialVideoId);

                    videoDtos.Add(new TurtorialVideoDto
                    {
                        TurtorialVideoId = video.TurtorialVideoId,
                        Name = video.Name,
                        VideoURL = video.VideoURL,
                        Description = video.Description,
                        HotpotCount = hotpotCount,
                        CreatedAt = video.CreatedAt,
                        UpdatedAt = video.UpdatedAt
                    });
                }

                return Ok(new ApiResponse<IEnumerable<TurtorialVideoDto>>
                {
                    Success = true,
                    Message = "Tutorial videos retrieved successfully",
                    Data = videoDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tutorial videos for hotpot type with ID: {HotpotTypeId}", hotpotTypeId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve tutorial videos"
                });
            }
        }

        //[HttpGet("search")]
        //[ProducesResponseType(typeof(ApiResponse<IEnumerable<TurtorialVideoDto>>), StatusCodes.Status200OK)]
        //public async Task<ActionResult<ApiResponse<IEnumerable<TurtorialVideoDto>>>> SearchTutorialVideos([FromQuery] string searchTerm)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Admin searching tutorial videos with term: {SearchTerm}", searchTerm);

        //        if (string.IsNullOrWhiteSpace(searchTerm))
        //        {
        //            return await GetAllTutorialVideos();
        //        }

        //        var allVideos = await _tutorialVideoService.GetAllAsync();
        //        var filteredVideos = allVideos.Where(v =>
        //            v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        //            (v.Description != null && v.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
        //        ).ToList();

        //        var videoDtos = new List<TurtorialVideoDto>();

        //        foreach (var video in filteredVideos)
        //        {
        //            var hotpotCount = await _hotpotService.GetCountByTutorialVideoAsync(video.TurtorialVideoId);

        //            videoDtos.Add(new TurtorialVideoDto
        //            {
        //                TurtorialVideoId = video.TurtorialVideoId,
        //                Name = video.Name,
        //                VideoURL = video.VideoURL,
        //                Description = video.Description,
        //                HotpotCount = hotpotCount,
        //                CreatedAt = video.CreatedAt,
        //                UpdatedAt = video.UpdatedAt
        //            });
        //        }

        //        return Ok(new ApiResponse<IEnumerable<TurtorialVideoDto>>
        //        {
        //            Success = true,
        //            Message = $"Found {videoDtos.Count} tutorial videos matching '{searchTerm}'",
        //            Data = videoDtos
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error searching tutorial videos with term: {SearchTerm}", searchTerm);
        //        return BadRequest(new ApiErrorResponse
        //        {
        //            Status = "Error",
        //            Message = "Failed to search tutorial videos"
        //        });
        //    }
        //}
    }
}
