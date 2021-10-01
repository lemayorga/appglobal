using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Servicio.Datos.Context;

namespace Servicio.Datos.Shared
{
    // public class ServicesContext
    // {
    //     public DbContextBase ctx;
        
    //     private EnumGestor gestorBaseDatos { get =>  ((EnumGestor) int.Parse(configurationBuilder["MyGestorBD"].ToString())); }

    //     public static DbContextBase _context { get => new ServicesContext().ctx;   }

    //     public ServicesContext()
    //     {
    //         this.ctx = new DbContextBase();
    //     }

        // public string ObtenerConexionString()
        // {
        //     string gestorconexion = gestorBaseDatos == EnumGestor.SqlServer ? "Sql" 
        //                       : gestorBaseDatos == EnumGestor.PostgreSql ?  "Npgsql" : "";
                              
        //     return configurationBuilder[$"ConnectionStrings:{gestorconexion}_BDConexion"];
        // }

        // public IConfigurationRoot configurationBuilder
        // {
        //     get
        //     {
        //         var configurationBuilder = new ConfigurationBuilder();
        //         var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        //         configurationBuilder.AddJsonFile(path, false);

        //         var root = configurationBuilder.Build();

        //         return root;
        //     }
        // }


        // public DbContextOptionsBuilder _dbContextOptionsBuilder
        // {
        //     get
        //     {
        //                 var optionsBuilder = new DbContextOptionsBuilder();
        //         string connectionString = string.Empty;
        //         if ((EnumGestor) int.Parse(configurationBuilder["MyGestorBD"].ToString()) == EnumGestor.SqlServer)
        //         {
        //                 connectionString = configurationBuilder.GetConnectionString("Sql_BDConexion");
        //                 optionsBuilder.UseSqlServer(connectionString);

        //         }
        //         else  if ((EnumGestor) int.Parse(configurationBuilder["MyGestorBD"].ToString()) == EnumGestor.PostgreSql)
        //         {
        //                 connectionString = configurationBuilder.GetConnectionString("Npgsql_BDConexion");
        //                 optionsBuilder.UseNpgsql(connectionString);
        //         }

        //           return optionsBuilder;
        //     }
        // }
    // }
}