using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.RepositoryLayer.Utils;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Capstone.HPTY.ServiceLayer.Services.MailService;
using Google.Apis.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly EmailService _emailService;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUnitOfWork unitOfWork, IJwtService jwtService, ILogger<AuthService> logger, EmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _logger = logger;
            _emailService = emailService;
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
            return await _unitOfWork.ExecuteInTransactionAsync<AuthResponse>(async () =>
            {
                string normalizedPhoneNumber = NormalizePhoneNumber(request.PhoneNumber);

                // Check if user exists (including soft-deleted)
                var existingUser = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.PhoneNumber == normalizedPhoneNumber);

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
                    throw new ValidationException("Role Customer không tìm thấy");

                User resultUser;

                if (existingUser != null)
                {
                    // Only reactivate if the existing user was a Customer
                    if (existingUser.RoleId != customerRole.RoleId)
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
                        RoleId = customerRole.RoleId, // Always set to Customer role
                        LoyatyPoint = 0, // Initialize loyalty points for new customers
                        CreatedAt = DateTime.UtcNow.AddHours(7),
                        UpdatedAt = DateTime.UtcNow.AddHours(7)
                    };

                    _unitOfWork.Repository<User>().Insert(newUser);
                    await _unitOfWork.CommitAsync();

                    resultUser = newUser;
                }

                // Commit the transaction

                return await GenerateAuthResponseAsync(resultUser);
            },
        ex =>
        {
            // Only log for exceptions that aren't validation or not found
            if (!(ex is NotFoundException || ex is ValidationException))
            {
                _logger.LogError(ex, "Đăng ký gặp trục trặc", ex);
            }
        });
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

            if (user == null || user.RefreshTokenExpiry <= DateTime.UtcNow.AddHours(7))
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

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = expiresAt
            };
        }

        public async Task<AuthResponse> GoogleLoginAsync(string idToken)
        {
            return await _unitOfWork.ExecuteInTransactionAsync<AuthResponse>(async () =>
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

                        user = existingUser;
                    }
                    else
                    {
                        // Get Customer role
                        var customerRole = await _unitOfWork.Repository<Role>()
                            .FindAsync(r => r.Name == "Customer");

                        if (customerRole == null)
                            throw new ValidationException("Role Customer không tìm thấy");

                        // Generate a random password
                        string randomPassword = GenerateRandomPassword();

                        // Create new user
                        user = new User
                        {
                            Email = payload.Email,
                            Name = payload.Name,
                            // Store the hashed password
                            Password = BCrypt.Net.BCrypt.HashPassword(randomPassword),
                            RoleId = customerRole.RoleId,
                            LoyatyPoint = 0, // Initialize loyalty points for new customers
                            CreatedAt = DateTime.UtcNow.AddHours(7),
                            UpdatedAt = DateTime.UtcNow.AddHours(7)
                        };

                        _unitOfWork.Repository<User>().Insert(user);
                        await _unitOfWork.CommitAsync();

                        // Send the password email
                        await _emailService.SendPasswordEmailAsync(user.Email, user.Name, randomPassword);
                    }
                }

                // Generate JWT token and return auth response
                return await GenerateAuthResponseAsync(user);
            },
            ex =>
            {
                // Only log for exceptions that aren't validation or not found
                if (!(ex is NotFoundException || ex is ValidationException))
                {
                    _logger.LogError(ex, "Đăng nhập Google gặp trục trặc: " + ex.Message);
                }
            });
        }

        private string GenerateRandomPassword()
        {
            // Generate a secure random password with at least one uppercase, one lowercase, one digit, and one special character
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string digitChars = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";
            const string allChars = uppercaseChars + lowercaseChars + digitChars + specialChars;

            var random = new Random();
            var password = new char[12]; // 12 characters long

            // Ensure at least one of each type
            password[0] = uppercaseChars[random.Next(uppercaseChars.Length)];
            password[1] = lowercaseChars[random.Next(lowercaseChars.Length)];
            password[2] = digitChars[random.Next(digitChars.Length)];
            password[3] = specialChars[random.Next(specialChars.Length)];

            // Fill the rest with random characters
            for (int i = 4; i < password.Length; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Shuffle the password characters
            for (int i = 0; i < password.Length; i++)
            {
                int swapIndex = random.Next(password.Length);
                char temp = password[i];
                password[i] = password[swapIndex];
                password[swapIndex] = temp;
            }

            return new string(password);
        }
    }
}
