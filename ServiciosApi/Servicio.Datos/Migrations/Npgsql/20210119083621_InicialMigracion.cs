using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Servicio.Datos.Migrations.Npgsql
{
    public partial class InicialMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Comun");

            migrationBuilder.CreateTable(
                name: "Institucion",
                schema: "Comun",
                columns: table => new
                {
                    cod_institucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(550)", maxLength: 550, nullable: false),
                    siglas = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institucion", x => x.cod_institucion);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                schema: "Comun",
                columns: table => new
                {
                    cod_sucursal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sucursal = table.Column<string>(type: "character varying(550)", maxLength: 550, nullable: false),
                    cod_institucion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.cod_sucursal);
                    table.ForeignKey(
                        name: "FK_Sucursales_Institucion_cod_institucion",
                        column: x => x.cod_institucion,
                        principalSchema: "Comun",
                        principalTable: "Institucion",
                        principalColumn: "cod_institucion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_cod_institucion",
                schema: "Comun",
                table: "Sucursales",
                column: "cod_institucion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursales",
                schema: "Comun");

            migrationBuilder.DropTable(
                name: "Institucion",
                schema: "Comun");
        }
    }
}
