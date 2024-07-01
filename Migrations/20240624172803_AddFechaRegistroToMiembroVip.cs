using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperChampiniones.Migrations
{
    /// <inheritdoc />
    public partial class AddFechaRegistroToMiembroVip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "FechaRegistro",
            table: "Miembro_Vip",
            type: "TEXT",
            nullable: false,
            defaultValue: "00:00");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Miembro_Vip");
        }
    }
}
