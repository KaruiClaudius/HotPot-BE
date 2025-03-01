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
                        EquipmentType = "HotPot",
                        SeriesNumber = hotpot.SeriesNumber,
                        Name = hotpot.Hotpot?.Name ?? "Unknown",
                        IsAvailable = hotpot.Status,
                        LastInspectionDate = lastInspection?.LoggedDate,
                        LastInspectionStatus = lastInspection?.Status
                    });
                }

                // Get Utensils
                var utensils = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .Include(u => u.ConditionLogs.OrderByDescending(c => c.LoggedDate).Take(1))
                    .ToListAsync();

                foreach (var utensil in utensils)
                {
                    var lastInspection = utensil.ConditionLogs?.OrderByDescending(c => c.LoggedDate).FirstOrDefault();

                    result.Add(new EquipmentRetrievalDto
                    {
                        EquipmentId = utensil.UtensilId,
                        EquipmentType = "Utensil",
                        SeriesNumber = utensil.UtensilId.ToString(), // Utensils might not have series numbers
                        Name = utensil.Name,
                        IsAvailable = utensil.Status,
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

        public async Task<EquipmentRetrievalDto> GetRentalEquipmentDetailsAsync(int equipmentId, string equipmentType)
        {
            try
            {
                _logger.LogInformation("Getting details for {EquipmentType} with ID: {EquipmentId}", equipmentType, equipmentId);

                if (equipmentType.Equals("HotPot", StringComparison.OrdinalIgnoreCase))
                {
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
                        EquipmentType = "HotPot",
                        SeriesNumber = hotpot.SeriesNumber,
                        Name = hotpot.Hotpot?.Name ?? "Unknown",
                        IsAvailable = hotpot.Status,
                        LastInspectionDate = lastInspection?.LoggedDate,
                        LastInspectionStatus = lastInspection?.Status
                    };
                }
                else if (equipmentType.Equals("Utensil", StringComparison.OrdinalIgnoreCase))
                {
                    var utensil = await _unitOfWork.Repository<Utensil>()
                        .AsQueryable()
                        .Include(u => u.ConditionLogs.OrderByDescending(c => c.LoggedDate).Take(1))
                        .FirstOrDefaultAsync(u => u.UtensilId == equipmentId);

                    if (utensil == null)
                    {
                        throw new NotFoundException($"Utensil with ID {equipmentId} not found");
                    }

                    var lastInspection = utensil.ConditionLogs?.OrderByDescending(c => c.LoggedDate).FirstOrDefault();

                    return new EquipmentRetrievalDto
                    {
                        EquipmentId = utensil.UtensilId,
                        EquipmentType = "Utensil",
                        SeriesNumber = utensil.UtensilId.ToString(), // Utensils might not have series numbers
                        Name = utensil.Name,
                        IsAvailable = utensil.Status,
                        LastInspectionDate = lastInspection?.LoggedDate,
                        LastInspectionStatus = lastInspection?.Status
                    };
                }
                else
                {
                    throw new ArgumentException($"Invalid equipment type: {equipmentType}. Must be 'HotPot' or 'Utensil'.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rental equipment details for {EquipmentType} with ID: {EquipmentId}", equipmentType, equipmentId);
                throw;
            }
        }

        public async Task<EquipmentInspectionResponse> LogEquipmentInspectionAsync(EquipmentInspectionRequest request)
        {
            try
            {
                _logger.LogInformation("Logging inspection for {EquipmentType} with ID: {EquipmentId}", request.EquipmentType, request.EquipmentId);

                // Create condition log
                var conditionLog = new ConditionLog
                {
                    Name = request.ConditionName,
                    Description = request.ConditionDescription,
                    Status = request.Status,
                    ScheduleType = request.ScheduleType,
                    LoggedDate = DateTime.UtcNow
                };

                // Set the appropriate foreign key based on equipment type
                if (request.EquipmentType.Equals("HotPot", StringComparison.OrdinalIgnoreCase))
                {
                    var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                        .FindAsync(h => h.HotPotInventoryId == request.EquipmentId);

                    if (hotpot == null)
                    {
                        throw new NotFoundException($"HotPot with ID {request.EquipmentId} not found");
                    }

                    conditionLog.HotPotInventoryId = request.EquipmentId;

                    // Update availability status if requested
                    if (request.SetAsAvailable)
                    {
                        hotpot.Status = true;
                    }
                    else if (request.Status != MaintenanceStatus.Completed)
                    {
                        // If maintenance is needed, set as unavailable
                        hotpot.Status = false;
                    }
                }
                else if (request.EquipmentType.Equals("Utensil", StringComparison.OrdinalIgnoreCase))
                {
                    var utensil = await _unitOfWork.Repository<Utensil>()
                        .FindAsync(u => u.UtensilId == request.EquipmentId);

                    if (utensil == null)
                    {
                        throw new NotFoundException($"Utensil with ID {request.EquipmentId} not found");
                    }

                    conditionLog.UtensilID = request.EquipmentId;

                    // Update availability status if requested
                    if (request.SetAsAvailable)
                    {
                        utensil.Status = true;
                    }
                    else if (request.Status != MaintenanceStatus.Completed)
                    {
                        // If maintenance is needed, set as unavailable
                        utensil.Status = false;
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid equipment type: {request.EquipmentType}. Must be 'HotPot' or 'Utensil'.");
                }

                // Save condition log
                await _unitOfWork.Repository<ConditionLog>().InsertAsync(conditionLog);
                await _unitOfWork.CommitAsync();

                // Return response
                return new EquipmentInspectionResponse
                {
                    ConditionLogId = conditionLog.ConditionLogId,
                    EquipmentId = request.EquipmentId,
                    EquipmentType = request.EquipmentType,
                    ConditionName = conditionLog.Name,
                    ConditionDescription = conditionLog.Description,
                    Status = conditionLog.Status,
                    ScheduleType = conditionLog.ScheduleType,
                    LoggedDate = conditionLog.LoggedDate,
                    IsAvailable = request.SetAsAvailable || (request.Status == MaintenanceStatus.Completed)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging inspection for {EquipmentType} with ID: {EquipmentId}", request.EquipmentType, request.EquipmentId);
                throw;
            }
        }
        public async Task<bool> UpdateEquipmentAvailabilityAsync(int equipmentId, string equipmentType, bool isAvailable)
        {
            try
            {
                _logger.LogInformation("Updating availability for {EquipmentType} with ID: {EquipmentId} to {IsAvailable}",
                    equipmentType, equipmentId, isAvailable);

                if (equipmentType.Equals("HotPot", StringComparison.OrdinalIgnoreCase))
                {
                    var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                        .FindAsync(h => h.HotPotInventoryId == equipmentId);

                    if (hotpot == null)
                    {
                        throw new NotFoundException($"HotPot with ID {equipmentId} not found");
                    }

                    hotpot.Status = isAvailable;
                    await _unitOfWork.CommitAsync();

                    return true;
                }
                else if (equipmentType.Equals("Utensil", StringComparison.OrdinalIgnoreCase))
                {
                    var utensil = await _unitOfWork.Repository<Utensil>()
                        .FindAsync(u => u.UtensilId == equipmentId);

                    if (utensil == null)
                    {
                        throw new NotFoundException($"Utensil with ID {equipmentId} not found");
                    }

                    utensil.Status = isAvailable;
                    await _unitOfWork.CommitAsync();

                    return true;
                }
                else
                {
                    throw new ArgumentException($"Invalid equipment type: {equipmentType}. Must be 'HotPot' or 'Utensil'.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating availability for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);
                throw;
            }
        }

        public async Task<IEnumerable<EquipmentInspectionResponse>> GetEquipmentInspectionHistoryAsync(int equipmentId, string equipmentType)
        {
            try
            {
                _logger.LogInformation("Getting inspection history for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                List<ConditionLog> conditionLogs;

                if (equipmentType.Equals("HotPot", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if the HotPot exists
                    var hotpot = await _unitOfWork.Repository<HotPotInventory>()
                        .FindAsync(h => h.HotPotInventoryId == equipmentId);

                    if (hotpot == null)
                    {
                        throw new NotFoundException($"HotPot with ID {equipmentId} not found");
                    }

                    // Get condition logs for this HotPot
                    conditionLogs = await _unitOfWork.Repository<ConditionLog>()
                        .AsQueryable()
                        .Where(c => c.HotPotInventoryId == equipmentId)
                        .OrderByDescending(c => c.LoggedDate)
                        .ToListAsync();
                }
                else if (equipmentType.Equals("Utensil", StringComparison.OrdinalIgnoreCase))
                {
                    // Check if the Utensil exists
                    var utensil = await _unitOfWork.Repository<Utensil>()
                        .FindAsync(u => u.UtensilId == equipmentId);

                    if (utensil == null)
                    {
                        throw new NotFoundException($"Utensil with ID {equipmentId} not found");
                    }

                    // Get condition logs for this Utensil
                    conditionLogs = await _unitOfWork.Repository<ConditionLog>()
                        .AsQueryable()
                        .Where(c => c.UtensilID == equipmentId)
                        .OrderByDescending(c => c.LoggedDate)
                        .ToListAsync();
                }
                else
                {
                    throw new ArgumentException($"Invalid equipment type: {equipmentType}. Must be 'HotPot' or 'Utensil'.");
                }

                // Map condition logs to response DTOs
                return conditionLogs.Select(log => new EquipmentInspectionResponse
                {
                    ConditionLogId = log.ConditionLogId,
                    EquipmentId = equipmentType.Equals("HotPot", StringComparison.OrdinalIgnoreCase)
                        ? log.HotPotInventoryId.Value
                        : log.UtensilID.Value,
                    EquipmentType = equipmentType,
                    ConditionName = log.Name,
                    ConditionDescription = log.Description,
                    Status = log.Status,
                    ScheduleType = log.ScheduleType,
                    LoggedDate = log.LoggedDate,
                    IsAvailable = log.Status == MaintenanceStatus.Completed
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting inspection history for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);
                throw;
            }
        }
    }
}
