using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENTRADA",
                columns: table => new
                {
                    IDENTRADA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    DATAHORA = table.Column<DateTime>(type: "datetime", nullable: false),
                    LOCAL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTRADA", x => x.IDENTRADA);
                });

            migrationBuilder.CreateTable(
                name: "SAIDA",
                columns: table => new
                {
                    IDENTRADA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    DATAHORA = table.Column<DateTime>(type: "datetime", nullable: false),
                    LOCAL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAIDA", x => x.IDENTRADA);
                });

            migrationBuilder.CreateTable(
                name: "MERCADORIA",
                columns: table => new
                {
                    IDMERCADORIA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDENTRADA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSAIDA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    REGISTRO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FABRICANTE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MERCADORIA", x => x.IDMERCADORIA);
                    table.ForeignKey(
                        name: "FK_MERCADORIA_ENTRADA_IDENTRADA",
                        column: x => x.IDENTRADA,
                        principalTable: "ENTRADA",
                        principalColumn: "IDENTRADA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MERCADORIA_SAIDA_IDSAIDA",
                        column: x => x.IDSAIDA,
                        principalTable: "SAIDA",
                        principalColumn: "IDENTRADA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MERCADORIA_IDENTRADA",
                table: "MERCADORIA",
                column: "IDENTRADA");

            migrationBuilder.CreateIndex(
                name: "IX_MERCADORIA_IDSAIDA",
                table: "MERCADORIA",
                column: "IDSAIDA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MERCADORIA");

            migrationBuilder.DropTable(
                name: "ENTRADA");

            migrationBuilder.DropTable(
                name: "SAIDA");
        }
    }
}
