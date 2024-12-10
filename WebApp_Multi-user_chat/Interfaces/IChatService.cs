using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_Multi_user_chat.Dto;
using WebApp_Multi_user_chat.Entities;

namespace WebApp_Multi_user_chat.Interfaces
{
    public interface IChatService
    {
        // Envoyer un message (asynchrone)
        Task<ChatMessageResponse> SendMessageAsync(ChatMessageRequest message);
        Task AddAttachementAsync(int chatMessageId, IFormFileCollection files);

        // Récupérer les messages pour une salle donnée (sans pagination) - Asynchrone

        // Supprimer un message
        bool DeleteMessage(int messageId);
        Task<List<ChatMessageResponse>> GetMessagesBySenderIdAndReceiverIdAsync(int senderId, int receiverId);
        Task<Attachement> GetAttachementById(int id);
        Task UpdateAsync(int messageId);
        Task<List<ChatMessageResponse>> GetNewUserMessagesAsync(int userId);
    }
}
