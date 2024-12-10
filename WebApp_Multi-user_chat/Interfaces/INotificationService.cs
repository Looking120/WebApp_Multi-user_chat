namespace WebApp_Multi_user_chat.Interfaces
{
    public interface INotificationService
    {
        // Notifie tous les utilisateurs d'une salle de chat
        Task NotifyRoomAsync(string roomName, string message);

        // Notifie un utilisateur spécifique dans une salle (si besoin)
        Task NotifyUserAsync(string userId, string roomName, string message);

        // Méthode pour envoyer une notification avec un type spécifique
        Task NotifyRoomWithTypeAsync(string roomName, string message, string notificationType);
    }
}
