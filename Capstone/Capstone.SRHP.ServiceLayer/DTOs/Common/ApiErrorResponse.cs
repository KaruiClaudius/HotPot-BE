using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Common
{
    public class ApiErrorResponse
    {
        public string Status { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? DetailedMessage { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<string> Errors { get; set; } = new List<string>();
    }
}
