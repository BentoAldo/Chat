using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedChatRoomIdasfkonMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "ChatRoomId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 16, 20, 59, 17, 326, DateTimeKind.Local).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 16, 20, 59, 17, 326, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "ChatRoomId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 16, 13, 25, 34, 744, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 16, 13, 25, 34, 744, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id");
        }
    }
}
