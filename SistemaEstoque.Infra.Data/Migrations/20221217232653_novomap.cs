using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class novomap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_ENTRADA_EntradaIdEntrada",
                table: "MERCADORIA");

            migrationBuilder.DropIndex(
                name: "IX_MERCADORIA_EntradaIdEntrada",
                table: "MERCADORIA");

            migrationBuilder.DropColumn(
                name: "EntradaIdEntrada",
                table: "MERCADORIA");

            migrationBuilder.DropColumn(
                name: "IDENTRADA",
                table: "MERCADORIA");

            migrationBuilder.DropColumn(
                name: "NOME",
                table: "ENTRADA");

            migrationBuilder.CreateIndex(
                name: "IX_ENTRADA_IDMERCADORIA",
                table: "ENTRADA",
                column: "IDMERCADORIA");

            migrationBuilder.AddForeignKey(
                name: "FK_ENTRADA_MERCADORIA_IDMERCADORIA",
                table: "ENTRADA",
                column: "IDMERCADORIA",
                principalTable: "MERCADORIA",
                principalColumn: "IDMERCADORIA",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENTRADA_MERCADORIA_IDMERCADORIA",
                table: "ENTRADA");

            migrationBuilder.DropIndex(
                name: "IX_ENTRADA_IDMERCADORIA",
                table: "ENTRADA");

            migrationBuilder.AddColumn<Guid>(
                name: "EntradaIdEntrada",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDENTRADA",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOME",
                table: "ENTRADA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MERCADORIA_EntradaIdEntrada",
                table: "MERCADORIA",
                column: "EntradaIdEntrada");

            migrationBuilder.AddForeignKey(
                name: "FK_MERCADORIA_ENTRADA_EntradaIdEntrada",
                table: "MERCADORIA",
                column: "EntradaIdEntrada",
                principalTable: "ENTRADA",
                principalColumn: "IDENTRADA",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
