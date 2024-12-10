using WebApp_Multi_user_chat.Interfaces;
using WebApp_Multi_user_chat.Models;

namespace WebApp_Multi_user_chat.Services
{
    public class ErrorLoggingService : IErrorLoggingService
    {
        private readonly string _logFilePath = "error_log.txt"; // Chemin vers le fichier de log

        // Méthode pour consigner une erreur dans un fichier
        public void LogError(ErrorLog errorLog)
        {
            try
            {
                // Créer un message structuré pour le log
                var logMessage = CreateLogMessage(errorLog);

                // Écrire dans le fichier
                WriteToLogFile(logMessage);
            }
            catch (Exception ex)
            {
                // Si l'écriture échoue, afficher l'erreur dans la console
                Console.WriteLine($"Error logging to file: {ex.Message}");
            }
        }

        // Créer un message de log structuré
        private string CreateLogMessage(ErrorLog errorLog)
        {
            var timestamp = errorLog.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
            return $"[{timestamp}] [Type: {errorLog.ErrorType}] - {errorLog.ErrorMessage}";
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
    }
}
