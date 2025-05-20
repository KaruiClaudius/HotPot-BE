using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Extensions;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class VehicleManagementService : IVehicleManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VehicleManagementService> _logger;

        public VehicleManagementService(IUnitOfWork unitOfWork, ILogger<VehicleManagementService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PagedResult<VehicleDTO>> GetAllVehiclesAsync(VehicleQueryParams queryParams)
        {
            try
            {
                var query = _unitOfWork.Repository<Vehicle>()
                    .GetAll(v => !v.IsDelete);

                // Apply filters and sorting
                query = query.ApplyFilters(queryParams);
                query = query.ApplySorting(queryParams);

                // Get paged result
                var pagedResult = await query.ToPagedResultAsync(queryParams);

                // Map to DTOs
                return new PagedResult<VehicleDTO>
                {
                    Items = pagedResult.Items.Select(MapToVehicleDTO).ToList(),
                    TotalCount = pagedResult.TotalCount,
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving vehicles");
                throw;
            }
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(int id)
        {
            try
            {
                var vehicle = await _unitOfWork.Repository<Vehicle>()
                    .FindAsync(v => v.VehicleId == id && !v.IsDelete);

                if (vehicle == null)
                    throw new NotFoundException($"Vehicle with ID {id} not found");

                return MapToVehicleDTO(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving vehicle with ID {VehicleId}", id);
                throw;
            }
        }

        public async Task<VehicleDTO> CreateVehicleAsync(CreateVehicleRequest request)
        {
            try
            {
                // Validate license plate is unique
                var existingVehicle = await _unitOfWork.Repository<Vehicle>()
                    .FindAsync(v => v.LicensePlate == request.LicensePlate && !v.IsDelete);

                if (existingVehicle != null)
                    throw new ValidationException($"Vehicle with license plate {request.LicensePlate} already exists");

                var vehicle = new Vehicle
                {
                    Name = request.Name,
                    LicensePlate = request.LicensePlate,
                    Type = request.Type,
                    Status = request.Status,
                    Notes = request.Notes,
                    CreatedAt = DateTime.UtcNow.AddHours(7)
                };

                _unitOfWork.Repository<Vehicle>().Insert(vehicle);
                await _unitOfWork.CommitAsync();

                return MapToVehicleDTO(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new vehicle");
                throw;
            }
        }

        public async Task<VehicleDTO> UpdateVehicleAsync(int id, UpdateVehicleRequest request)
        {
            try
            {
                var vehicle = await _unitOfWork.Repository<Vehicle>()
                    .FindAsync(v => v.VehicleId == id && !v.IsDelete);

                if (vehicle == null)
                    throw new NotFoundException($"Vehicle with ID {id} not found");

                // Check if license plate is being changed and if it's unique
                if (request.LicensePlate != vehicle.LicensePlate)
                {
                    var existingVehicle = await _unitOfWork.Repository<Vehicle>()
                        .FindAsync(v => v.LicensePlate == request.LicensePlate && v.VehicleId != id && !v.IsDelete);

                    if (existingVehicle != null)
                        throw new ValidationException($"Vehicle with license plate {request.LicensePlate} already exists");
                }

                // Update properties
                vehicle.Name = request.Name;
                vehicle.LicensePlate = request.LicensePlate;
                vehicle.Type = request.Type;
                vehicle.Status = request.Status;
                vehicle.Notes = request.Notes;
                vehicle.SetUpdateDate();

                await _unitOfWork.CommitAsync();

                return MapToVehicleDTO(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating vehicle with ID {VehicleId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            try
            {
                var vehicle = await _unitOfWork.Repository<Vehicle>()
                    .FindAsync(v => v.VehicleId == id && !v.IsDelete);

                if (vehicle == null)
                    throw new NotFoundException($"Vehicle with ID {id} not found");

                // Check if vehicle is in use
                var inUseShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.VehicleId == id && !so.IsDelivered && !so.IsDelete);

                if (inUseShippingOrder != null)
                    throw new ValidationException("Cannot delete vehicle that is currently in use for deliveries");

                vehicle.IsDelete = true;
                vehicle.SetUpdateDate();

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting vehicle with ID {VehicleId}", id);
                throw;
            }
        }

        public async Task<VehicleDTO> UpdateVehicleStatusAsync(int id, VehicleStatus status)
        {
            try
            {
                var vehicle = await _unitOfWork.Repository<Vehicle>()
                    .FindAsync(v => v.VehicleId == id && !v.IsDelete);

                if (vehicle == null)
                    throw new NotFoundException($"Vehicle with ID {id} not found");

                // If trying to set to Unavailable, check if it's in use
                if (status == VehicleStatus.Unavailable && vehicle.Status == VehicleStatus.InUse)
                {
                    var inUseShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                        .FindAsync(so => so.VehicleId == id && !so.IsDelivered && !so.IsDelete);

                    if (inUseShippingOrder != null)
                        throw new ValidationException("Cannot set vehicle to Unavailable while it is in use for deliveries");
                }

                vehicle.Status = status;
                vehicle.SetUpdateDate();

                await _unitOfWork.CommitAsync();

                return MapToVehicleDTO(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for vehicle with ID {VehicleId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<VehicleDTO>> GetAvailableVehiclesAsync(VehicleType? type = null)
        {
            try
            {
                var query = _unitOfWork.Repository<Vehicle>()
                    .GetAll(v => v.Status == VehicleStatus.Available && !v.IsDelete);

                if (type.HasValue)
                    query = query.Where(v => v.Type == type.Value);

                var vehicles = await query.ToListAsync();
                return vehicles.Select(MapToVehicleDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving available vehicles");
                throw;
            }
        }

        private VehicleDTO MapToVehicleDTO(Vehicle vehicle)
        {
            return new VehicleDTO
            {
                VehicleId = vehicle.VehicleId,
                Name = vehicle.Name,
                LicensePlate = vehicle.LicensePlate,
                Type = vehicle.Type,
                Status = vehicle.Status,
                Notes = vehicle.Notes,
                CreatedAt = vehicle.CreatedAt,
                UpdatedAt = vehicle.UpdatedAt
            };
        }
    }
}
