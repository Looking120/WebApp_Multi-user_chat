namespace WebApp_Multi_user_chat.Interfaces
{
    public interface IErrorHandlingService
    {
        // Méthode synchrone pour consigner une erreur
        void LogError(string errorMessage, string severity = "Error", string? userId = null);

        // Méthode pour consigner une exception complète
        void LogError(Exception ex, string severity = "Error", string? userId = null);

        // Méthode asynchrone pour consigner une erreur avec une meilleure gestion de la performance
        Task LogErrorAsync(string errorMessage, string severity = "Error", string? userId = null);

        // Méthode pour consigner une exception avec gestion asynchrone
        Task LogErrorAsync(Exception ex, string severity = "Error", string? userId = null);
    }
}
