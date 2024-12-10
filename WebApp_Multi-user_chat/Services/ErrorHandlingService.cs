using WebApp_Multi_user_chat.Interfaces;

namespace WebApp_Multi_user_chat.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        private readonly string _logFilePath = "error_log.txt"; // Le chemin vers le fichier de log (peut être configuré)

        // Méthode synchrone pour consigner une erreur
        public void LogError(string errorMessage, string severity = "Error", string? userId = null)
        {
            var logMessage = CreateLogMessage(errorMessage, severity, userId);
            WriteToLogFile(logMessage);
        }

        // Méthode pour consigner une exception complète
        public void LogError(Exception ex, string severity = "Error", string? userId = null)
        {
            var logMessage = CreateLogMessage(ex.Message, severity, userId);
            logMessage += $"\nStack Trace: {ex.StackTrace}";
            WriteToLogFile(logMessage);
        }

        // Méthode asynchrone pour consigner une erreur avec une meilleure gestion de la performance
        public async Task LogErrorAsync(string errorMessage, string severity = "Error", string? userId = null)
        {
            var logMessage = CreateLogMessage(errorMessage, severity, userId);
            await WriteToLogFileAsync(logMessage);
        }

        // Méthode pour consigner une exception avec gestion asynchrone
        public async Task LogErrorAsync(Exception ex, string severity = "Error", string? userId = null)
        {
            var logMessage = CreateLogMessage(ex.Message, severity, userId);
            logMessage += $"\nStack Trace: {ex.StackTrace}";
            await WriteToLogFileAsync(logMessage);
        }

        // Créer un message de log structuré
        private string CreateLogMessage(string message, string severity, string? userId)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var userInfo = string.IsNullOrEmpty(userId) ? "No user" : userId;
            return $"[{timestamp}] [Severity: {severity}] [User: {userInfo}] - {message}";
        }

        // Écrire dans le fichier de log de manière synchrone
        private void WriteToLogFile(string logMessage)
        {
            try
            {
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Si on ne peut pas écrire dans le fichier, on affiche l'erreur dans la console
                Console.WriteLine($"Error logging to file: {ex.Message}");
            }
        }

        // Écrire dans le fichier de log de manière asynchrone
        private async Task WriteToLogFileAsync(string logMessage)
        {
            try
            {
                await File.AppendAllTextAsync(_logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Si on ne peut pas écrire dans le fichier, on affiche l'erreur dans la console
                Console.WriteLine($"Error logging to file: {ex.Message}");
            }
        }
    }
}
