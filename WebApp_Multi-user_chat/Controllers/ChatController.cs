using Microsoft.AspNetCore.Mvc;
using WebApp_Multi_user_chat.Interfaces;
using WebApp_Multi_user_chat.Dto;

namespace WebApp_Multi_user_chat.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IChatService chatService, INotificationService notificationService, ILogger<ChatController> logger)
        {
            _chatService = chatService;
            _notificationService = notificationService;
            _logger = logger;
        }

        // Envoi d'un message à une salle de chat
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageRequest message) 
        { 
            _logger.LogInformation("message "+ message.Message);

            return Ok(await _chatService.SendMessageAsync(message));
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> AddAttachement(int id, IFormFileCollection files)
        {
            await _chatService.AddAttachementAsync(id, files);

            return Ok();
        }

        [HttpGet]
       public async Task<IActionResult> GetMessagesBySenderIdAndReceiverId([FromQuery] int senderId, [FromQuery] int receiverId)
       {
            return Ok(await _chatService.GetMessagesBySenderIdAndReceiverIdAsync(senderId, receiverId));
       }

        [HttpGet("download")]
       public async Task<IActionResult> DownloadFile(int id)
       {
            var file = await _chatService.GetAttachementById(id);
            return File(file.Content, file.Extension, file.FileName);
       }

        [HttpPut]
        public async Task<IActionResult> Update(int messageId)
        {
            await _chatService.UpdateAsync(messageId);
            return Ok();
        }

        [HttpGet("new-messages/{userId:int}")]
        public async Task<IActionResult> GetNewUserMessages(int userId)
        {
            return Ok(await _chatService.GetNewUserMessagesAsync(userId));
        }
    }
}
