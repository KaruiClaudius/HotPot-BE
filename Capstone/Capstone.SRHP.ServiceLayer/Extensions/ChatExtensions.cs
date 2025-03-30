using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;

namespace Capstone.HPTY.ServiceLayer.Extensions
{
    public static class ChatExtensions
    {
        public static ChatSessionDto ToDto(this ChatSession entity)
        {
            if (entity == null) return null;

            return new ChatSessionDto
            {
                ChatSessionId = entity.ChatSessionId,
                CustomerId = entity.CustomerId,
                CustomerName = entity.Customer?.Name,
                ManagerId = entity.ManagerId,
                ManagerName = entity.Manager?.Name,
                IsActive = entity.IsActive,
                Topic = entity.Topic,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static ChatSessionDetailDto ToDetailDto(this ChatSession entity)
        {
            if (entity == null) return null;

            return new ChatSessionDetailDto
            {
                ChatSessionId = entity.ChatSessionId,
                CustomerId = entity.CustomerId,
                CustomerName = entity.Customer?.Name,
                ManagerId = entity.ManagerId,
                ManagerName = entity.Manager?.Name,
                IsActive = entity.IsActive,
                Topic = entity.Topic,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Messages = entity.Messages?.Select(m => m.ToDto()).ToList() ?? new List<ChatMessageDto>()
            };
        }

        public static ChatMessageDto ToDto(this ChatMessage entity)
        {
            if (entity == null) return null;

            return new ChatMessageDto
            {
                ChatMessageId = entity.ChatMessageId,
                SenderUserId = entity.SenderUserId,
                SenderName = entity.SenderUser?.Name,
                ReceiverUserId = entity.ReceiverUserId,
                ReceiverName = entity.ReceiverUser?.Name,
                Message = entity.Message,
                IsRead = entity.IsRead,
                CreatedAt = entity.CreatedAt
            };
        }

        public static List<ChatSessionDto> ToDtoList(this IEnumerable<ChatSession> entities)
        {
            return entities?.Select(e => e.ToDto()).ToList() ?? new List<ChatSessionDto>();
        }

        public static List<ChatMessageDto> ToDtoList(this IEnumerable<ChatMessage> entities)
        {
            return entities?.Select(e => e.ToDto()).ToList() ?? new List<ChatMessageDto>();
        }

    }
}
