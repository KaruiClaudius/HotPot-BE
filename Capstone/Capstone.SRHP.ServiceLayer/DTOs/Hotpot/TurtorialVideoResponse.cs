using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Hotpot
{
    public class TurtorialVideoResponse
    {
        public int TurtorialVideoId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
