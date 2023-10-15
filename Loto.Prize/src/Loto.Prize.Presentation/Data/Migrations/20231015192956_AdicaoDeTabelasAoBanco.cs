using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loto.Prize.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDeTabelasAoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalNumero = table.Column<int>(type: "int", nullable: false),
                    QuantidadeNumeroSelecao = table.Column<int>(type: "int", nullable: false),
                    NumerosSorteados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Premio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    NumerosEscolhidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVolante = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volante", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogo");

            migrationBuilder.DropTable(
                name: "Volante");
        }
    }
}
