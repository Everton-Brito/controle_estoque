using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Atualizar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_ENTRADA_IDENTRADA",
                table: "MERCADORIA");

            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_SAIDA_IDSAIDA",
                table: "MERCADORIA");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDSAIDA",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDENTRADA",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_MERCADORIA_ENTRADA_IDENTRADA",
                table: "MERCADORIA",
                column: "IDENTRADA",
                principalTable: "ENTRADA",
                principalColumn: "IDENTRADA");

            migrationBuilder.AddForeignKey(
                name: "FK_MERCADORIA_SAIDA_IDSAIDA",
                table: "MERCADORIA",
                column: "IDSAIDA",
                principalTable: "SAIDA",
                principalColumn: "IDENTRADA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_ENTRADA_IDENTRADA",
                table: "MERCADORIA");

            migrationBuilder.DropForeignKey(
                name: "FK_MERCADORIA_SAIDA_IDSAIDA",
                table: "MERCADORIA");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDSAIDA",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IDENTRADA",
                table: "MERCADORIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MERCADORIA_ENTRADA_IDENTRADA",
                table: "MERCADORIA",
                column: "IDENTRADA",
                principalTable: "ENTRADA",
                principalColumn: "IDENTRADA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MERCADORIA_SAIDA_IDSAIDA",
                table: "MERCADORIA",
                column: "IDSAIDA",
                principalTable: "SAIDA",
                principalColumn: "IDENTRADA",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
