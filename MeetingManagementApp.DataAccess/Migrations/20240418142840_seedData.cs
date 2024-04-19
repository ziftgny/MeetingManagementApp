using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetingManagementApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "Description", "DocumentURL", "EndTime", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, "deneme", "deneme", new DateTime(2024, 4, 18, 17, 28, 39, 529, DateTimeKind.Local).AddTicks(1876), "pazar toplantısı", new DateTime(2024, 4, 18, 17, 28, 39, 529, DateTimeKind.Local).AddTicks(1894) },
                    { 2, "deneme", "deneme", new DateTime(2024, 4, 18, 17, 28, 39, 529, DateTimeKind.Local).AddTicks(1897), "sali toplantısı", new DateTime(2024, 4, 18, 17, 28, 39, 529, DateTimeKind.Local).AddTicks(1898) },
                    { 3, "deneme", "deneme", new DateTime(2024, 4, 18, 17, 28, 39, 529, DateTimeKind.Local).AddTicks(1901), "toplanmantısı", new DateTime(2024, 4, 18, 17, 28, 39, 529, DateTimeKind.Local).AddTicks(1902) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
