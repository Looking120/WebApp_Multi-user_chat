using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Multi_user_chat.Entities;
using WebApp_Multi_user_chat.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApp_Multi_user_chat.Data;
using WebApp_Multi_user_chat.Dto;
using Microsoft.CodeAnalysis.CSharp;
using Mapster;

namespace WebApp_Multi_user_chat.Services
{
    public class ChatService : IChatService
    {
        private readonly ChatDbContext _context;

        public ChatService(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<ChatMessageResponse> SendMessageAsync(ChatMessageRequest message)
        {
            var chatMapped = message.Adapt<ChatMessage>();
            _context.ChatMessages.Add(chatMapped);
            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();

            return chatMapped.Adapt<ChatMessageResponse>();
        }

        public async Task AddAttachementAsync(int chatMessageId, IFormFileCollection files)
        {
            if (files is null || files.Count == 0)
            {
                return;
            }

            foreach (var file in files)
            {
                if (file is null)
                {
                    continue;
                }

                var fileContent = file.OpenReadStream();

                _context.Attachements.Add(new Attachement()
                {
                    FileName = file.FileName,
                    Extension = file.ContentType,
                    Content = ReadFully(fileContent),
                    ChatMessageId = chatMessageId
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<ChatMessageResponse>> GetMessagesBySenderIdAndReceiverIdAsync(int senderId, int receiverId)
        {
            return (await _context.ChatMessages
                .Include(x => x.Attachements)
                .AsNoTracking()
                .Where(x => (x.SenderId.Equals(senderId) && x.ReceiverId.Equals(receiverId)) || (x.SenderId.Equals(receiverId) && x.ReceiverId.Equals(senderId)))
                .OrderByDescending(x => x.Time)
                .ToListAsync()).Adapt<List<ChatMessageResponse>>();
        }

        public bool DeleteMessage(int messageId)
        {
            var message = _context.ChatMessages.Find(messageId);
            if (message == null)
                return false;

            _context.ChatMessages.Remove(message);
            _context.SaveChanges();
            return true;
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public async Task<Attachement> GetAttachementById(int id)
        {
            var attachement = await _context.Attachements.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            ArgumentNullException.ThrowIfNull(attachement);

            return attachement;
        }

        public async Task UpdateAsync(int messageId)
        {
            var message = await _context.ChatMessages.Where(x => x.Id == messageId).AsNoTracking().FirstOrDefaultAsync();

            ArgumentNullException.ThrowIfNull(message);

            message.IsMessageRead = true;
            await _context.SaveChangesAsync();

        }

        public async Task<List<ChatMessageResponse>> GetNewUserMessagesAsync(int userId)
        {
            var newMessages = await _context.ChatMessages
                .Include(x => x.Attachements)
                .Where(x => x.ReceiverId == userId)
                .OrderByDescending(x => x.Time)
                .ToListAsync();

            return newMessages.Adapt<List<ChatMessageResponse>>();
        }
    }
}
