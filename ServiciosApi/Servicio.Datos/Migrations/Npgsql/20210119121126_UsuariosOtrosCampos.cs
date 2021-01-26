using Microsoft.EntityFrameworkCore.Migrations;

namespace Servicio.Datos.Migrations.Npgsql
{
    public partial class UsuariosOtrosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "apellidos",
                schema: "Seguridad",
                table: "Usuarios",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "correo",
                schema: "Seguridad",
                table: "Usuarios",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "esActivo",
                schema: "Seguridad",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "nombres",
                schema: "Seguridad",
                table: "Usuarios",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apellidos",
                schema: "Seguridad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "correo",
                schema: "Seguridad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "esActivo",
                schema: "Seguridad",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "nombres",
                schema: "Seguridad",
                table: "Usuarios");
        }
    }
}
