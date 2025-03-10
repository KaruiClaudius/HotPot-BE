using Capstone.HPTY.ModelLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class WorkShift : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public TimeSpan? ShiftStartTime { get; set; }

        [Required]
        public WorkDays DaysOfWeek { get; set; }
        public AttendanceStatus? Status { get; set; }

        public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
        public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();
    }
}
