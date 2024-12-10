using WebApp_Multi_user_chat.Entities;

namespace WebApp_Multi_user_chat.Dto
{
    public class ChatMessageResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public bool IsMessageRead { get; set; } = false;
        public List<AttachementResponse> Attachements { get; set; }
    }
}
