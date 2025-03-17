using System.Reflection;
using Capstone.HPTY.API.AppStarts;
using Capstone.HPTY.API.Hubs;
using Mapster;
using Microsoft.AspNetCore.Http.Features;

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
builder.Services.AddSignalR();

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


var app = builder.Build();

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
app.MapHub<EquipmentHub>("/equipmentHub");
app.MapHub<FeedbackHub>("/feedbackHub");
app.MapHub<ScheduleHub>("/scheduleHub");
app.MapHub<EquipmentConditionHub>("/equipmentConditionHub");
app.MapHub<EquipmentStockHub>("/equipmentStockHub");
app.MapHub<NotificationHub>("/notificationHub");

app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow.AddHours(7) }));

app.Run();
