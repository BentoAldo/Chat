using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedchatrooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChatRooms",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 16, 13, 25, 34, 744, DateTimeKind.Local).AddTicks(1140), "The first Chat Room", "Chat Room 1" },
                    { 2, new DateTime(2023, 1, 16, 13, 25, 34, 744, DateTimeKind.Local).AddTicks(1190), "The second Chat Room", "Chat Room 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
