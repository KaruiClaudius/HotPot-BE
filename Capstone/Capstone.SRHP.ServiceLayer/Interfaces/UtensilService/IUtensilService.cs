using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.UtensilService
{
    public interface IUtensilService
    {
        // Utensil methods
        Task<PagedResult<Utensil>> GetUtensilsAsync(
            string searchTerm = null,
            int? typeId = null,
            bool? isAvailable = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Name",
            bool ascending = true);
        Task<Utensil> GetUtensilByIdAsync(int id);
        Task<Utensil> CreateUtensilAsync(Utensil entity);
        Task UpdateUtensilAsync(int id, Utensil entity);
        Task DeleteUtensilAsync(int id);
        Task UpdateUtensilStatusAsync(int id, bool status);
        Task UpdateUtensilQuantityAsync(int id, int quantity);
        Task<bool> IsUtensilAvailableAsync(int id);

        // Utensil Type methods
        Task<IEnumerable<UtensilType>> GetAllUtensilTypesAsync();
        Task<UtensilType> GetUtensilTypeByIdAsync(int id);
        Task<UtensilType> CreateUtensilTypeAsync(string name);
        Task DeleteUtensilTypeAsync(int id);
        Task<Dictionary<int, int>> GetUtensilCountsByTypesAsync(IEnumerable<int> typeIds);
    }
}
