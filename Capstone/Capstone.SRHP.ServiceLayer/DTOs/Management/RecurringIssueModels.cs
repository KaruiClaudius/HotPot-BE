using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class RecurringIssueDto
    {
        public string EquipmentType { get; set; } // "HotPot" or "Utensil"
        public string IssueName { get; set; }
        public int OccurrenceCount { get; set; }
        public List<int> ConditionLogIds { get; set; }
        public DateTime FirstOccurrence { get; set; }
        public DateTime LastOccurrence { get; set; }
    }
}
