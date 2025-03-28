using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ManagerService
{
    public interface IEquipmentService
    {
        Task<ConditionLogDto> LogEquipmentFailureAsync(EquipmentFailureDto failureDto); //keep
        Task<ConditionLogDetailDto> GetConditionLogByIdAsync(int conditionLogId); // keep
        Task<IEnumerable<ConditionLogDto>> GetActiveConditionLogsAsync(); // keep
        Task<ConditionLogDto> VerifyEquipmentFailureAsync(int conditionLogId, bool isVerified, string verificationNotes, int staffId); // keep


    }
}
