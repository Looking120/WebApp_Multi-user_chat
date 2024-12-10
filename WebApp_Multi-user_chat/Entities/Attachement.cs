namespace WebApp_Multi_user_chat.Entities;

public class Attachement
{
    public int Id { get; set; }
    public byte[] Content { get; set; }
    public string Extension { get; set; }
    public string FileName { get; set;  }
    public int? ChatMessageId { get;set; }

    public ChatMessage? ChatMessage { get; set; }
}
