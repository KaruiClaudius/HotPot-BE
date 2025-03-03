using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Interfaces.IngredientService
{
    public interface ISizeDiscountService : IBaseService<SizeDiscount>
    {
        Task<SizeDiscount> GetApplicableDiscountAsync(int size);
    }
}
