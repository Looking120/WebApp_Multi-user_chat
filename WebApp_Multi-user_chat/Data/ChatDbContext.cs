using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using WebApp_Multi_user_chat.Entities;

namespace WebApp_Multi_user_chat.Data;

public class ChatDbContext : DbContext
{
    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options)
    {

    }


    public DbSet<User> Users { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<Notification> Notification { get; set; }
    public DbSet<Attachement> Attachements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>()
            .HasOne(m => m.Sender)
            .WithMany(r => r.ChatSenderMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ChatMessage>()
            .HasOne(m => m.Receiver)
            .WithMany(x => x.ChatReceiverMessages)
            .HasForeignKey(x => x.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);


        // Seed des données pour les entités

        // Ajout des utilisateurs
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = -1,
                UserName = "Alice",
                Email = "alice@gmail.com",
                Password = "password123"
            },
            new User
            {
                Id = -2,
                UserName = "Bob",
                Email = "bob@gmail.com",
                Password = "password456"
            },
              new User
              {
                  Id = -3,
                  UserName = "Franck",
                  Email = "franck@gmail.com",
                  Password = "password4562"
              }
        );


        // Ajout des notifications
        modelBuilder.Entity<Notification>().HasData(
            new Notification
            {
                NotificationId = 1,
                RoomName = "General",
                Message = "New user Alice joined the room",
                NotificationType = "Join",
                TimeStamp = DateTime.Now,
                UserId = "user1"
            },
            new Notification
            {
                NotificationId = 2,
                RoomName = "Sports",
                Message = "New user Bob joined the room",
                NotificationType = "Join",
                TimeStamp = DateTime.Now,
                UserId = "user2"
            }
        );
    }
}
