using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtomotivServisSatis.Data.Migrations
{
    public partial class UserGuidEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Kullanicilar",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklenmeTarihi", "UserGuid" },
                values: new object[] { new DateTime(2024, 8, 1, 13, 14, 18, 529, DateTimeKind.Local).AddTicks(5136), new Guid("82436cc3-bcf4-4ad4-8a6b-ba651138bfb8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Kullanicilar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 16, 11, 29, 51, 496, DateTimeKind.Local).AddTicks(9651));
        }
    }
}
