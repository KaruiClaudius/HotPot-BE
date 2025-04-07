using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Capstone.HPTY.API.AppStarts
{
    public static class AuthConfig
    {
        public static void ConfigureAuthService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            // Try to get token from Authorization header first
                            var authHeader = context.Request.Headers.Authorization.ToString();
                            if (!string.IsNullOrEmpty(authHeader))
                            {
                                context.Token = authHeader.Replace("Bearer ", "").Trim();
                            }

                            // If no token found and this is a SignalR request, check query string
                            if (string.IsNullOrEmpty(context.Token))
                            {
                                var accessToken = context.Request.Query["access_token"];

                                // If the request is for our hub...
                                var path = context.HttpContext.Request.Path;
                                if (!string.IsNullOrEmpty(accessToken) &&
                                    (path.StartsWithSegments("/chatHub") || path.StartsWithSegments("/notificationHub")
                                    || path.StartsWithSegments("/equipmentConditionHub") || path.StartsWithSegments("/equipmentHub") || path.StartsWithSegments("/equipmentStockHub")
                                    || path.StartsWithSegments("/scheduleHub") || path.StartsWithSegments("/feedbackHub")
                                    ))
                                {
                                    // Read the token out of the query string
                                    context.Token = accessToken;
                                }
                            }

                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            // Add role claim if it doesn't exist in the correct format
                            var identity = context.Principal.Identity as ClaimsIdentity;
                            var roleClaim = identity?.FindFirst("role");
                            if (roleClaim != null)
                            {
                                // Add the role claim in the format that [Authorize] expects
                                if (!identity.HasClaim(ClaimTypes.Role, roleClaim.Value))
                                {
                                    identity.AddClaim(new Claim(ClaimTypes.Role, roleClaim.Value));
                                }
                            }

                            return Task.CompletedTask;
                        }
                    };
                });


            // Only add Google authentication if configuration exists
            var googleClientId = configuration["Authentication:Google:ClientId"];
            var googleClientSecret = configuration["Authentication:Google:ClientSecret"];

            if (!string.IsNullOrEmpty(googleClientId) && !string.IsNullOrEmpty(googleClientSecret))
            {
                services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.ClientId = googleClientId;
                        options.ClientSecret = googleClientSecret;
                        options.CallbackPath = "/signin-google";
                    });
            }

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy =>
                    policy.RequireRole("Admin"));
            });
        }
    }
}