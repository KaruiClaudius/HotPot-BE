using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/reports/ingredients")]
    [Authorize(Roles = "Admin")]
    public class AdminIngredientReportController : ControllerBase
    {
        private readonly IIngredientReportService _reportService;
        private readonly ILogger<AdminIngredientReportController> _logger;

        public AdminIngredientReportController(
            IIngredientReportService reportService,
            ILogger<AdminIngredientReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        [HttpGet("usage")]
        public async Task<ActionResult<Response>> GetIngredientUsageReport(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int? ingredientId = null)
        {
            try
            {
                // Default to last 30 days if dates not provided
                var start = startDate ?? DateTime.UtcNow.AddDays(-30);
                var end = endDate ?? DateTime.UtcNow;

                var report = await _reportService.GetIngredientUsageReportAsync(start, end, ingredientId);

                return new Response(0, "Ingredient usage report retrieved successfully", report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient usage report");
                return new Response(-1, "Error retrieving ingredient usage report", null);
            }
        }

        [HttpGet("batches/{ingredientId}")]
        public async Task<ActionResult<Response>> GetBatchUsageReport(
            int ingredientId,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            try
            {
                // Default to last 30 days if dates not provided
                var start = startDate ?? DateTime.UtcNow.AddDays(-30);
                var end = endDate ?? DateTime.UtcNow;

                var report = await _reportService.GetBatchUsageReportAsync(ingredientId, start, end);

                return new Response(0, "Batch usage report retrieved successfully", report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving batch usage report for ingredient {IngredientId}", ingredientId);
                return new Response(-1, "Error retrieving batch usage report", null);
            }
        }

        [HttpGet("orders/{orderId}")]
        public async Task<ActionResult<Response>> GetOrderIngredientUsage(int orderId)
        {
            try
            {
                var report = await _reportService.GetOrderIngredientUsageAsync(orderId);

                return new Response(0, "Order ingredient usage retrieved successfully", report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient usage for order {OrderId}", orderId);
                return new Response(-1, "Error retrieving order ingredient usage", null);
            }
        }

        [HttpGet("combos")]
        public async Task<ActionResult<Response>> GetIngredientUsageByCombo(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int? comboId = null)
        {
            try
            {
                // Default to last 30 days if dates not provided
                var start = startDate ?? DateTime.UtcNow.AddDays(-30);
                var end = endDate ?? DateTime.UtcNow;

                var report = await _reportService.GetIngredientUsageByComboAsync(start, end, comboId);

                return new Response(0, "Ingredient usage by combo retrieved successfully", report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient usage by combo");
                return new Response(-1, "Error retrieving ingredient usage by combo", null);
            }
        }

        [HttpGet("customizations")]
        public async Task<ActionResult<Response>> GetIngredientUsageByCustomization(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int? customizationId = null)
        {
            try
            {
                // Default to last 30 days if dates not provided
                var start = startDate ?? DateTime.UtcNow.AddDays(-30);
                var end = endDate ?? DateTime.UtcNow;

                var report = await _reportService.GetIngredientUsageByCustomizationAsync(start, end, customizationId);

                return new Response(0, "Ingredient usage by customization retrieved successfully", report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient usage by customization");
                return new Response(-1, "Error retrieving ingredient usage by customization", null);
            }
        }

        [HttpGet("daily")]
        public async Task<ActionResult<Response>> GetDailyIngredientUsage(
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int? ingredientId = null)
        {
            try
            {
                // Default to last 7 days if dates not provided
                var start = startDate ?? DateTime.UtcNow.AddDays(-7);
                var end = endDate ?? DateTime.UtcNow;

                var report = await _reportService.GetDailyIngredientUsageAsync(start, end, ingredientId);

                return new Response(0, "Daily ingredient usage retrieved successfully", report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving daily ingredient usage");
                return new Response(-1, "Error retrieving daily ingredient usage", null);
            }
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<Response>> GetIngredientDashboard()
        {
            try
            {
                // Get today's date
                var today = DateTime.UtcNow.Date;
                var yesterday = today.AddDays(-1);
                var lastWeekStart = today.AddDays(-7);
                var lastMonthStart = today.AddDays(-30);

                // Get various reports for the dashboard
                var todayUsage = await _reportService.GetDailyIngredientUsageAsync(today, today);
                var yesterdayUsage = await _reportService.GetDailyIngredientUsageAsync(yesterday, yesterday);
                var weeklyUsage = await _reportService.GetIngredientUsageReportAsync(lastWeekStart, today);
                var monthlyUsage = await _reportService.GetIngredientUsageReportAsync(lastMonthStart, today);
                var topCombos = await _reportService.GetIngredientUsageByComboAsync(lastMonthStart, today);

                // Create dashboard summary
                var dashboard = new
                {
                    TodayStats = new
                    {
                        Date = today,
                        TotalOrderCount = todayUsage.Sum(r => r.TotalOrderCount),
                        TotalIngredientCost = todayUsage.Sum(r => r.TotalCost),
                        TopIngredients = todayUsage
                            .SelectMany(r => r.Ingredients)
                            .GroupBy(i => i.IngredientId)
                            .Select(g => new
                            {
                                IngredientId = g.Key,
                                IngredientName = g.First().IngredientName,
                                TotalQuantityUsed = g.Sum(i => i.QuantityUsed),
                                TotalCost = g.Sum(i => i.TotalCost)
                            })
                            .OrderByDescending(i => i.TotalQuantityUsed)
                            .Take(5)
                            .ToList()
                    },
                    YesterdayStats = new
                    {
                        Date = yesterday,
                        TotalOrderCount = yesterdayUsage.Sum(r => r.TotalOrderCount),
                        TotalIngredientCost = yesterdayUsage.Sum(r => r.TotalCost),
                    },
                    WeeklyStats = new
                    {
                        StartDate = lastWeekStart,
                        EndDate = today,
                        TotalIngredientCost = weeklyUsage.Sum(r => r.TotalCost),
                        TopIngredients = weeklyUsage
                            .OrderByDescending(r => r.TotalQuantityUsed)
                            .Take(5)
                            .ToList()
                    },
                    MonthlyStats = new
                    {
                        StartDate = lastMonthStart,
                        EndDate = today,
                        TotalIngredientCost = monthlyUsage.Sum(r => r.TotalCost),
                        TopIngredients = monthlyUsage
                            .OrderByDescending(r => r.TotalQuantityUsed)
                            .Take(10)
                            .ToList()
                    },
                    TopCombos = topCombos
                        .OrderByDescending(c => c.TotalQuantitySold)
                        .Take(5)
                        .ToList()
                };

                return new Response(0, "Ingredient dashboard retrieved successfully", dashboard);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient dashboard");
                return new Response(-1, "Error retrieving ingredient dashboard", null);
            }
        }
    }
}
