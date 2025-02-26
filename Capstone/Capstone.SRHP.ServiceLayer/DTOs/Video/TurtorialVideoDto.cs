using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Video
{
    public class TurtorialVideoDto
    {
        public int TurtorialVideoId { get; set; }
        public string Name { get; set; }
        public string VideoURL { get; set; }
        public string? Description { get; set; }
        public int HotpotCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class TurtorialVideoDetailDto : TurtorialVideoDto
    {
        public List<HotpotDto> Hotpots { get; set; }
    }
}
