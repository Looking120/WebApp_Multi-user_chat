using WebApp_Multi_user_chat.Models;

namespace WebApp_Multi_user_chat.Interfaces
{
    public interface IErrorLoggingService
    {
        void LogError(ErrorLog errorLog);

    }
}
