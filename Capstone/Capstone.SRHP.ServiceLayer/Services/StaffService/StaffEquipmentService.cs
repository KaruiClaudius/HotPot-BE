using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffEquipmentService : IStaffEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffEquipmentService> _logger;

        public StaffEquipmentService(
            IUnitOfWork unitOfWork,
            ILogger<StaffEquipmentService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<EquipmentRetrievalDto>> GetAllRentalEquipmentAsync()
        {
            try
            {
                _logger.LogInformation("Getting all rental equipment");

                var result = new List<EquipmentRetrievalDto>();

                // Get HotPot inventory
                var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Include(h => h.Hotpot)
                    .Include(h => h.ConditionLogs.OrderByDescending(c => c.LoggedDate).Take(1))
                    .ToListAsync();

                foreach (var hotpot in hotpotInventory)
                {
                    var lastInspection = hotpot.ConditionLogs?.OrderByDescending(c => c.LoggedDate).FirstOrDefault();

                    result.Add(new EquipmentRetrievalDto
                    {
                        EquipmentId = hotpot.HotPotInventoryId,
                        SeriesNumber = hotpot.SeriesNumber,
                        Name = hotpot.Hotpot?.Name ?? "Unknown",
                        IsAvailable = hotpot.Status == HotpotStatus.Available,
                        LastInspectionDate = lastInspection?.LoggedDate,
                        LastInspectionStatus = lastInspection?.Status
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rental equipment");
                throw;
            }
        }

        public async Task<EquipmentRetrievalDto> GetRentalEquipmentDetailsAsync(int equipmentId)
        {
            try
            {
                _logger.LogInformation("Getting details for equipment with ID: {EquipmentId}", equipmentId);

                var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Include(h => h.Hotpot)
                    .Include(h => h.ConditionLogs.OrderByDescending(c => c.LoggedDate).Take(1))
                    .FirstOrDefaultAsync(h => h.HotPotInventoryId == equipmentId);

                if (hotpot == null)
                {
                    throw new NotFoundException($"HotPot with ID {equipmentId} not found");
                }

                var lastInspection = hotpot.ConditionLogs?.OrderByDescending(c => c.LoggedDate).FirstOrDefault();

                return new EquipmentRetrievalDto
                {
                    EquipmentId = hotpot.HotPotInventoryId,
                    SeriesNumber = hotpot.SeriesNumber,
                    Name = hotpot.Hotpot?.Name ?? "Unknown",
                    IsAvailable = hotpot.Status == HotpotStatus.Available,
                    LastInspectionDate = lastInspection?.LoggedDate,
                    LastInspectionStatus = lastInspection?.Status
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rental equipment details for ID: {EquipmentId}", equipmentId);
                throw;
            }
        }


        public async Task<EquipmentInspectionResponse> LogEquipmentInspectionAsync(EquipmentInspectionRequest request)
        {
            try
            {
                _logger.LogInformation("Logging inspection for equipment with ID: {EquipmentId}", request.EquipmentId);

                // Get the HotPot
                var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(h => h.HotPotInventoryId == request.EquipmentId);

                if (hotpot == null)
                {
                    throw new NotFoundException($"HotPot with ID {request.EquipmentId} not found");
                }

                // Create condition log
                var conditionLog = new DamageDevice
                {
                    Name = request.ConditionName,
                    Description = request.ConditionDescription,
                    Status = request.Status,
                    LoggedDate = DateTime.UtcNow.AddHours(7),
                    HotPotInventoryId = request.EquipmentId
                };

                // Set finish date if status is Completed or Cancelled
                if (request.Status == MaintenanceStatus.Completed || request.Status == MaintenanceStatus.Cancelled)
                {
                    conditionLog.FinishDate = DateTime.UtcNow.AddHours(7);
                }

                // Update availability status if requested
                if (request.SetAsAvailable)
                {
                    hotpot.Status = HotpotStatus.Available;
                }
                else if (request.Status != MaintenanceStatus.Completed)
                {
                    // If maintenance is needed, set as unavailable
                    hotpot.Status = HotpotStatus.Damaged;
                }

                // Save condition log
                await _unitOfWork.Repository<DamageDevice>().InsertAsync(conditionLog);
                await _unitOfWork.CommitAsync();

                // Return response
                return new EquipmentInspectionResponse
                {
                    ConditionLogId = conditionLog.DamageDeviceId,
                    Equipment = hotpot.Hotpot?.Name ?? $"HotPot #{hotpot.HotPotInventoryId}",
                    ConditionName = conditionLog.Name,
                    ConditionDescription = conditionLog.Description,
                    Status = conditionLog.Status,
                    LoggedDate = conditionLog.LoggedDate,
                    FinishDate = conditionLog.FinishDate,
                    IsAvailable = request.SetAsAvailable || (request.Status == MaintenanceStatus.Completed)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging inspection for equipment with ID: {EquipmentId}", request.EquipmentId);
                throw;
            }
        }
        public async Task<bool> UpdateEquipmentAvailabilityAsync(int equipmentId, UpdateAvailabilityRequest request)
        {
            try
            {
                _logger.LogInformation("Updating availability for equipment with ID: {EquipmentId} to {IsAvailable}",
                    equipmentId, request.IsAvailable);

                var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAsync(h => h.HotPotInventoryId == equipmentId);

                if (hotpot == null)
                {
                    throw new NotFoundException($"HotPot with ID {equipmentId} not found");
                }

                // Convert boolean to appropriate HotpotStatus enum value
                hotpot.Status = request.IsAvailable ? HotpotStatus.Available : HotpotStatus.Damaged;
                await _unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating availability for equipment with ID: {EquipmentId}", equipmentId);
                throw;
            }
        }


        public async Task<IEnumerable<EquipmentInspectionResponse>> GetEquipmentInspectionHistoryAsync(int equipmentId)
        {
            try
            {
                _logger.LogInformation("Getting inspection history for equipment with ID: {EquipmentId}", equipmentId);

                // Check if the HotPot exists
                var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Include(h => h.Hotpot)
                    .FirstOrDefaultAsync(h => h.HotPotInventoryId == equipmentId);

                if (hotpot == null)
                {
                    throw new NotFoundException($"HotPot with ID {equipmentId} not found");
                }

                // Get condition logs for this HotPot
                var conditionLogs = await _unitOfWork.Repository<DamageDevice>()
                    .AsQueryable()
                    .Where(c => c.HotPotInventoryId == equipmentId)
                    .OrderByDescending(c => c.LoggedDate)
                    .ToListAsync();

                // Map condition logs to response DTOs
                return conditionLogs.Select(log => new EquipmentInspectionResponse
                {
                    ConditionLogId = log.DamageDeviceId,
                    Equipment = hotpot.Hotpot?.Name ?? $"HotPot #{hotpot.HotPotInventoryId}",
                    ConditionName = log.Name,
                    ConditionDescription = log.Description,
                    Status = log.Status,
                    LoggedDate = log.LoggedDate,
                    FinishDate = log.FinishDate,
                    IsAvailable = log.Status == MaintenanceStatus.Completed
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting inspection history for equipment with ID: {EquipmentId}", equipmentId);
                throw;
            }
        }
    }
}
