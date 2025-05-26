using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Ingredient
{
    public class MultipleBatchRequest
    {
        [Required]
        public List<CreateBatchRequest> Batches { get; set; }
    }
}
