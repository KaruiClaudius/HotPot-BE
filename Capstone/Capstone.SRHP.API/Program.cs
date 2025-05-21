using System.Reflection;
using Capstone.HPTY.API.AppStarts;
using Capstone.HPTY.ServiceLayer.Services.ChatService;
using Capstone.HPTY.ServiceLayer.Services.MailService;
using Mapster;
using Microsoft.AspNetCore.Http.Features;
using System.Runtime.CompilerServices;
using Capstone.HPTY.API.Hubs;
[assembly: InternalsVisibleTo("Capstone.HPTY.Test")]


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
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
})
.AddJsonProtocol(options =>
{
    options.PayloadSerializerOptions.PropertyNamingPolicy = null;
});

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
                "https://hotpot-web-app-production.up.railway.app"   // Your production domain
            )
    );
});

// Build the app
var app = builder.Build();

// Get logger from service provider
var logger = app.Services.GetRequiredService<ILogger<Program>>();

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

// Simplified socket health check that doesn't rely on methods that don't exist
app.MapGet("/api/socket-health", (HttpContext context) =>
{
    var socketService = context.RequestServices.GetRequiredService<SocketIOClientService>();
    var config = context.RequestServices.GetRequiredService<IConfiguration>();

    return Results.Ok(new
    {
        ServerUrl = config["SocketIO:ServerUrl"] ?? "https://chat-server-production-9950.up.railway.app/",
        Timestamp = DateTime.UtcNow.AddHours(7),
        TimeZone = "UTC+7"
    });
});

app.Run();