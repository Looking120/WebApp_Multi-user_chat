namespace WebApp_Multi_user_chat.Dto
{
    public class AttachementResponse
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public int? ChatMessageId { get; set; }
    }
}
