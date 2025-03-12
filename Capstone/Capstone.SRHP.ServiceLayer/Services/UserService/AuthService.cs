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
            string normalizedPhoneNumber = NormalizePhoneNumber(request.PhoneNumber);

            var user = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.PhoneNumber == normalizedPhoneNumber && !u.IsDelete);

            if (user == null || !PasswordTools.VerifyPassword(request.Password, user.Password))
                throw new UnauthorizedException("Sai SĐT hoặc Mật khẩu");

            return await GenerateAuthResponseAsync(user);
        }


        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            try
            {
                string normalizedPhoneNumber = NormalizePhoneNumber(request.PhoneNumber);



                // Check if user exists (including soft-deleted)
                var existingUser = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.PhoneNumber == request.PhoneNumber);

                if (existingUser != null && !existingUser.IsDelete)
                {
                    throw new ValidationException("SĐT đã được sử dụng");
                }

                // Hash password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

                // Get Customer role
                var customerRole = await _unitOfWork.Repository<Role>()
                    .FindAsync(r => r.Name == "Customer");
                if (customerRole == null)
                    throw new ValidationException("Role Khách hàng không tìm thấy");

                User resultUser;

                if (existingUser != null)
                {
                    // Only reactivate if the existing user was a Customer
                    if (existingUser.RoleID != customerRole.RoleId)
                    {
                        throw new ValidationException("SĐT đã được sử dụng cho 1 vai trò khác");
                    }

                    // Reactivate soft-deleted user
                    existingUser.IsDelete = false;
                    existingUser.Name = request.Name;
                    existingUser.PhoneNumber = normalizedPhoneNumber;
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
                        Password = hashedPassword,
                        Name = request.Name,
                        PhoneNumber = normalizedPhoneNumber,
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
                throw new Exception("Đăng ký gặp trục trặc", ex);
            }
        }

        private string NormalizePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return phoneNumber;

            // Trim any whitespace
            phoneNumber = phoneNumber.Trim();

            // Remove the "+84" prefix (with or without space)
            if (phoneNumber.StartsWith("+84"))
            {
                // Check if there's a space after +84
                if (phoneNumber.Length > 3 && phoneNumber[3] == ' ')
                    phoneNumber = phoneNumber.Substring(4);
                else
                    phoneNumber = phoneNumber.Substring(3);
            }
            // Remove the "0" prefix
            else if (phoneNumber.StartsWith("0"))
            {
                phoneNumber = phoneNumber.Substring(1);
            }

            // Remove any remaining spaces or non-digit characters
            phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            return phoneNumber;
        }



        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var user = await _unitOfWork.Repository<User>()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && !u.IsDelete);

            if (user == null || user.RefreshTokenExpiry <= DateTime.UtcNow)
                throw new UnauthorizedException("Token bị lỗi");

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
                throw new Exception($"lỗi tạo entry", ex);
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
                        throw new ValidationException("Role Khách hàng không tìm thấy");

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
                throw new UnauthorizedException("Đăng nhập Google gặp trục trặc: " + ex.Message);
            }
        }
    }
}
