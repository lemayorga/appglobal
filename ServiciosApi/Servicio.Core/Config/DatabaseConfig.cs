using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Servicio.Datos.Context;
using Servicio.Datos.Shared;

namespace Servicio.Core.Config
{
    public class DatabaseConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            switch (OptionsBuilder.myGestorBD)
            {
                case  EnumGestor.SqlServer:
                      services.AddDbContext<ApplicationDbContext>(options => 
                             options.UseSqlServer(connectionString: Configuration.GetConnectionString("Sql_BDConexion") ));  
                break;
                case  EnumGestor.PostgreSql:
                 services.AddDbContext<ApplicationDbContext>(options => 
                        options.UseNpgsql(connectionString: Configuration.GetConnectionString("Npgsql_BDConexion")));  
                break;
            }
        }
    }
}