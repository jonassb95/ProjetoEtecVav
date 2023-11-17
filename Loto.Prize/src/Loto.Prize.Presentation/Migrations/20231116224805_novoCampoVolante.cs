using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loto.Prize.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class novoCampoVolante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeParticipante",
                table: "Volante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeParticipante",
                table: "Volante");
        }
    }
}
