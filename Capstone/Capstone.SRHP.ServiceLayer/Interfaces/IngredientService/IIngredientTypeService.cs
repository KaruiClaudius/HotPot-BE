using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.IngredientService
{
    public interface IIngredientTypeService : IBaseService<IngredientType>
    {
        Task<PagedResult<IngredientType>> GetPagedAsync(int pageNumber, int pageSize);
        Task<int> GetIngredientCountByTypeAsync(int typeId);
        Task<Dictionary<int, int>> GetIngredientCountsByTypesAsync(IEnumerable<int> typeIds);
        Task<PagedResult<IngredientType>> SearchAsync(string searchTerm, int pageNumber, int pageSize);
    }
}
