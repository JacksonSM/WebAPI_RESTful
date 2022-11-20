using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraFlix.Infrastructure.Migrations
{
    public partial class AdicionandoColunaROLEEmUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 20, 11, 25, 48, 413, DateTimeKind.Unspecified).AddTicks(1856), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataCriacao", "Email", "Nome", "Role", "Senha" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 11, 20, 11, 25, 48, 413, DateTimeKind.Unspecified).AddTicks(2408), new TimeSpan(0, -3, 0, 0, 0)), "firstAdm@gmail.com", "Administrador", "ADMIN", "8c5722d24a864a75e1e87e9e9e2926694b2fab0a0be4708984a07af88b1a204db9280ee4760682788428467dcc0a47ab8f6d77500c844a67e0507baaf7987f0a" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataCriacao", "Email", "Nome", "Role", "Senha" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2022, 11, 20, 11, 25, 48, 413, DateTimeKind.Unspecified).AddTicks(2513), new TimeSpan(0, -3, 0, 0, 0)), "user321@gmail.com", "Usuario", "USER", "f0eba30fd73259a377087a149274cb51d2c98ac08355faf632c075224887c29298d913169751c21ef10079a4c892ab4b0b47e0d58ebe5a2135f7b493f0f32e0b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTimeOffset(new DateTime(2022, 11, 16, 19, 45, 40, 472, DateTimeKind.Unspecified).AddTicks(4478), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
