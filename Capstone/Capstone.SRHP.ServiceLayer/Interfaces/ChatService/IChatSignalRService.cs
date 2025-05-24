using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ChatService
{
    public interface IChatSignalRService
    {

        Task NotifyNewChat(ChatSessionDto session);
        Task NotifyChatAccepted(ChatSessionDto session);
        Task NotifyNewMessage(ChatMessageDto message, int sessionId);
        Task NotifyChatEnded(ChatSessionDto session);
    }
}
