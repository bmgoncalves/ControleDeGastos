using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeGastos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class EntryStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Entries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Entries");
        }
    }
}
