using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtomotivServisSatis.Data.Migrations
{
    public partial class AnasayfaEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anasayfa",
                table: "Araclar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 16, 11, 29, 51, 496, DateTimeKind.Local).AddTicks(9651));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anasayfa",
                table: "Araclar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 7, 12, 18, 50, 45, 866, DateTimeKind.Local).AddTicks(3264));
        }
    }
}
