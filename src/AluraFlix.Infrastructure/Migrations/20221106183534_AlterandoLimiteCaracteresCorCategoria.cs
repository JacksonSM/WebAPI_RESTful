using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraFlix.Infrastructure.Migrations
{
    public partial class AlterandoLimiteCaracteresCorCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 6, 15, 35, 33, 925, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, -3, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 5, 17, 43, 49, 493, DateTimeKind.Unspecified).AddTicks(490), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
