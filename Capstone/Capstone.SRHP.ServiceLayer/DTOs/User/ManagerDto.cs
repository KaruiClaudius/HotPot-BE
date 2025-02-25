using Capstone.HPTY.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.User
{
    public class ManagerDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; } = null!;
        public ICollection<WorkShift> WorkShifts { get; set; } = new List<WorkShift>();
    }
}
