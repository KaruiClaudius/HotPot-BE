using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.UserService
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public AuthService(IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email && !u.IsDelete);

            if (user == null || !PasswordTools.VerifyPassword(request.Password, user.Password))
                throw new UnauthorizedException("Invalid email or password");

            return await GenerateAuthResponseAsync(user);
        }


        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            try
            {
                // Check if user exists (including soft-deleted)
                var existingUser = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.Email == request.Email);

                if (existingUser != null && !existingUser.IsDelete)
                {
                    throw new ValidationException("Email already in use");
                }

                // Hash password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

                // Get Customer role
                var customerRole = await _unitOfWork.Repository<Role>()
                    .FindAsync(r => r.Name == "Customer");
                if (customerRole == null)
                    throw new ValidationException("Customer role not found");

                User resultUser;

                if (existingUser != null)
                {
                    // Only reactivate if the existing user was a Customer
                    if (existingUser.RoleID != customerRole.RoleId)
                    {
                        throw new ValidationException("Email already registered with a different role");
                    }

                    // Reactivate soft-deleted user
                    existingUser.IsDelete = false;
                    existingUser.Name = request.Name;
                    existingUser.PhoneNumber = request.PhoneNumber;
                    existingUser.Password = hashedPassword; // Update password
                    existingUser.SetUpdateDate();
                    await _unitOfWork.CommitAsync();

                    // Reactivate customer record
                    await CreateCustomerEntryAsync(existingUser);
                    resultUser = existingUser;
                }
                else
                {
                    // Create new user with Customer role
                    var newUser = new User
                    {
                        Email = request.Email,
                        Password = hashedPassword,
                        Name = request.Name,
                        PhoneNumber = request.PhoneNumber,
                        RoleID = customerRole.RoleId, // Always set to Customer role
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    _unitOfWork.Repository<User>().Insert(newUser);
                    await _unitOfWork.CommitAsync();

                    // Create customer record
                    await CreateCustomerEntryAsync(newUser);
                    resultUser = newUser;
                }

                return await GenerateAuthResponseAsync(resultUser);
            }
            catch (ValidationException)
            {
                // Rethrow validation exceptions directly
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering customer", ex);
            }
        }





        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var user = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && !u.IsDelete);

            if (user == null || user.RefreshTokenExpiry <= DateTime.UtcNow)
                throw new UnauthorizedException("Invalid refresh token");

            return await GenerateAuthResponseAsync(user);
        }

        public async Task LogoutAsync(int userId)
        {
            var user = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == userId);
            if (user != null)
            {
                user.RefreshToken = null;
                user.RefreshTokenExpiry = null;
                await _unitOfWork.CommitAsync();
            }
        }

        private async Task<AuthResponse> GenerateAuthResponseAsync(User user)
        {
            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();
            var expiresAt = _jwtService.GetExpirationDate(accessToken);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _unitOfWork.CommitAsync();

            // Manual mapping to UserDto
            var userDto = new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleName = user.Role?.Name ?? "Customer",
                ImageURL = user.ImageURL ?? string.Empty
            };

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = expiresAt,
                User = userDto
            };
        }

        private async Task<int> GetDefaultRoleId()
        {
            var customerRole = await _unitOfWork.Repository<Role>()
                .FindAsync(r => r.Name == "Customer" && !r.IsDelete);

            if (customerRole == null)
                throw new ValidationException("Default role not found");

            return customerRole.RoleId;
        }

        private async Task CreateCustomerEntryAsync(User user)
        {
            try
            {
                var existingCustomer = await _unitOfWork.Repository<Customer>()
                    .FindAsync(c => c.UserID == user.UserId);

                if (existingCustomer != null)
                {
                    existingCustomer.IsDelete = false;
                    existingCustomer.SetUpdateDate();
                }
                else
                {
                    var customer = new Customer
                    {
                        UserID = user.UserId,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    _unitOfWork.Repository<Customer>().Insert(customer);
                }

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating customer entry", ex);
            }
        }

        public async Task<AuthResponse> GoogleLoginAsync(string idToken)
        {
            try
            {             
                // Verify the Google token
                var payload = await _jwtService.VerifyGoogleTokenAsync(idToken);

                // Check if user exists by email
                var user = await _unitOfWork.Repository<User>()
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == payload.Email && !u.IsDelete);

                if (user == null)
                {
                    // Check if user exists but is deleted
                    var existingUser = await _unitOfWork.Repository<User>()
                        .FindAsync(u => u.Email == payload.Email);

                    if (existingUser != null && existingUser.IsDelete)
                    {
                        // Reactivate user
                        existingUser.IsDelete = false;
                        existingUser.Name = payload.Name;
                        existingUser.SetUpdateDate();
                        await _unitOfWork.CommitAsync();

                        // Reactivate customer record
                        await CreateCustomerEntryAsync(existingUser);

                        return await GenerateAuthResponseAsync(existingUser);
                    }

                    // Get Customer role
                    var customerRole = await _unitOfWork.Repository<Role>()
                        .FindAsync(r => r.Name == "Customer");

                    if (customerRole == null)
                        throw new ValidationException("Customer role not found");

                    // Create new user
                    user = new User
                    {
                        Email = payload.Email,
                        Name = payload.Name,
                        // Generate a random password since the user won't use it
                        Password = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString()),
                        RoleID = customerRole.RoleId,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    _unitOfWork.Repository<User>().Insert(user);
                    await _unitOfWork.CommitAsync();

                    // Create customer record
                    await CreateCustomerEntryAsync(user);
                }

                // Generate JWT token and return auth response
                return await GenerateAuthResponseAsync(user);
            }
            catch (Exception ex)
            {
                throw new UnauthorizedException("Google authentication failed: " + ex.Message);
            }
        }
    }
}
