using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services
{
    public class DatabaseInitializer: IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DatabaseInitializer> _logger;

        public DatabaseInitializer(
            IServiceProvider serviceProvider,
            ILogger<DatabaseInitializer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<HPTYContext>();

            try
            {
                _logger.LogInformation("Ensuring database is created and migrated...");

                // Use migrations (preferred for production)
                await dbContext.Database.MigrateAsync(cancellationToken);

                // Use EnsureCreated for development/testing
                //await dbContext.Database.EnsureCreatedAsync(cancellationToken);


                // Optional: Check if seeding is needed
                if (!await dbContext.Roles.AnyAsync(cancellationToken))
                {
                    _logger.LogInformation("Database appears empty. Seed data will be applied through migrations.");
                }

                _logger.LogInformation("Database initialization completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}

