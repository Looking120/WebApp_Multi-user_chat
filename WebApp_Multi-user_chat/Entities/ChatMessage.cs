using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Multi_user_chat.Entities
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public int? SenderId { get; set; }
        public User? Sender { get; set; }
        public int? ReceiverId { get; set; }
        public User? Receiver { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public bool IsMessageRead { get; set; } = false;

        public List<Attachement> Attachements { get; set; }

    }
}
