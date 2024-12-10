using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_Multi_user_chat.Entities;

namespace WebApp_Multi_user_chat.Interfaces
{
    public interface IChatHistoryService
    {
        // Sauvegarde asynchrone de l'historique des messages
        Task SaveMessageHistory(ChatMessage message);

        // Récupérer les messages pour une salle de manière synchrone
        Task<List<ChatMessage>> GetMessagesForRoom(string roomName);

        // Supprimer l'historique des messages d'une salle de manière asynchrone
        Task<bool> DeleteMessageHistory(string roomName);

        // Récupérer les messages pour une salle avec pagination de manière asynchrone
        Task<List<ChatMessage>> GetMessagesForRoom(string roomName, int pageIndex, int pageSize);
    }
}
