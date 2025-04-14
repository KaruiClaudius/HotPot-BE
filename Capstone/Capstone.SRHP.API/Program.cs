using System.Reflection;
using Capstone.HPTY.API.AppStarts;
using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ServiceLayer.Services.ChatService;
using Capstone.HPTY.ServiceLayer.Services.MailService;
using Mapster;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var root = Directory.GetCurrentDirectory();
var dotenvPath = Path.Combine(root, ".env");
DotEnv.Load(dotenvPath);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100 MB file limit
});

builder.Services.InstallService(builder.Configuration);

// Configure Authentication
builder.Services.ConfigureAuthService(builder.Configuration);

// Add SignalR
builder.Services.AddSignalR(options => {
    options.EnableDetailedErrors = true;
})
.AddJsonProtocol(options => {
    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
});

// Add logging
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();
//builder.Logging.SetMinimumLevel(LogLevel.Debug);
//builder.Logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
//builder.Logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);

// Add Email
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Add Mapster
TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

// Configure Swagger
builder.Services.ConfigureSwaggerServices("HPTY API");

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins(
                "http://localhost:5000",  // Your local frontend
                "http://localhost:3000",   // React default port
                "https://yourdomain.com"   // Your production domain
            )
    );
});

// Build the app
var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    try
    {
        using var scope = app.Services.CreateScope();
        var socketService = scope.ServiceProvider.GetRequiredService<SocketIOClientService>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogInformation($"Attempting to connect to Socket.IO server at {socketService.GetServerUrl()}");
        var connected = await socketService.ConnectAsync();

        if (connected)
        {
            logger.LogInformation("Successfully connected to Socket.IO server at startup");
        }
        else
        {
            logger.LogWarning("Could not connect to Socket.IO server at startup. Chat functionality may be limited.");
        }
    }
    catch (Exception ex)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Failed to connect to Socket.IO server at startup");
    }
});

// Get logger from service provider
var logger = app.Services.GetRequiredService<ILogger<Program>>();

// Connect to Socket.IO server at startup
try
{
    var socketService = app.Services.GetRequiredService<SocketIOClientService>();
    await socketService.ConnectAsync();
    logger.LogInformation("Successfully connected to Socket.IO server at startup");
}
catch (Exception ex)
{
    logger.LogError(ex, "Failed to connect to Socket.IO server at startup");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HPTY API v1");
        c.RoutePrefix = string.Empty; // Swagger at root URL
    });
}
else
{
    // Production swagger with basic auth (optional)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HPTY API v1");
        c.RoutePrefix = string.Empty;
        c.EnablePersistAuthorization();
    });

    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");
app.MapHub<NotificationHub>("/notificationHub");

app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow.AddHours(7) }));
app.MapGet("/api/socket-health", (HttpContext context) =>
{
    var socketService = context.RequestServices.GetRequiredService<SocketIOClientService>();
    return Results.Ok(new
    {
        IsConnected = socketService._isConnected,
        ServerUrl = socketService.GetServerUrl(),
        Timestamp = DateTime.UtcNow
    });
});
app.Run();