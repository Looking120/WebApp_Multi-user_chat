namespace WebApp_Multi_user_chat.Models
{
    public class UserSettings
    {
        public string Theme { get; set; } = "light";
        public bool NotificationsEnabled { get; set; } = true;

        public DateTime LastUodated { get; set; } = DateTime.Now;

        public enum thrmeOption
        {
            light,
            Dark
        }
    }
}
