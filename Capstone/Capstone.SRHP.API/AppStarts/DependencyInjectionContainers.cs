using Capstone.HPTY.ModelLayer;
using Capstone.HPTY.RepositoryLayer;
using Capstone.HPTY.RepositoryLayer.Repositories;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Services;
using Capstone.HPTY.ServiceLayer.Services.Chat;
using Capstone.HPTY.ServiceLayer.Services.ManagerService;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

namespace Capstone.HPTY.API.AppStarts
{
    public static class DependencyInjectionContainers
    {
        public static void InstallService(this IServiceCollection services, IConfiguration configuration)
        {
            // Routing
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            // Database
            services.AddDbContext<HPTYContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure());
            });

            // Core Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Auth Services
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();

            // Business Services
            services.AddScoped<IComboService, ComboService>();
            services.AddScoped<IConditionLogService, ConditionLogService>();
            services.AddScoped<ICustomizationService, CustomizationService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IHotPotInventoryService, HotPotInventoryService>();
            services.AddScoped<IHotpotService, HotpotService>();
            services.AddScoped<IHotpotTypeService, HotpotTypeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IIngredientTypeService, IngredientTypeService>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<ITurtorialVideoService, TurtorialVideoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUtensilService, UtensilService>();
            services.AddScoped<IUtensilTypeService, UtensilTypeService>();
            services.AddScoped<IWorkShiftService, WorkShiftService>();

            // Manager Services
            services.AddScoped<IOrderManagementService, OrderManagementService>();
            services.AddScoped<IChatService, ChatService>();    

            // External Services
            services.AddHttpClient();
            services.AddMemoryCache();

            //// AutoMapper
            //services.AddAutoMapper(typeof(MappingProfile));

            //// Validators
            //services.AddValidatorsFromAssemblyContaining<Program>();


        }
    }
}
