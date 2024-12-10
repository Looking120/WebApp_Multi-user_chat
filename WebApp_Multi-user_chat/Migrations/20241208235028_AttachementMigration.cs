using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Multi_user_chat.Migrations
{
    /// <inheritdoc />
    public partial class AttachementMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachement_ChatMessages_ChatMessageId",
                table: "Attachement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachement",
                table: "Attachement");

            migrationBuilder.RenameTable(
                name: "Attachement",
                newName: "Attachements");

            migrationBuilder.RenameIndex(
                name: "IX_Attachement_ChatMessageId",
                table: "Attachements",
                newName: "IX_Attachements_ChatMessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachements",
                table: "Attachements",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2024, 12, 9, 2, 50, 26, 926, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2024, 12, 9, 2, 50, 26, 926, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.AddForeignKey(
                name: "FK_Attachements_ChatMessages_ChatMessageId",
                table: "Attachements",
                column: "ChatMessageId",
                principalTable: "ChatMessages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachements_ChatMessages_ChatMessageId",
                table: "Attachements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachements",
                table: "Attachements");

            migrationBuilder.RenameTable(
                name: "Attachements",
                newName: "Attachement");

            migrationBuilder.RenameIndex(
                name: "IX_Attachements_ChatMessageId",
                table: "Attachement",
                newName: "IX_Attachement_ChatMessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachement",
                table: "Attachement",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 30, 0, 26, 57, 582, DateTimeKind.Local).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 30, 0, 26, 57, 582, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.AddForeignKey(
                name: "FK_Attachement_ChatMessages_ChatMessageId",
                table: "Attachement",
                column: "ChatMessageId",
                principalTable: "ChatMessages",
                principalColumn: "Id");
        }
    }
}
