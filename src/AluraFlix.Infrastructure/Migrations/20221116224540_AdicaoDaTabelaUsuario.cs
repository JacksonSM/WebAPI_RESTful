using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraFlix.Infrastructure.Migrations
{
    public partial class AdicaoDaTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 16, 19, 45, 40, 472, DateTimeKind.Unspecified).AddTicks(4478), new TimeSpan(0, -3, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 6, 16, 49, 48, 534, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
