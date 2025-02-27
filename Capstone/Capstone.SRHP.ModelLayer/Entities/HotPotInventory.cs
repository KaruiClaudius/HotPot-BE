using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class HotPotInventory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotPotInventoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string SeriesNumber { get; set; }

        public int HotpotId { get; set; }

        public bool Status { get; set; }

        public virtual Hotpot? Hotpot { get; set; }


        public virtual ICollection<ConditionLog>? ConditionLogs { get; set; }

    }
}
