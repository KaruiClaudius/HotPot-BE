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
        public int WorkShiftId { get; set; }

        public TimeSpan? ShiftStartTime { get; set; }

        public TimeSpan? ShiftEndTime { get; set; }

        public string ShiftName { get; set; }


        [InverseProperty("StaffWorkShifts")]
        public virtual ICollection<User>? Staff { get; set; } = new List<User>();

        [InverseProperty("MangerWorkShifts")]
        public virtual ICollection<User> Managers { get; set; } = new List<User>();
    }
}
