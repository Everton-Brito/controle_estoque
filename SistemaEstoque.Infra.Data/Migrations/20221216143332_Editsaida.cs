using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Editsaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_SAIDA_IDSAIDA",
                table: "MERCADORIA");

            migrationBuilder.DropIndex(
                name: "IX_MERCADORIA_IDSAIDA",
                table: "MERCADORIA");

            migrationBuilder.RenameColumn(
                name: "IDSAIDA",
                table: "MERCADORIA",
                newName: "IdSaida");

            migrationBuilder.AddColumn<Guid>(
                name: "IDMERCADORIA",
                table: "SAIDA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "ENTRADA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SAIDA_IDMERCADORIA",
                table: "SAIDA",
                column: "IDMERCADORIA",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SAIDA_MERCADORIA_IDMERCADORIA",
                table: "SAIDA",
                column: "IDMERCADORIA",
                principalTable: "MERCADORIA",
                principalColumn: "IDMERCADORIA",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SAIDA_MERCADORIA_IDMERCADORIA",
                table: "SAIDA");

            migrationBuilder.DropIndex(
                name: "IX_SAIDA_IDMERCADORIA",
                table: "SAIDA");

            migrationBuilder.DropColumn(
                name: "IDMERCADORIA",
                table: "SAIDA");

            migrationBuilder.RenameColumn(
                name: "IdSaida",
                table: "MERCADORIA",
                newName: "IDSAIDA");

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "ENTRADA",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MERCADORIA_IDSAIDA",
                table: "MERCADORIA",
                column: "IDSAIDA");

            migrationBuilder.AddForeignKey(
                name: "FK_MERCADORIA_SAIDA_IDSAIDA",
                table: "MERCADORIA",
                column: "IDSAIDA",
                principalTable: "SAIDA",
                principalColumn: "IDENTRADA");
        }
    }
}
