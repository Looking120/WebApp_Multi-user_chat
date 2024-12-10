namespace WebApp_Multi_user_chat.Models
{
    public class ErrorLog
    {
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; } = "Error"; // Par défaut, l'erreur est de type "Error"
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public ErrorLog(string errorMessage, string errorType = "Error")
        {
            ErrorMessage = errorMessage;
            ErrorType = errorType;
        }

        public ErrorLog(string errorMessage) 
        { 
            ErrorMessage = errorMessage;
        }
    }
}
