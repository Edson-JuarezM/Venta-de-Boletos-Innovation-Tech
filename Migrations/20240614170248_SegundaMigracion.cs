using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperChampiniones.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Ventas",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Miembro_VipId",
                table: "Ventas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mimbro_VipId",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartidoId",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sector",
                table: "Ventas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Miembro_Vip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Ci = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Celular = table.Column<int>(type: "INTEGER", nullable: false),
                    Saldo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembro_Vip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipoA = table.Column<string>(type: "TEXT", nullable: false),
                    EquipoB = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha_Hora = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UrlEscudA = table.Column<string>(type: "TEXT", nullable: true),
                    UrlEscudB = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Miembro_VipId",
                table: "Ventas",
                column: "Miembro_VipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_PartidoId",
                table: "Ventas",
                column: "PartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Miembro_Vip_Miembro_VipId",
                table: "Ventas",
                column: "Miembro_VipId",
                principalTable: "Miembro_Vip",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Partido_PartidoId",
                table: "Ventas",
                column: "PartidoId",
                principalTable: "Partido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Miembro_Vip_Miembro_VipId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Partido_PartidoId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Miembro_Vip");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_Miembro_VipId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_PartidoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Miembro_VipId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Mimbro_VipId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "PartidoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
