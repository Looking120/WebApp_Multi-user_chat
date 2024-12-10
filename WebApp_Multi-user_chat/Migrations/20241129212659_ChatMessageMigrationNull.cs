using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Multi_user_chat.Migrations
{
    /// <inheritdoc />
    public partial class ChatMessageMigrationNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachement_ChatMessages_ChatMessageId",
                table: "Attachement");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "ChatMessages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "ChatMessages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChatMessageId",
                table: "Attachement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachement_ChatMessages_ChatMessageId",
                table: "Attachement");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "ChatMessages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "ChatMessages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChatMessageId",
                table: "Attachement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 1,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 30, 0, 18, 30, 901, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "Notification",
                keyColumn: "NotificationId",
                keyValue: 2,
                column: "TimeStamp",
                value: new DateTime(2024, 11, 30, 0, 18, 30, 901, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.AddForeignKey(
                name: "FK_Attachement_ChatMessages_ChatMessageId",
                table: "Attachement",
                column: "ChatMessageId",
                principalTable: "ChatMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
