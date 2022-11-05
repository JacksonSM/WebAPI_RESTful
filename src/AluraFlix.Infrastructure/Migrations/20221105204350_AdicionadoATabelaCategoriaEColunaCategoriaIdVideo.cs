using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraFlix.Infrastructure.Migrations
{
    public partial class AdicionadoATabelaCategoriaEColunaCategoriaIdVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Videos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Cor = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DataCriacao = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Cor", "DataCriacao", "Titulo" },
                values: new object[] { 1, "#FFFFFF", new DateTimeOffset(new DateTime(2022, 11, 5, 17, 43, 49, 493, DateTimeKind.Unspecified).AddTicks(490), new TimeSpan(0, -3, 0, 0, 0)), "LIVRE" });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CategoriaId",
                table: "Videos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Categoria_CategoriaId",
                table: "Videos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Categoria_CategoriaId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Videos_CategoriaId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Videos");
        }
    }
}
