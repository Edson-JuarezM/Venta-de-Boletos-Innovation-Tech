using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperChampiniones.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlEscudB",
                table: "Partido",
                newName: "UrlEscudoB");

            migrationBuilder.RenameColumn(
                name: "UrlEscudA",
                table: "Partido",
                newName: "UrlEscudoA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlEscudoB",
                table: "Partido",
                newName: "UrlEscudB");

            migrationBuilder.RenameColumn(
                name: "UrlEscudoA",
                table: "Partido",
                newName: "UrlEscudA");
        }
    }
}
