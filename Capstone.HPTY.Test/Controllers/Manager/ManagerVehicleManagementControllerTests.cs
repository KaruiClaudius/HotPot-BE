using Capstone.HPTY.API.Controllers.Manager;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Manager
{
    public class ManagerVehicleManagementControllerTests
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IVehicleManagementService> mockVehicleManagementService;
        private readonly Mock<ILogger<ManagerVehicleManagementController>> mockLogger;

        public ManagerVehicleManagementControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockVehicleManagementService = this.mockRepository.Create<IVehicleManagementService>();

            // Create logger with loose behavior to avoid having to set up every log call
            this.mockLogger = new Mock<ILogger<ManagerVehicleManagementController>>(MockBehavior.Loose);
        }

        private ManagerVehicleManagementController CreateManagerVehicleManagementController()
        {
            return new ManagerVehicleManagementController(
                this.mockVehicleManagementService.Object,
                this.mockLogger.Object);
        }

        #region GetVehicles Tests

        [Fact]
        public async Task GetVehicles_ReturnsOkResult_WithVehicles()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            var queryParams = new VehicleQueryParams();

            var pagedResult = new PagedResult<VehicleDTO>
            {
                Items = new List<VehicleDTO>
        {
            new VehicleDTO
            {
                VehicleId = 1,
                Name = "Test Vehicle",
                LicensePlate = "ABC123",
                Type = VehicleType.Car,
                Status = VehicleStatus.Available,
                Notes = "Test notes",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            }
        },
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            this.mockVehicleManagementService
                .Setup(s => s.GetAllVehiclesAsync(queryParams))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await controller.GetVehicles(queryParams);

            // Assert
            // First, check that we got an ActionResult<PagedResult<VehicleDTO>>
            Assert.IsType<ActionResult<PagedResult<VehicleDTO>>>(result);

            // Then, check that the Value property is an OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Check the ApiResponse structure
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<VehicleDTO>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicles retrieved successfully", apiResponse.Message);

            // Check the PagedResult data
            var returnedPagedResult = apiResponse.Data;
            Assert.NotNull(returnedPagedResult);
            Assert.Single(returnedPagedResult.Items);
            Assert.Equal(1, returnedPagedResult.TotalCount);
            Assert.Equal(1, returnedPagedResult.PageNumber);
            Assert.Equal(10, returnedPagedResult.PageSize);

            // Check the vehicle data
            var vehicle = returnedPagedResult.Items.First();
            Assert.Equal(1, vehicle.VehicleId);
            Assert.Equal("Test Vehicle", vehicle.Name);
            Assert.Equal("ABC123", vehicle.LicensePlate);
            Assert.Equal(VehicleType.Car, vehicle.Type);
            Assert.Equal(VehicleStatus.Available, vehicle.Status);

            this.mockVehicleManagementService.Verify(s => s.GetAllVehiclesAsync(queryParams), Times.Once);
        }

        [Fact]
        public async Task GetVehicles_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            var queryParams = new VehicleQueryParams();

            this.mockVehicleManagementService
                .Setup(s => s.GetAllVehiclesAsync(queryParams))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetVehicles(queryParams);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<VehicleDTO>>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while retrieving vehicles", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.GetAllVehiclesAsync(queryParams), Times.Once);
        }

        #endregion

        #region GetVehicleById Tests

        [Fact]
        public async Task GetVehicleById_ReturnsOkResult_WhenVehicleExists()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;

            var vehicle = new VehicleDTO
            {
                VehicleId = id,
                Name = "Test Vehicle",
                LicensePlate = "ABC123",
                Type = VehicleType.Car,
                Status = VehicleStatus.Available,
                Notes = "Test notes",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            this.mockVehicleManagementService
                .Setup(s => s.GetVehicleByIdAsync(id))
                .ReturnsAsync(vehicle);

            // Act
            var result = await controller.GetVehicleById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicle retrieved successfully", apiResponse.Message);

            var vehicleData = apiResponse.Data;
            Assert.Equal(id, vehicleData.VehicleId);
            Assert.Equal("Test Vehicle", vehicleData.Name);
            Assert.Equal("ABC123", vehicleData.LicensePlate);
            Assert.Equal(VehicleType.Car, vehicleData.Type);
            Assert.Equal(VehicleStatus.Available, vehicleData.Status);

            this.mockVehicleManagementService.Verify(s => s.GetVehicleByIdAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetVehicleById_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 999;

            this.mockVehicleManagementService
                .Setup(s => s.GetVehicleByIdAsync(id))
                .ThrowsAsync(new NotFoundException($"Vehicle with ID {id} not found"));

            // Act
            var result = await controller.GetVehicleById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Vehicle with ID {id} not found", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.GetVehicleByIdAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetVehicleById_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;

            this.mockVehicleManagementService
                .Setup(s => s.GetVehicleByIdAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetVehicleById(id);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while retrieving the vehicle", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.GetVehicleByIdAsync(id), Times.Once);
        }

        #endregion

        #region CreateVehicle Tests

        [Fact]
        public async Task CreateVehicle_ReturnsCreatedResult_WhenRequestIsValid()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            var request = new CreateVehicleRequest
            {
                Name = "New Vehicle",
                LicensePlate = "XYZ789",
                Type = VehicleType.Scooter,
                Status = VehicleStatus.Available,
                Notes = "New vehicle notes"
            };

            var createdVehicle = new VehicleDTO
            {
                VehicleId = 2,
                Name = request.Name,
                LicensePlate = request.LicensePlate,
                Type = request.Type,
                Status = request.Status,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = null
            };

            this.mockVehicleManagementService
                .Setup(s => s.CreateVehicleAsync(request))
                .ReturnsAsync(createdVehicle);

            // Act
            var result = await controller.CreateVehicle(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(ManagerVehicleManagementController.GetVehicleById), createdAtActionResult.ActionName);
            Assert.Equal(2, createdAtActionResult.RouteValues["id"]);

            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(createdAtActionResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicle created successfully", apiResponse.Message);

            var vehicleData = apiResponse.Data;
            Assert.Equal(2, vehicleData.VehicleId);
            Assert.Equal("New Vehicle", vehicleData.Name);
            Assert.Equal("XYZ789", vehicleData.LicensePlate);
            Assert.Equal(VehicleType.Scooter, vehicleData.Type);
            Assert.Equal(VehicleStatus.Available, vehicleData.Status);

            this.mockVehicleManagementService.Verify(s => s.CreateVehicleAsync(request), Times.Once);
        }

        [Fact]
        public async Task CreateVehicle_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            var request = new CreateVehicleRequest
            {
                Name = "New Vehicle",
                LicensePlate = "XYZ789",
                Type = VehicleType.Scooter,
                Status = VehicleStatus.Available
            };

            this.mockVehicleManagementService
                .Setup(s => s.CreateVehicleAsync(request))
                .ThrowsAsync(new ValidationException("License plate already exists"));

            // Act
            var result = await controller.CreateVehicle(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("License plate already exists", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.CreateVehicleAsync(request), Times.Once);
        }

        [Fact]
        public async Task CreateVehicle_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            var request = new CreateVehicleRequest
            {
                Name = "New Vehicle",
                LicensePlate = "XYZ789",
                Type = VehicleType.Scooter,
                Status = VehicleStatus.Available
            };

            this.mockVehicleManagementService
                .Setup(s => s.CreateVehicleAsync(request))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.CreateVehicle(request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while creating the vehicle", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.CreateVehicleAsync(request), Times.Once);
        }

        #endregion

        #region UpdateVehicle Tests

        [Fact]
        public async Task UpdateVehicle_ReturnsOkResult_WhenRequestIsValid()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;
            var request = new UpdateVehicleRequest
            {
                Name = "Updated Vehicle",
                LicensePlate = "ABC123",
                Type = VehicleType.Car,
                Status = VehicleStatus.InUse,
                Notes = "Updated notes"
            };

            var updatedVehicle = new VehicleDTO
            {
                VehicleId = id,
                Name = request.Name,
                LicensePlate = request.LicensePlate,
                Type = request.Type,
                Status = request.Status,
                Notes = request.Notes,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleAsync(id, request))
                .ReturnsAsync(updatedVehicle);

            // Act
            var result = await controller.UpdateVehicle(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicle updated successfully", apiResponse.Message);

            var vehicleData = apiResponse.Data;
            Assert.Equal(id, vehicleData.VehicleId);
            Assert.Equal("Updated Vehicle", vehicleData.Name);
            Assert.Equal("ABC123", vehicleData.LicensePlate);
            Assert.Equal(VehicleType.Car, vehicleData.Type);
            Assert.Equal(VehicleStatus.InUse, vehicleData.Status);
            Assert.Equal("Updated notes", vehicleData.Notes);
            Assert.NotNull(vehicleData.UpdatedAt);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleAsync(id, request), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicle_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 999;
            var request = new UpdateVehicleRequest
            {
                Name = "Updated Vehicle",
                LicensePlate = "ABC123",
                Type = VehicleType.Car,
                Status = VehicleStatus.InUse,
                Notes = "Updated notes"
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleAsync(id, request))
                .ThrowsAsync(new NotFoundException($"Vehicle with ID {id} not found"));

            // Act
            var result = await controller.UpdateVehicle(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Vehicle with ID {id} not found", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleAsync(id, request), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicle_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;
            var request = new UpdateVehicleRequest
            {
                Name = "Updated Vehicle",
                LicensePlate = "XYZ789", // Trying to update to a license plate that already exists
                Type = VehicleType.Car,
                Status = VehicleStatus.InUse,
                Notes = "Updated notes"
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleAsync(id, request))
                .ThrowsAsync(new ValidationException("License plate XYZ789 is already in use"));

            // Act
            var result = await controller.UpdateVehicle(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("License plate XYZ789 is already in use", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleAsync(id, request), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicle_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;
            var request = new UpdateVehicleRequest
            {
                Name = "Updated Vehicle",
                LicensePlate = "ABC123",
                Type = VehicleType.Car,
                Status = VehicleStatus.InUse,
                Notes = "Updated notes"
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleAsync(id, request))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.UpdateVehicle(id, request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while updating the vehicle", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleAsync(id, request), Times.Once);
        }

        #endregion

        #region DeleteVehicle Tests

        [Fact]
        public async Task DeleteVehicle_ReturnsOkResult_WhenVehicleExists()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;

            this.mockVehicleManagementService
                .Setup(s => s.DeleteVehicleAsync(id))
                .ReturnsAsync(true);

            // Act
            var result = await controller.DeleteVehicle(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<bool>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicle deleted successfully", apiResponse.Message);
            Assert.True(apiResponse.Data);

            this.mockVehicleManagementService.Verify(s => s.DeleteVehicleAsync(id), Times.Once);
        }

        [Fact]
        public async Task DeleteVehicle_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 999;

            this.mockVehicleManagementService
                .Setup(s => s.DeleteVehicleAsync(id))
                .ThrowsAsync(new NotFoundException($"Vehicle with ID {id} not found"));

            // Act
            var result = await controller.DeleteVehicle(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<bool>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Vehicle with ID {id} not found", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.DeleteVehicleAsync(id), Times.Once);
        }

        [Fact]
        public async Task DeleteVehicle_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;

            this.mockVehicleManagementService
                .Setup(s => s.DeleteVehicleAsync(id))
                .ThrowsAsync(new ValidationException("Cannot delete vehicle that is currently in use"));

            // Act
            var result = await controller.DeleteVehicle(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<bool>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Cannot delete vehicle that is currently in use", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.DeleteVehicleAsync(id), Times.Once);
        }

        [Fact]
        public async Task DeleteVehicle_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;

            this.mockVehicleManagementService
                .Setup(s => s.DeleteVehicleAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.DeleteVehicle(id);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<bool>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while deleting the vehicle", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.DeleteVehicleAsync(id), Times.Once);
        }

        #endregion

        #region UpdateVehicleStatus Tests

        [Fact]
        public async Task UpdateVehicleStatus_ReturnsOkResult_WhenRequestIsValid()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;
            var request = new UpdateVehicleStatusRequest
            {
                Status = VehicleStatus.InUse
            };

            var updatedVehicle = new VehicleDTO
            {
                VehicleId = id,
                Name = "Test Vehicle",
                LicensePlate = "ABC123",
                Type = VehicleType.Car,
                Status = VehicleStatus.InUse, // Updated status
                Notes = "Test notes",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleStatusAsync(id, request.Status))
                .ReturnsAsync(updatedVehicle);

            // Act
            var result = await controller.UpdateVehicleStatus(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal($"Vehicle status updated to {request.Status} successfully", apiResponse.Message);

            var vehicleData = apiResponse.Data;
            Assert.Equal(id, vehicleData.VehicleId);
            Assert.Equal(VehicleStatus.InUse, vehicleData.Status);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleStatusAsync(id, request.Status), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicleStatus_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 999;
            var request = new UpdateVehicleStatusRequest
            {
                Status = VehicleStatus.InUse
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleStatusAsync(id, request.Status))
                .ThrowsAsync(new NotFoundException($"Vehicle with ID {id} not found"));

            // Act
            var result = await controller.UpdateVehicleStatus(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Vehicle with ID {id} not found", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleStatusAsync(id, request.Status), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicleStatus_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;
            var request = new UpdateVehicleStatusRequest
            {
                Status = VehicleStatus.Available
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleStatusAsync(id, request.Status))
                .ThrowsAsync(new ValidationException("Cannot change status of vehicle that is currently assigned to an order"));

            // Act
            var result = await controller.UpdateVehicleStatus(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Cannot change status of vehicle that is currently assigned to an order", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleStatusAsync(id, request.Status), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicleStatus_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;
            var request = new UpdateVehicleStatusRequest
            {
                Status = VehicleStatus.InUse
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleStatusAsync(id, request.Status))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.UpdateVehicleStatus(id, request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while updating the vehicle status", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleStatusAsync(id, request.Status), Times.Once);
        }

        #endregion

        #region GetAvailableVehicles Tests

        [Fact]
        public async Task GetAvailableVehicles_ReturnsOkResult_WithAllAvailableVehicles()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            VehicleType? type = null; // No specific type, get all available vehicles

            var availableVehicles = new List<VehicleDTO>
            {
                new VehicleDTO
                {
                    VehicleId = 1,
                    Name = "Car 1",
                    LicensePlate = "CAR001",
                    Type = VehicleType.Car,
                    Status = VehicleStatus.Available,
                    Notes = "Available car",
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                },
                new VehicleDTO
                {
                    VehicleId = 2,
                    Name = "Scooter 1",
                    LicensePlate = "SCO001",
                    Type = VehicleType.Scooter,
                    Status = VehicleStatus.Available,
                    Notes = "Available scooter",
                    CreatedAt = DateTime.UtcNow.AddDays(-20),
                    UpdatedAt = DateTime.UtcNow.AddDays(-2)
                }
            };

            this.mockVehicleManagementService
                .Setup(s => s.GetAvailableVehiclesAsync(type))
                .ReturnsAsync(availableVehicles);

            // Act
            var result = await controller.GetAvailableVehicles(type);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<VehicleDTO>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Available vehicles retrieved successfully", apiResponse.Message);

            var vehicles = apiResponse.Data.ToList();
            Assert.Equal(2, vehicles.Count);

            // Check first vehicle
            Assert.Equal(1, vehicles[0].VehicleId);
            Assert.Equal("Car 1", vehicles[0].Name);
            Assert.Equal(VehicleType.Car, vehicles[0].Type);
            Assert.Equal(VehicleStatus.Available, vehicles[0].Status);

            // Check second vehicle
            Assert.Equal(2, vehicles[1].VehicleId);
            Assert.Equal("Scooter 1", vehicles[1].Name);
            Assert.Equal(VehicleType.Scooter, vehicles[1].Type);
            Assert.Equal(VehicleStatus.Available, vehicles[1].Status);

            this.mockVehicleManagementService.Verify(s => s.GetAvailableVehiclesAsync(type), Times.Once);
        }

        [Fact]
        public async Task GetAvailableVehicles_ReturnsOkResult_WithSpecificTypeVehicles()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            VehicleType type = VehicleType.Car; // Get only available cars

            var availableCars = new List<VehicleDTO>
            {
                new VehicleDTO
                {
                    VehicleId = 1,
                    Name = "Car 1",
                    LicensePlate = "CAR001",
                    Type = VehicleType.Car,
                    Status = VehicleStatus.Available,
                    Notes = "Available car",
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                },
                new VehicleDTO
                {
                    VehicleId = 3,
                    Name = "Car 2",
                    LicensePlate = "CAR002",
                    Type = VehicleType.Car,
                    Status = VehicleStatus.Available,
                    Notes = "Another available car",
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1)
                }
            };

            this.mockVehicleManagementService
                .Setup(s => s.GetAvailableVehiclesAsync(type))
                .ReturnsAsync(availableCars);

            // Act
            var result = await controller.GetAvailableVehicles(type);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<VehicleDTO>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Available Car vehicles retrieved successfully", apiResponse.Message);

            var vehicles = apiResponse.Data.ToList();
            Assert.Equal(2, vehicles.Count);

            // Check that all vehicles are of the requested type
            Assert.All(vehicles, v => Assert.Equal(VehicleType.Car, v.Type));
            Assert.All(vehicles, v => Assert.Equal(VehicleStatus.Available, v.Status));

            this.mockVehicleManagementService.Verify(s => s.GetAvailableVehiclesAsync(type), Times.Once);
        }

        [Fact]
        public async Task GetAvailableVehicles_ReturnsOkResult_WithEmptyList_WhenNoAvailableVehicles()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            VehicleType type = VehicleType.Scooter; // Get only available scooters

            var emptyList = new List<VehicleDTO>();

            this.mockVehicleManagementService
                .Setup(s => s.GetAvailableVehiclesAsync(type))
                .ReturnsAsync(emptyList);

            // Act
            var result = await controller.GetAvailableVehicles(type);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<VehicleDTO>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Available Scooter vehicles retrieved successfully", apiResponse.Message);

            var vehicles = apiResponse.Data.ToList();
            Assert.Empty(vehicles);

            this.mockVehicleManagementService.Verify(s => s.GetAvailableVehiclesAsync(type), Times.Once);
        }

        [Fact]
        public async Task GetAvailableVehicles_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            VehicleType? type = null;

            this.mockVehicleManagementService
                .Setup(s => s.GetAvailableVehiclesAsync(type))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetAvailableVehicles(type);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<IEnumerable<VehicleDTO>>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while retrieving available vehicles", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.GetAvailableVehiclesAsync(type), Times.Once);
        }

        #endregion

        #region Edge Cases and Additional Tests

        [Fact]
        public async Task GetVehicles_HandlesNullQueryParams()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            VehicleQueryParams queryParams = null;

            var pagedResult = new PagedResult<VehicleDTO>
            {
                Items = new List<VehicleDTO>
                {
                    new VehicleDTO
                    {
                        VehicleId = 1,
                        Name = "Test Vehicle",
                        LicensePlate = "ABC123",
                        Type = VehicleType.Car,
                        Status = VehicleStatus.Available,
                        Notes = "Test notes",
                        CreatedAt = DateTime.UtcNow.AddDays(-10),
                        UpdatedAt = DateTime.UtcNow.AddDays(-5)
                    }
                },
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            this.mockVehicleManagementService
                .Setup(s => s.GetAllVehiclesAsync(queryParams))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await controller.GetVehicles(queryParams);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<VehicleDTO>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicles retrieved successfully", apiResponse.Message);

            this.mockVehicleManagementService.Verify(s => s.GetAllVehiclesAsync(queryParams), Times.Once);
        }

        [Fact]
        public async Task CreateVehicle_HandlesNullNotes()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            var request = new CreateVehicleRequest
            {
                Name = "New Vehicle",
                LicensePlate = "XYZ789",
                Type = VehicleType.Scooter,
                Status = VehicleStatus.Available,
                Notes = null // Null notes
            };

            var createdVehicle = new VehicleDTO
            {
                VehicleId = 2,
                Name = request.Name,
                LicensePlate = request.LicensePlate,
                Type = request.Type,
                Status = request.Status,
                Notes = null, // Null notes
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = null
            };

            this.mockVehicleManagementService
                .Setup(s => s.CreateVehicleAsync(request))
                .ReturnsAsync(createdVehicle);

            // Act
            var result = await controller.CreateVehicle(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(createdAtActionResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicle created successfully", apiResponse.Message);

            var vehicleData = apiResponse.Data;
            Assert.Equal(2, vehicleData.VehicleId);
            Assert.Equal("New Vehicle", vehicleData.Name);
            Assert.Null(vehicleData.Notes);

            this.mockVehicleManagementService.Verify(s => s.CreateVehicleAsync(request), Times.Once);
        }

        [Fact]
        public async Task UpdateVehicle_HandlesNullNotes()
        {
            // Arrange
            var controller = this.CreateManagerVehicleManagementController();
            int id = 1;
            var request = new UpdateVehicleRequest
            {
                Name = "Updated Vehicle",
                LicensePlate = "ABC123",
                Type = VehicleType.Car,
                Status = VehicleStatus.InUse,
                Notes = null // Null notes
            };

            var updatedVehicle = new VehicleDTO
            {
                VehicleId = id,
                Name = request.Name,
                LicensePlate = request.LicensePlate,
                Type = request.Type,
                Status = request.Status,
                Notes = null, // Null notes
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            this.mockVehicleManagementService
                .Setup(s => s.UpdateVehicleAsync(id, request))
                .ReturnsAsync(updatedVehicle);

            // Act
            var result = await controller.UpdateVehicle(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<VehicleDTO>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Vehicle updated successfully", apiResponse.Message);

            var vehicleData = apiResponse.Data;
            Assert.Equal(id, vehicleData.VehicleId);
            Assert.Equal("Updated Vehicle", vehicleData.Name);
            Assert.Null(vehicleData.Notes);

            this.mockVehicleManagementService.Verify(s => s.UpdateVehicleAsync(id, request), Times.Once);
        }

        #endregion
    }

}