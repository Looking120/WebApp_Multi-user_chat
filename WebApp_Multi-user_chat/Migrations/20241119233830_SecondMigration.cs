using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Multi_user_chat.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChatHistory",
                keyColumn: "HistoryId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "ChatHistory",
                keyColumn: "HistoryId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "ChatRoomId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "ChatRoomId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 20, 2, 38, 27, 977, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "user1",
                column: "Email",
                value: "alice@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "user2",
                column: "Email",
                value: "bob@gmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "ChatHistory",
                keyColumn: "HistoryId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "ChatHistory",
                keyColumn: "HistoryId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "ChatRoomId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "ChatRoomId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 16, 18, 26, 27, 209, DateTimeKind.Local).AddTicks(2201));
        }
    }
}
