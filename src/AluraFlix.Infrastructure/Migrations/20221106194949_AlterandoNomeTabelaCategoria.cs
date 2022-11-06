using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraFlix.Infrastructure.Migrations
{
    public partial class AlterandoNomeTabelaCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Categoria_CategoriaId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 6, 16, 49, 48, 534, DateTimeKind.Unspecified).AddTicks(3258), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Categorias_CategoriaId",
                table: "Videos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Categorias_CategoriaId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 6, 15, 35, 33, 925, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Categoria_CategoriaId",
                table: "Videos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
