using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class mappingDateinmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 17, 0, 38, 34, 559, DateTimeKind.Local).AddTicks(3950));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Messages");

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
        }
    }
}
