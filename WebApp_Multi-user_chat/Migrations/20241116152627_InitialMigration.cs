using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp_Multi_user_chat.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    ChatRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.ChatRoomId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "ChatHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatRoomId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_ChatHistory_ChatRooms_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_ChatRooms_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId");
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatRoomId = table.Column<int>(type: "int", nullable: false),
                    ChatHistoryHistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatHistory_ChatHistoryHistoryId",
                        column: x => x.ChatHistoryHistoryId,
                        principalTable: "ChatHistory",
                        principalColumn: "HistoryId");
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatRooms_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChatRooms",
                columns: new[] { "ChatRoomId", "LastUpdated", "RoomName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2106), "General" },
                    { 2, new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2118), "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "NotificationId", "Message", "NotificationType", "RoomName", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { 1, "New user Alice joined the room", "Join", "General", new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2199), "user1" },
                    { 2, "New user Bob joined the room", "Join", "Sports", new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2201), "user2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ChatRoomId", "Password", "UserName" },
                values: new object[,]
                {
                    { "user1", null, "password123", "Alice" },
                    { "user2", null, "password456", "Bob" }
                });

            migrationBuilder.InsertData(
                table: "ChatHistory",
                columns: new[] { "HistoryId", "ChatRoomId", "LastUpdated" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2142) },
                    { 2, 2, new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2144) }
                });

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "Id", "ChatHistoryHistoryId", "ChatRoomId", "Message", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { 1, null, 1, "Hello everyone!", new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2167), "user1" },
                    { 2, null, 1, "Good morning Alice!", new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2169), "user2" },
                    { 3, null, 2, "Who won the match yesterday?", new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2170), "user1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatHistory_ChatRoomId",
                table: "ChatHistory",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatHistoryHistoryId",
                table: "ChatMessages",
                column: "ChatHistoryHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatRoomId",
                table: "ChatMessages",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChatRoomId",
                table: "Users",
                column: "ChatRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ChatHistory");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ChatRooms");
        }
    }
}
