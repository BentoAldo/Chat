using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullableuseridinmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 17, 20, 13, 40, 279, DateTimeKind.Local).AddTicks(2930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 17, 0, 38, 34, 559, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 17, 20, 13, 40, 279, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 17, 20, 13, 40, 279, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 17, 0, 38, 34, 559, DateTimeKind.Local).AddTicks(3950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 17, 20, 13, 40, 279, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 17, 0, 38, 34, 559, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 1, 17, 0, 38, 34, 559, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
