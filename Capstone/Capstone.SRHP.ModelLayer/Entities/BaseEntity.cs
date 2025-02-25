using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ModelLayer.Entities
{
    public class BaseEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? UpdatedAt { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDelete { get; set; } = false;

        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow.AddHours(7); 
        }

        public virtual void SetUpdateDate()
        {
            UpdatedAt = DateTime.UtcNow.AddHours(7);
        }

        public virtual void SoftDelete()
        {
            IsDelete = true;
            SetUpdateDate();
        }
    }
}
