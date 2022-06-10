using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Servicio.Datos.Context;
using Servicio.Datos.Shared;
using System;

namespace Servicio.Core.Config
{
    public class DatabaseConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            string conexion = string.Empty;
            Console.WriteLine("");
            Console.WriteLine($"*** Gestor de base de datos: {OptionsBuilder.myGestorBD.ToString()}");
            Console.WriteLine("");
            switch (OptionsBuilder.myGestorBD)
            {
                case  EnumGestor.SqlServer:
                      services.AddDbContext<ApplicationDbContext>(options => 
                             options.UseSqlServer(connectionString: Configuration.GetConnectionString("Sql_BDConexion") ));

                       conexion = Configuration.GetConnectionString("Sql_BDConexion");
                break;
                case  EnumGestor.PostgreSql:
                 services.AddDbContext<ApplicationDbContext>(options => 
                        options.UseNpgsql(connectionString: Configuration.GetConnectionString("Npgsql_BDConexion")));

                        conexion = Configuration.GetConnectionString("Npgsql_BDConexion");
                break;
            }
            Console.WriteLine("");
            Console.WriteLine($"-------------------------------------------------------------------------------");
            Console.WriteLine($"*** Conexion de base de datos: {conexion}");
            Console.WriteLine($"-------------------------------------------------------------------------------");
            Console.WriteLine("");
        }
    }
}