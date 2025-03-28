using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ConditionLogDto> LogEquipmentFailureAsync(EquipmentFailureDto failureDto)
        {
            // Validate foreign keys before attempting to save
            string equipmentName = null;

            if (failureDto.HotPotInventoryId.HasValue)
            {
                var hotPot = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .FirstOrDefaultAsync(h => h.HotPotInventoryId == failureDto.HotPotInventoryId.Value);

                if (hotPot == null)
                {
                    throw new InvalidOperationException($"Hot Pot with ID {failureDto.HotPotInventoryId.Value} does not exist.");
                }

                equipmentName = hotPot.Hotpot.Name;
            }

            if (failureDto.UtensilID.HasValue)
            {
                var utensil = await _unitOfWork.Repository<Utensil>()
                    .AsQueryable()
                    .FirstOrDefaultAsync(u => u.UtensilId == failureDto.UtensilID.Value);

                if (utensil == null)
                {
                    throw new InvalidOperationException($"Utensil with ID {failureDto.UtensilID.Value} does not exist.");
                }

                equipmentName = utensil.Name;
            }

            // Ensure at least one equipment type is specified
            if (!failureDto.HotPotInventoryId.HasValue && !failureDto.UtensilID.HasValue)
            {
                throw new InvalidOperationException("Either HotPotInventoryId or UtensilId must be specified.");
            }

            // Create entity from DTO
            var conditionLog = new DamageDevice
            {
                Name = failureDto.Name ?? equipmentName, // Use equipment name if name is not provided
                Description = failureDto.Description,
                HotPotInventoryId = failureDto.HotPotInventoryId,
                UtensilId = failureDto.UtensilID,
                LoggedDate = DateTime.UtcNow,
                Status = MaintenanceStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Repository<DamageDevice>().Insert(conditionLog);
            await _unitOfWork.CommitAsync();

            // Create a DTO with the equipment name we already fetched
            var dto = new ConditionLogDto
            {
                DamageDeviceId = conditionLog.DamageDeviceId,
                Name = conditionLog.Name,
                Description = conditionLog.Description,
                Status = conditionLog.Status,
                LoggedDate = conditionLog.LoggedDate,
                UpdatedAt = conditionLog.UpdatedAt,
                EquipmentName = equipmentName,
                EquipmentType = failureDto.HotPotInventoryId.HasValue ? EquipmentType.HotPot : EquipmentType.Utensil,
                EquipmentId = failureDto.HotPotInventoryId ?? failureDto.UtensilID
            };

            return dto;
        }
     

        public async Task<ConditionLogDetailDto> GetConditionLogByIdAsync(int conditionLogId)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable(c => c.DamageDeviceId == conditionLogId)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .Include(c => c.ReplacementRequests)
                    .ThenInclude(r => r.AssignedStaff)
                .FirstOrDefaultAsync();

            if (conditionLog == null)
                return null;

            return MapToConditionLogDetailDto(conditionLog);
        }

        public async Task<IEnumerable<ConditionLogDto>> GetActiveConditionLogsAsync()
        {
            var conditionLogs = await _unitOfWork.Repository<DamageDevice>()
                .GetAll(c => c.Status != MaintenanceStatus.Completed)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .OrderByDescending(c => c.LoggedDate)
                .ToListAsync();

            return conditionLogs.Select(MapToConditionLogDto);
        }            

        private ConditionLogDto MapToConditionLogDto(DamageDevice conditionLog)
        {
            if (conditionLog == null)
            {
                return null;
            }

            var dto = new ConditionLogDto
            {
                DamageDeviceId = conditionLog.DamageDeviceId,
                Name = conditionLog.Name,
                Description = conditionLog.Description,
                Status = conditionLog.Status,
                LoggedDate = conditionLog.LoggedDate,
                UpdatedAt = conditionLog.UpdatedAt
            };

            // Determine equipment type and details
            if (conditionLog.HotPotInventoryId.HasValue)
            {
                dto.EquipmentType = EquipmentType.HotPot;
                dto.EquipmentId = conditionLog.HotPotInventoryId.Value;

                // Safely access HotPotInventory name
                if (conditionLog.HotPotInventory != null)
                {
                    dto.EquipmentName = conditionLog.HotPotInventory.Hotpot.Name;
                }
                else
                {
                    // If HotPotInventory is null, fetch it from the database
                    var hotPot = _unitOfWork.Repository<HotPotInventory>()
                        .AsQueryable()
                        .FirstOrDefault(h => h.HotPotInventoryId == conditionLog.HotPotInventoryId.Value);

                    dto.EquipmentName = hotPot?.Hotpot.Name ?? "Unknown Hot Pot";
                }
            }
            else if (conditionLog.UtensilId.HasValue)
            {
                dto.EquipmentType = EquipmentType.Utensil;
                dto.EquipmentId = conditionLog.UtensilId.Value;

                // Safely access Utensil name
                if (conditionLog.Utensil != null)
                {
                    dto.EquipmentName = conditionLog.Utensil.Name;
                }
                else
                {
                    // If Utensil is null, fetch it from the database
                    var utensil = _unitOfWork.Repository<Utensil>()
                        .AsQueryable()
                        .FirstOrDefault(u => u.UtensilId == conditionLog.UtensilId.Value);

                    dto.EquipmentName = utensil?.Name ?? "Unknown Utensil";
                }
            }
            else
            {
                // Handle the case where neither HotPotInventoryId nor UtensilId is set
                dto.EquipmentName = "Unknown Equipment";
            }

            return dto;
        }

        private ConditionLogDetailDto MapToConditionLogDetailDto(DamageDevice conditionLog)
        {
            // Start with the base DTO properties
            var dto = new ConditionLogDetailDto
            {
                DamageDeviceId = conditionLog.DamageDeviceId,
                Name = conditionLog.Name,
                Description = conditionLog.Description,
                Status = conditionLog.Status,
                LoggedDate = conditionLog.LoggedDate,
                UpdatedAt = conditionLog.UpdatedAt,
                ReplacementRequests = new List<ReplacementRequestDto>()
            };

            // Determine equipment type and details
            if (conditionLog.HotPotInventoryId.HasValue)
            {
                dto.EquipmentType = EquipmentType.HotPot;
                dto.EquipmentId = conditionLog.HotPotInventoryId.Value;
                dto.EquipmentName = conditionLog.HotPotInventory.Hotpot.Name ?? "Unknown Hot Pot";
            }
            else if (conditionLog.UtensilId.HasValue)
            {
                dto.EquipmentType = EquipmentType.Utensil;
                dto.EquipmentId = conditionLog.UtensilId.Value;
                dto.EquipmentName = conditionLog.Utensil.Name ?? "Unknown Utensil";
            }

            // Map replacement requests if any
            if (conditionLog.ReplacementRequests != null)
            {
                foreach (var request in conditionLog.ReplacementRequests)
                {
                    dto.ReplacementRequests.Add(new ReplacementRequestDto
                    {
                        ReplacementRequestId = request.ReplacementRequestId,
                        RequestReason = request.RequestReason,
                        AdditionalNotes = request.AdditionalNotes,
                        Status = request.Status,
                        RequestDate = request.RequestDate,
                        ReviewDate = request.ReviewDate,
                        ReviewNotes = request.ReviewNotes,
                        AssignedStaffId = request.AssignedStaffId
                    });

                    // If there's an assigned staff, get their name
                    if (request.AssignedStaffId.HasValue && request.AssignedStaff != null)
                    {
                        dto.AssignedStaffId = request.AssignedStaffId;
                        dto.AssignedStaffName = $"{request.AssignedStaff.Name}";
                    }
                }
            }

            return dto;
        }

        public async Task<ConditionLogDto> VerifyEquipmentFailureAsync(int conditionLogId, bool isVerified, string verificationNotes, int staffId)
        {
            var conditionLog = await _unitOfWork.Repository<DamageDevice>()
                .AsQueryable()
                .Where(c => c.DamageDeviceId == conditionLogId)
                .Include(c => c.HotPotInventory)
                .Include(c => c.Utensil)
                .FirstOrDefaultAsync();

            if (conditionLog == null)
                return null;

            // Update the condition log status based on verification
            conditionLog.Status = isVerified ? MaintenanceStatus.Completed : MaintenanceStatus.Cancelled;
            conditionLog.Description += $"\n\nVerification Notes ({DateTime.UtcNow:g}): {verificationNotes}";
            conditionLog.SetUpdateDate();

            // If verified, create a replacement request if none exists
            if (isVerified && (conditionLog.ReplacementRequests == null || !conditionLog.ReplacementRequests.Any()))
            {
                var replacementRequest = new ReplacementRequest
                {
                    RequestReason = $"Verified equipment failure: {conditionLog.Name}",
                    AdditionalNotes = verificationNotes,
                    Status = ReplacementRequestStatus.Pending,
                    RequestDate = DateTime.UtcNow,
                    DamageDeviceId = conditionLogId,
                    AssignedStaffId = staffId,
                    EquipmentType = conditionLog.HotPotInventoryId.HasValue ?
                        EquipmentType.HotPot : EquipmentType.Utensil,
                    HotPotInventoryId = conditionLog.HotPotInventoryId,
                    UtensilId = conditionLog.UtensilId,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.Repository<ReplacementRequest>().InsertAsync(replacementRequest);
            }

            await _unitOfWork.CommitAsync();

            // Map to DTO and return
            return MapToConditionLogDto(conditionLog);
        }
    }
}
