using System.Collections.Generic;
using WebApp_Multi_user_chat.Entities;

namespace WebApp_Multi_user_chat.Interfaces
{
    public interface IValidationService
    {
        void SaveMessageHistory(ChatMessage message);                          // Sauvegarde d'un message
        void DeleteMessageHistory(int messageId);                              // Suppression d'un message par son ID
        List<ChatMessage> GetMessageHistory(string roomName, int pageNumber = 1, int pageSize = 50); // Récupération des messages par room avec pagination
        bool ValidateMessage(ChatMessage message);                              // Valider un message avant de l'ajouter
    }
}
