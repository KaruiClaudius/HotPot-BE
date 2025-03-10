using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics;
using System.Reflection;

namespace Capstone.HPTY.API.AppStarts
{

    public static class SwaggerConfig
    {
        public static void ConfigureSwaggerServices(this IServiceCollection services, string appName)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appName,
                    Version = "v1",
                    Description = "HPTY API Documentation",
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name",
                        Email = "your.email@example.com"
                    }
                });
                c.CustomSchemaIds(type => type.FullName);

                // Add operation filter to assign operations to groups
                c.OperationFilter<SwaggerGroupOperationFilter>();

                // Add document filter to order the tags
                c.DocumentFilter<SwaggerGroupTagsFilter>();

                // Order actions within each tag
                c.OrderActionsBy(apiDesc => apiDesc.RelativePath);

                // JWT Authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });

                // Enum descriptions
                c.SchemaFilter<EnumSchemaFilter>();
            });
        }
    }
}
