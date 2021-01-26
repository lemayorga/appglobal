using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Servicio.Datos.Migrations.Npgsql
{
    public partial class SeguridadEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Seguridad");

            migrationBuilder.CreateTable(
                name: "Permisos",
                schema: "Seguridad",
                columns: table => new
                {
                    cod_permiso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permiso = table.Column<string>(type: "character varying(550)", maxLength: 550, nullable: false),
                    cod_estado = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false, defaultValue: 'V'),
                    cod_padre_permiso = table.Column<int>(type: "integer", nullable: true),
                    orden = table.Column<int>(type: "integer", nullable: false),
                    icono = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    url_permiso = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.cod_permiso);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Seguridad",
                columns: table => new
                {
                    cod_rol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre_rol = table.Column<int>(type: "integer", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.cod_rol);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "Seguridad",
                columns: table => new
                {
                    cod_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    xusuario = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    xcontrasena = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.cod_usuario);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermisos",
                schema: "Seguridad",
                columns: table => new
                {
                    cod_rol_permiso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cod_rol = table.Column<int>(type: "integer", nullable: false),
                    cod_permiso = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermisos", x => new { x.cod_rol_permiso, x.cod_rol, x.cod_permiso });
                    table.ForeignKey(
                        name: "FK_RolesPermisos_Permisos_cod_permiso",
                        column: x => x.cod_permiso,
                        principalSchema: "Seguridad",
                        principalTable: "Permisos",
                        principalColumn: "cod_permiso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesPermisos_Roles_cod_rol",
                        column: x => x.cod_rol,
                        principalSchema: "Seguridad",
                        principalTable: "Roles",
                        principalColumn: "cod_rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosRoles",
                schema: "Seguridad",
                columns: table => new
                {
                    cod_usuario_rol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cod_usuario = table.Column<int>(type: "integer", nullable: false),
                    cod_rol = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRoles", x => new { x.cod_usuario_rol, x.cod_rol, x.cod_usuario });
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Roles_cod_rol",
                        column: x => x.cod_rol,
                        principalSchema: "Seguridad",
                        principalTable: "Roles",
                        principalColumn: "cod_rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Usuarios_cod_usuario",
                        column: x => x.cod_usuario,
                        principalSchema: "Seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "cod_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermisos_cod_permiso",
                schema: "Seguridad",
                table: "RolesPermisos",
                column: "cod_permiso");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermisos_cod_rol",
                schema: "Seguridad",
                table: "RolesPermisos",
                column: "cod_rol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_cod_rol",
                schema: "Seguridad",
                table: "UsuariosRoles",
                column: "cod_rol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_cod_usuario",
                schema: "Seguridad",
                table: "UsuariosRoles",
                column: "cod_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesPermisos",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "UsuariosRoles",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Permisos",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "Seguridad");
        }
    }
}
