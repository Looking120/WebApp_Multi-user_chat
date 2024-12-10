using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp_Multi_user_chat.Data;
using WebApp_Multi_user_chat.Entities;
using WebApp_Multi_user_chat.Interfaces;

namespace WebApp_Multi_user_chat.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ChatDbContext _context;

        public NotificationService(ChatDbContext context)
        {
            _context = context;
        }

        public async Task NotifyRoomAsync(string roomName, string message)
        {
            
        }

        public async Task NotifyUserAsync(string userId, string roomName, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                RoomName = roomName,
                Message = message,
                NotificationType = "Private",
                TimeStamp = DateTime.Now
            };

            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task NotifyRoomWithTypeAsync(string roomName, string message, string notificationType)
        {
            
        }
    }
}
