using WebApp_Multi_user_chat.Entities;

namespace WebApp_Multi_user_chat.Dto
{
    public class ChatMessageRequest
    {
        public string? Message { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
