using System.ComponentModel.DataAnnotations;

namespace WebApp_Multi_user_chat.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; }
    public required string UserName { get; set; }

    public required string Password { get; set; }
    public List<ChatMessage> ChatSenderMessages { get; set; }
    public List<ChatMessage> ChatReceiverMessages { get; set; }
}