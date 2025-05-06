using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.IngredientReport;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.ComboService
{
    public class IngredientReportService : IIngredientReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IngredientReportService> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientReportService(
            IUnitOfWork unitOfWork,
            IIngredientService ingredientService,
            ILogger<IngredientReportService> logger)
        {
            _unitOfWork = unitOfWork;
            _ingredientService = ingredientService;
            _logger = logger;
        }

        public async Task<IEnumerable<IngredientUsageReport>> GetIngredientUsageReportAsync(
            DateTime startDate,
            DateTime endDate,
            int? ingredientId = null)
        {
            var query = _unitOfWork.Repository<IngredientUsage>()
                .IncludeNested(q => q
                    .Include(u => u.Ingredient)
                    .Include(u => u.IngredientBatch))
                .Where(u => u.UsageDate >= startDate && u.UsageDate <= endDate && !u.IsDelete);

            if (ingredientId.HasValue)
            {
                query = query.Where(u => u.IngredientId == ingredientId.Value);
            }

            var usages = await query.ToListAsync();

            return usages
                .GroupBy(u => new { u.IngredientId, IngredientName = u.Ingredient.Name })
                .Select(g => new IngredientUsageReport
                {
                    IngredientId = g.Key.IngredientId,
                    IngredientName = g.Key.IngredientName,
                    TotalQuantityUsed = g.Sum(u => u.QuantityUsed),
                    UsageCount = g.Count(),
                    OrderCount = g.Select(u => u.OrderId).Distinct().Count()
                })
                .OrderByDescending(r => r.TotalQuantityUsed)
                .ToList();
        }


        public async Task<IEnumerable<BatchUsageReport>> GetBatchUsageReportAsync(
                int ingredientId,
                DateTime startDate,
                DateTime endDate)
        {
            try
            {
                // Get all usage records for this ingredient in the date range
                var usages = await _unitOfWork.Repository<IngredientUsage>()
                    .IncludeNested(q => q.Include(u => u.IngredientBatch))
                    .Where(u => u.IngredientId == ingredientId &&
                               u.UsageDate >= startDate &&
                               u.UsageDate <= endDate &&
                               !u.IsDelete)
                    .ToListAsync();

                // Get all batches for this ingredient, including those with no usage
                var batches = await _unitOfWork.Repository<IngredientBatch>()
                    .FindAll(b => b.IngredientId == ingredientId && !b.IsDelete)
                    .ToListAsync();

                // Get the ingredient for cost information
                decimal costPerUnit = 0;
                try
                {
                    costPerUnit = await _ingredientService.GetCurrentPriceAsync(ingredientId);
                }
                catch
                {
                    // If price not found, use 0
                }

                // Group usages by batch
                var batchUsages = usages
                    .GroupBy(u => u.IngredientBatchId)
                    .ToDictionary(
                        g => g.Key,
                        g => new
                        {
                            TotalUsed = g.Sum(u => u.QuantityUsed),
                            OrderCount = g.Select(u => u.OrderId).Distinct().Count()
                        });

                // Create reports for each batch
                return batches.Select(batch =>
                {
                    // Get usage for this batch if any
                    batchUsages.TryGetValue(batch.IngredientBatchId, out var usage);

                    decimal totalUsed = usage?.TotalUsed ?? 0;
                    int orderCount = usage?.OrderCount ?? 0;

                    return new BatchUsageReport
                    {
                        IngredientBatchId = batch.IngredientBatchId,
                        BatchNumber = batch.BatchNumber,
                        BestBeforeDate = batch.BestBeforeDate, 
                        InitialQuantity = batch.InitialQuantity,
                        TotalQuantityUsed = totalUsed,
                        RemainingQuantity = batch.RemainingQuantity,
                        OrderCount = orderCount,
                        UsagePercentage = batch.InitialQuantity > 0
                            ? (totalUsed / batch.InitialQuantity) * 100
                            : 0,
                        CostPerUnit = costPerUnit,
                        TotalCost = costPerUnit * totalUsed
                    };
                })
                .OrderByDescending(r => r.TotalQuantityUsed)
                .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating batch usage report for ingredient {IngredientId}", ingredientId);
                throw;
            }
        }

        public async Task<IEnumerable<OrderIngredientUsageReport>> GetOrderIngredientUsageAsync(int orderId)
        {
            try
            {
                var usages = await _unitOfWork.Repository<IngredientUsage>()
                    .IncludeNested(q => q
                        .Include(u => u.Ingredient)
                        .Include(u => u.IngredientBatch)
                        .Include(u => u.Combo)
                        .Include(u => u.Customization))
                    .Where(u => u.OrderId == orderId && !u.IsDelete)
                    .ToListAsync();

                // Get all ingredients used in this order
                var ingredientIds = usages.Select(u => u.IngredientId).Distinct().ToList();

                // Get ingredient prices
                var ingredientPrices = new Dictionary<int, decimal>();
                foreach (var ingredientId in ingredientIds)
                {
                    try
                    {
                        var price = await _ingredientService.GetCurrentPriceAsync(ingredientId);
                        ingredientPrices[ingredientId] = price;
                    }
                    catch
                    {
                        // If price not found, use 0
                        ingredientPrices[ingredientId] = 0;
                    }
                }

                return usages.Select(u =>
                {
                    // Get cost per unit if available
                    ingredientPrices.TryGetValue(u.IngredientId, out var costPerUnit);

                    return new OrderIngredientUsageReport
                    {
                        IngredientId = u.IngredientId,
                        IngredientName = u.Ingredient?.Name ?? "Unknown",
                        IngredientBatchId = u.IngredientBatchId,
                        BatchNumber = u.IngredientBatch?.BatchNumber ?? "Unknown",
                        QuantityUsed = u.QuantityUsed,
                        ComboId = u.ComboId,
                        ComboName = u.Combo?.Name ?? "N/A",
                        CustomizationId = u.CustomizationId,
                        CustomizationName = u.Customization?.Name ?? "N/A",
                        CostPerUnit = costPerUnit,
                        TotalCost = costPerUnit * u.QuantityUsed
                    };
                })
                .OrderBy(r => r.IngredientName)
                .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating ingredient usage report for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<IEnumerable<IngredientUsageByComboReport>> GetIngredientUsageByComboAsync(
            DateTime startDate,
            DateTime endDate,
            int? comboId = null)
        {
            try
            {
                // Get all usage records for combos in the date range
                var query = _unitOfWork.Repository<IngredientUsage>()
                    .IncludeNested(q => q
                        .Include(u => u.Ingredient)
                        .Include(u => u.Combo))
                    .Where(u => u.UsageDate >= startDate &&
                               u.UsageDate <= endDate &&
                               u.ComboId.HasValue &&
                               !u.IsDelete);

                if (comboId.HasValue)
                {
                    query = query.Where(u => u.ComboId == comboId.Value);
                }

                var usages = await query.ToListAsync();

                // Get all combos used in this period
                var comboIds = usages.Select(u => u.ComboId.Value).Distinct().ToList();

                // Get all ingredients used in this period
                var ingredientIds = usages.Select(u => u.IngredientId).Distinct().ToList();

                // Get ingredient prices
                var ingredientPrices = new Dictionary<int, decimal>();
                foreach (var ingredientId in ingredientIds)
                {
                    try
                    {
                        var price = await _ingredientService.GetCurrentPriceAsync(ingredientId);
                        ingredientPrices[ingredientId] = price;
                    }
                    catch (NotFoundException)
                    {
                        // If price not found, use 0
                        ingredientPrices[ingredientId] = 0;
                    }
                }

                // Group by combo
                var result = new List<IngredientUsageByComboReport>();

                foreach (var comboGroup in usages.GroupBy(u => u.ComboId.Value))
                {
                    var currentComboId = comboGroup.Key;
                    var comboName = comboGroup.First().Combo?.Name ?? "Unknown Combo";

                    // Get order count and total quantity sold
                    var orderIds = comboGroup.Select(u => u.OrderId).Distinct().ToList();
                    var orderCount = orderIds.Count;

                    // Get total quantity sold by checking order details
                    var totalQuantitySold = await _unitOfWork.Repository<SellOrderDetail>()
                        .CountAsync(d => d.ComboId == currentComboId &&
                                       orderIds.Contains(d.OrderId) &&
                                       !d.IsDelete);

                    // Group ingredients within this combo
                    var ingredientUsages = new List<ComboIngredientUsage>();

                    foreach (var ingredientGroup in comboGroup.GroupBy(u => u.IngredientId))
                    {
                        var ingredientId = ingredientGroup.Key;
                        var ingredientName = ingredientGroup.First().Ingredient?.Name ?? "Unknown Ingredient";
                        var totalQuantityUsed = ingredientGroup.Sum(u => u.QuantityUsed);

                        // Get cost per unit
                        ingredientPrices.TryGetValue(ingredientId, out var costPerUnit);

                        ingredientUsages.Add(new ComboIngredientUsage
                        {
                            IngredientId = ingredientId,
                            IngredientName = ingredientName,
                            TotalQuantityUsed = totalQuantityUsed,
                            QuantityPerCombo = totalQuantitySold > 0 ? totalQuantityUsed / totalQuantitySold : 0,
                            CostPerUnit = costPerUnit,
                            TotalCost = costPerUnit * totalQuantityUsed
                        });
                    }

                    // Calculate totals
                    var totalIngredientCost = ingredientUsages.Sum(i => i.TotalCost);

                    result.Add(new IngredientUsageByComboReport
                    {
                        ComboId = currentComboId,
                        ComboName = comboName,
                        OrderCount = orderCount,
                        TotalQuantitySold = totalQuantitySold,
                        Ingredients = ingredientUsages,
                        TotalIngredientCost = totalIngredientCost,
                        AverageIngredientCostPerOrder = orderCount > 0 ? totalIngredientCost / orderCount : 0
                    });
                }

                return result.OrderByDescending(r => r.TotalQuantitySold);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating ingredient usage by combo report");
                throw;
            }
        }

        

        public async Task<IEnumerable<IngredientUsageByCustomizationReport>> GetIngredientUsageByCustomizationAsync(
            DateTime startDate,
            DateTime endDate,
            int? customizationId = null)
        {
            try
            {
                // Get all usage records for customizations in the date range
                var query = _unitOfWork.Repository<IngredientUsage>()
                    .IncludeNested(q => q
                        .Include(u => u.Ingredient)
                        .Include(u => u.Customization))
                    .Where(u => u.UsageDate >= startDate &&
                               u.UsageDate <= endDate &&
                               u.CustomizationId.HasValue &&
                               !u.IsDelete);

                if (customizationId.HasValue)
                {
                    query = query.Where(u => u.CustomizationId == customizationId.Value);
                }

                var usages = await query.ToListAsync();

                // Get all customizations used in this period
                var customizationIds = usages.Select(u => u.CustomizationId.Value).Distinct().ToList();

                // Get all ingredients used in this period
                var ingredientIds = usages.Select(u => u.IngredientId).Distinct().ToList();

                // Get ingredient prices
                var ingredientPrices = new Dictionary<int, decimal>();
                foreach (var ingredientId in ingredientIds)
                {
                    try
                    {
                        var price = await _ingredientService.GetCurrentPriceAsync(ingredientId);
                        ingredientPrices[ingredientId] = price;
                    }
                    catch (NotFoundException)
                    {
                        // If price not found, use 0
                        ingredientPrices[ingredientId] = 0;
                    }
                }

                // Group by customization
                var result = new List<IngredientUsageByCustomizationReport>();

                foreach (var customizationGroup in usages.GroupBy(u => u.CustomizationId.Value))
                {
                    var currentCustomizationId = customizationGroup.Key;
                    var customizationName = customizationGroup.First().Customization?.Name ?? "Unknown Customization";

                    // Get order count and total quantity sold
                    var orderIds = customizationGroup.Select(u => u.OrderId).Distinct().ToList();
                    var orderCount = orderIds.Count;

                    // Get total quantity sold by checking order details
                    var totalQuantitySold = await _unitOfWork.Repository<SellOrderDetail>()
                        .CountAsync(d => d.CustomizationId == currentCustomizationId &&
                                       orderIds.Contains(d.OrderId) &&
                                       !d.IsDelete);

                    // Group ingredients within this customization
                    var ingredientUsages = new List<CustomizationIngredientUsage>();

                    foreach (var ingredientGroup in customizationGroup.GroupBy(u => u.IngredientId))
                    {
                        var ingredientId = ingredientGroup.Key;
                        var ingredientName = ingredientGroup.First().Ingredient?.Name ?? "Unknown Ingredient";
                        var totalQuantityUsed = ingredientGroup.Sum(u => u.QuantityUsed);

                        // Get cost per unit
                        ingredientPrices.TryGetValue(ingredientId, out var costPerUnit);

                        ingredientUsages.Add(new CustomizationIngredientUsage
                        {
                            IngredientId = ingredientId,
                            IngredientName = ingredientName,
                            TotalQuantityUsed = totalQuantityUsed,
                            QuantityPerCustomization = totalQuantitySold > 0 ? totalQuantityUsed / totalQuantitySold : 0,
                            CostPerUnit = costPerUnit,
                            TotalCost = costPerUnit * totalQuantityUsed
                        });
                    }

                    // Calculate totals
                    var totalIngredientCost = ingredientUsages.Sum(i => i.TotalCost);

                    result.Add(new IngredientUsageByCustomizationReport
                    {
                        CustomizationId = currentCustomizationId,
                        CustomizationName = customizationName,
                        OrderCount = orderCount,
                        TotalQuantitySold = totalQuantitySold,
                        Ingredients = ingredientUsages,
                        TotalIngredientCost = totalIngredientCost,
                        AverageIngredientCostPerOrder = orderCount > 0 ? totalIngredientCost / orderCount : 0
                    });
                }

                return result.OrderByDescending(r => r.TotalQuantitySold);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating ingredient usage by customization report");
                throw;
            }
        }

        public async Task<IEnumerable<DailyIngredientUsageReport>> GetDailyIngredientUsageAsync(
     DateTime startDate,
     DateTime endDate,
     int? ingredientId = null)
        {
            try
            {
                // Ensure dates are at day boundaries
                startDate = startDate.Date;
                endDate = endDate.Date.AddDays(1).AddSeconds(-1);

                // Get all usage records in the date range
                var query = _unitOfWork.Repository<IngredientUsage>()
                    .IncludeNested(q => q.Include(u => u.Ingredient))
                    .Where(u => u.UsageDate >= startDate &&
                               u.UsageDate <= endDate &&
                               !u.IsDelete);

                if (ingredientId.HasValue)
                {
                    query = query.Where(u => u.IngredientId == ingredientId.Value);
                }

                var usages = await query.ToListAsync();

                // Get all ingredients used in this period
                var ingredientIds = usages.Select(u => u.IngredientId).Distinct().ToList();

                // Get ingredient prices
                var ingredientPrices = new Dictionary<int, decimal>();
                foreach (var currentIngredientId in ingredientIds)
                {
                    try
                    {
                        var price = await _ingredientService.GetCurrentPriceAsync(currentIngredientId);
                        ingredientPrices[currentIngredientId] = price;
                    }
                    catch (NotFoundException)
                    {
                        // If price not found, use 0
                        ingredientPrices[currentIngredientId] = 0;
                    }
                }

                // Group by date
                var result = new List<DailyIngredientUsageReport>();

                // Create a list of all dates in the range
                var allDates = Enumerable.Range(0, (endDate.Date - startDate.Date).Days + 1)
                    .Select(offset => startDate.Date.AddDays(offset))
                    .ToList();

                foreach (var date in allDates)
                {
                    var nextDate = date.AddDays(1);

                    // Get usages for this date
                    var dateUsages = usages.Where(u => u.UsageDate >= date && u.UsageDate < nextDate).ToList();

                    if (dateUsages.Count == 0 && ingredientId.HasValue)
                    {
                        // If filtering by ingredient and no usage on this date, add an empty report
                        result.Add(new DailyIngredientUsageReport
                        {
                            Date = date,
                            Ingredients = new List<IngredientDailyUsage>
                    {
                        new IngredientDailyUsage
                        {
                            IngredientId = ingredientId.Value,
                            IngredientName = await GetIngredientNameAsync(ingredientId.Value),
                            QuantityUsed = 0,
                            OrderCount = 0,
                            CostPerUnit = ingredientPrices.GetValueOrDefault(ingredientId.Value),
                            TotalCost = 0
                        }
                    },
                            TotalOrderCount = 0,
                            TotalCost = 0
                        });
                        continue;
                    }

                    if (dateUsages.Count == 0)
                    {
                        // Skip dates with no usage if not filtering by ingredient
                        continue;
                    }

                    // Get order count for this date
                    var orderIds = dateUsages.Select(u => u.OrderId).Distinct().ToList();
                    var orderCount = orderIds.Count;

                    // Group ingredients for this date
                    var ingredientUsages = new List<IngredientDailyUsage>();

                    foreach (var ingredientGroup in dateUsages.GroupBy(u => u.IngredientId))
                    {
                        var currentIngredientId = ingredientGroup.Key;
                        var ingredientName = ingredientGroup.First().Ingredient?.Name ?? "Unknown Ingredient";
                        var quantityUsed = ingredientGroup.Sum(u => u.QuantityUsed);
                        var ingredientOrderCount = ingredientGroup.Select(u => u.OrderId).Distinct().Count();

                        // Get cost per unit
                        ingredientPrices.TryGetValue(currentIngredientId, out var costPerUnit);

                        ingredientUsages.Add(new IngredientDailyUsage
                        {
                            IngredientId = currentIngredientId,
                            IngredientName = ingredientName,
                            QuantityUsed = quantityUsed,
                            OrderCount = ingredientOrderCount,
                            CostPerUnit = costPerUnit,
                            TotalCost = costPerUnit * quantityUsed
                        });
                    }

                    // Calculate total cost
                    var totalCost = ingredientUsages.Sum(i => i.TotalCost);

                    result.Add(new DailyIngredientUsageReport
                    {
                        Date = date,
                        Ingredients = ingredientUsages,
                        TotalOrderCount = orderCount,
                        TotalCost = totalCost
                    });
                }

                return result.OrderBy(r => r.Date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating daily ingredient usage report");
                throw;
            }
        }

        // Helper method to get ingredient name
        private async Task<string> GetIngredientNameAsync(int ingredientId)
        {
            var ingredient = await _unitOfWork.Repository<Ingredient>().GetById(ingredientId);
            return ingredient?.Name ?? "Unknown Ingredient";
        }
    }
}

      
