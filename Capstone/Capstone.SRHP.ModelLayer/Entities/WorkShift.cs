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

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ShiftTime { get; set; }

        public AttendanceStatus? Status { get; set; }

        [ForeignKey("Managers")]
        public int? ManagerID { get; set; }

        [ForeignKey("Staffs")]
        public int? StaffID { get; set; }

        public virtual Staff? Staff { get; set; }
        public virtual Manager? Manager { get; set; }
    }
}
