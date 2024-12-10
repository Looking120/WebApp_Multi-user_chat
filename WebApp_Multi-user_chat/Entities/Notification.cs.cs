using System.ComponentModel.DataAnnotations;

namespace WebApp_Multi_user_chat.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        public string RoomName { get; set; }

        public string Message { get; set; }

        public string NotificationType { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public string? UserId { get; set; }
    }
}