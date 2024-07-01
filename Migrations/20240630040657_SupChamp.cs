using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperChampiniones.Migrations
{
    /// <inheritdoc />
    public partial class SupChamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mimbro_VipId",
                table: "Ventas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mimbro_VipId",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
