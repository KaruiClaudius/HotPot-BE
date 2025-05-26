using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.IngredientReport;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ComboService
{
    public interface IIngredientReportService
    {
        Task<IEnumerable<IngredientUsageReport>> GetIngredientUsageReportAsync(
            DateTime startDate,
            DateTime endDate,
            int? ingredientId = null);

        Task<IEnumerable<BatchUsageReport>> GetBatchUsageReportAsync(
            int ingredientId,
            DateTime startDate,
            DateTime endDate);

        Task<IEnumerable<OrderIngredientUsageReport>> GetOrderIngredientUsageAsync(int orderId);

        Task<IEnumerable<IngredientUsageByComboReport>> GetIngredientUsageByComboAsync(
            DateTime startDate,
            DateTime endDate,
            int? comboId = null);

        Task<IEnumerable<IngredientUsageByCustomizationReport>> GetIngredientUsageByCustomizationAsync(
            DateTime startDate,
            DateTime endDate,
            int? customizationId = null);

        Task<IEnumerable<DailyIngredientUsageReport>> GetDailyIngredientUsageAsync(
            DateTime startDate,
            DateTime endDate,
            int? ingredientId = null);
    }
}
