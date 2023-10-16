using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loto.Prize.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterandoCampoRequirido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdJogo",
                table: "Volante",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdJogo",
                table: "Volante");
        }
    }
}
