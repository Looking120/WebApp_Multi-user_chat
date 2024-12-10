using System.Collections.Generic;
using WebApp_Multi_user_chat.Entities;
using WebApp_Multi_user_chat.Interfaces;

namespace WebApp_Multi_user_chat.Services
{
    public class ValidationService : IValidationService
    {
        public void SaveMessageHistory(ChatMessage message)
        {
            // Sauvegarder un message dans l'historique
        }

        public void DeleteMessageHistory(int messageId)
        {
            // Supprimer un message de l'historique
        }

        public List<ChatMessage> GetMessageHistory(string roomName, int pageNumber = 1, int pageSize = 50)
        {
            // Récupérer l'historique des messages avec pagination
            return new List<ChatMessage>();  // Implémenter avec la base de données
        }

        public bool ValidateMessage(ChatMessage message)
        {
            // Valider un message (exemple : vérifier sa taille ou son contenu)
            return !string.IsNullOrWhiteSpace(message.Message);
        }
    }
}
