using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Common
{
    public class DeleteImagesRequest
    {
        [Required]
        public string[] ImageURLs { get; set; }
    }
}
