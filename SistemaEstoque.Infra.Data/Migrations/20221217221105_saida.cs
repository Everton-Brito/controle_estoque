using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class saida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_ENTRADA_IDENTRADA",
                table: "MERCADORIA");

            migrationBuilder.DropIndex(
                name: "IX_SAIDA_IDMERCADORIA",
                table: "SAIDA");

            migrationBuilder.DropIndex(
                name: "IX_MERCADORIA_IDENTRADA",
                table: "MERCADORIA");

            migrationBuilder.DropColumn(
                name: "IdSaida",
                table: "MERCADORIA");

            migrationBuilder.AddColumn<Guid>(
                name: "EntradaIdEntrada",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SAIDA_IDMERCADORIA",
                table: "SAIDA",
                column: "IDMERCADORIA");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_ENTRADA_EntradaIdEntrada",
                table: "MERCADORIA");

            migrationBuilder.DropIndex(
                name: "IX_SAIDA_IDMERCADORIA",
                table: "SAIDA");

            migrationBuilder.DropIndex(
                name: "IX_MERCADORIA_EntradaIdEntrada",
                table: "MERCADORIA");

            migrationBuilder.DropColumn(
                name: "EntradaIdEntrada",
                table: "MERCADORIA");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSaida",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SAIDA_IDMERCADORIA",
                table: "SAIDA",
                column: "IDMERCADORIA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MERCADORIA_IDENTRADA",
                table: "MERCADORIA",
                column: "IDENTRADA");

            migrationBuilder.AddForeignKey(
                name: "FK_MERCADORIA_ENTRADA_IDENTRADA",
                table: "MERCADORIA",
                column: "IDENTRADA",
                principalTable: "ENTRADA",
                principalColumn: "IDENTRADA");
        }
    }
}
