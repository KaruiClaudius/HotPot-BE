using Capstone.HPTY.API.BackgroundServices;
using Capstone.HPTY.ModelLayer;
using Capstone.HPTY.RepositoryLayer;
using Capstone.HPTY.RepositoryLayer.Repositories;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Capstone.HPTY.ServiceLayer.Interfaces.UtensilService;
using Capstone.HPTY.ServiceLayer.Services.ChatService;
using Capstone.HPTY.ServiceLayer.Services.ComboService;
using Capstone.HPTY.ServiceLayer.Services.FeedbackService;
using Capstone.HPTY.ServiceLayer.Services.HotpotService;
using Capstone.HPTY.ServiceLayer.Services.IngredientService;
using Capstone.HPTY.ServiceLayer.Services.ManagerService;
using Capstone.HPTY.ServiceLayer.Services.OrderService;
using Capstone.HPTY.ServiceLayer.Services.ReplacementService;
using Capstone.HPTY.ServiceLayer.Services.ScheduleService;
using Capstone.HPTY.ServiceLayer.Services.ShippingService;
using Capstone.HPTY.ServiceLayer.Services.StaffService;
using Capstone.HPTY.ServiceLayer.Services.UserService;
using Capstone.HPTY.ServiceLayer.Services.UtensilService;
using Microsoft.EntityFrameworkCore;
using Net.payOS;
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
                //var connectionString = configuration.GetConnectionString("Server");
                var connectionString = configuration.GetConnectionString("Local");
                options.UseSqlServer(connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure());
            });

            PayOS payOS = new PayOS(configuration["Environment:PAYOS_CLIENT_ID"] ?? throw new Exception("Cannot find environment"),
                    configuration["Environment:PAYOS_API_KEY"] ?? throw new Exception("Cannot find environment"),
                    configuration["Environment:PAYOS_CHECKSUM_KEY"] ?? throw new Exception("Cannot find environment"));

            services.AddSingleton(payOS);

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
            services.AddScoped<IHotPotInventoryService, HotPotInventoryService>();
            services.AddScoped<IHotpotService, HotpotService>();
            services.AddScoped<IHotpotTypeService, HotpotTypeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IIngredientTypeService, IngredientTypeService>();
            services.AddScoped<IComboService, ComboService>();
            services.AddScoped<ICustomizationService, CustomizationService>();
            services.AddScoped<ISizeDiscountService, SizeDiscountService>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<ITurtorialVideoService, TurtorialVideoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUtensilService, UtensilService>();
            services.AddScoped<IUtensilTypeService, UtensilTypeService>();
            services.AddScoped<IWorkShiftService, WorkShiftService>();
            services.AddScoped<IPaymentService, PaymentService>();

            // Manager Services
            services.AddScoped<IOrderManagementService, OrderManagementService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IEquipmentConditionService, EquipmentConditionService>();
            services.AddScoped<IEquipmentStockService, EquipmentStockService>();
            services.AddScoped<IReplacementRequestService, ReplacementRequestService>();

            // Notification Services
            services.AddScoped<INotificationService, SignalRNotificationService>();

            // Background Services
            services.AddHostedService<EquipmentStockMonitorService>();

            // Shipping Services
            services.AddScoped<IStaffShippingService, StaffShippingService>();

            // Equipment Services
            services.AddScoped<IStaffEquipmentService, StaffEquipmentService>();

            // Oder History Services
            services.AddScoped<ICustomerOrderHistoryService, CustomerOrderHistoryService>();
            services.AddScoped<IOrderHistoryService, OrderHistoryService>();

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
