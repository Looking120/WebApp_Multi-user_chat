﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_Multi_user_chat.Data;

#nullable disable

namespace WebApp_Multi_user_chat.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    [Migration("20241129212659_ChatMessageMigrationNull")]
    partial class ChatMessageMigrationNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.Attachement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChatMessageId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChatMessageId");

                    b.ToTable("Attachement");
                });

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMessageRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.ToTable("Notification");

                    b.HasData(
                        new
                        {
                            NotificationId = 1,
                            Message = "New user Alice joined the room",
                            NotificationType = "Join",
                            RoomName = "General",
                            TimeStamp = new DateTime(2024, 11, 30, 0, 26, 57, 582, DateTimeKind.Local).AddTicks(1494),
                            UserId = "user1"
                        },
                        new
                        {
                            NotificationId = 2,
                            Message = "New user Bob joined the room",
                            NotificationType = "Join",
                            RoomName = "Sports",
                            TimeStamp = new DateTime(2024, 11, 30, 0, 26, 57, 582, DateTimeKind.Local).AddTicks(1497),
                            UserId = "user2"
                        });
                });

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Email = "alice@gmail.com",
                            Password = "password123",
                            UserName = "Alice"
                        },
                        new
                        {
                            Id = -2,
                            Email = "bob@gmail.com",
                            Password = "password456",
                            UserName = "Bob"
                        });
                });

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.Attachement", b =>
                {
                    b.HasOne("WebApp_Multi_user_chat.Entities.ChatMessage", "ChatMessage")
                        .WithMany("Attachements")
                        .HasForeignKey("ChatMessageId");

                    b.Navigation("ChatMessage");
                });

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.ChatMessage", b =>
                {
                    b.HasOne("WebApp_Multi_user_chat.Entities.User", "Receiver")
                        .WithMany("ChatReceiverMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WebApp_Multi_user_chat.Entities.User", "Sender")
                        .WithMany("ChatSenderMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.ChatMessage", b =>
                {
                    b.Navigation("Attachements");
                });

            modelBuilder.Entity("WebApp_Multi_user_chat.Entities.User", b =>
                {
                    b.Navigation("ChatReceiverMessages");

                    b.Navigation("ChatSenderMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
