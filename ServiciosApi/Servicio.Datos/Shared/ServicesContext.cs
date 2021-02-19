using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Servicio.Datos.Context;

namespace Servicio.Datos.Shared
{
    public class ServicesContext
    {
        public BDContext_Npgsql ctx;
        private EnumGestor gestoBaseDatos { get => EnumGestor.PostgreSql;  }
        public static BDContext_Npgsql _context { get => new ServicesContext().ctx;   }
        public ServicesContext()
        {
            this.ctx = new BDContext_Npgsql(ObtenerConexionString());
        }
        private string ObtenerConexionString()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            string gestor_base_datos = gestoBaseDatos == EnumGestor.PostgreSql ? "Npgsql"
                             : gestoBaseDatos == EnumGestor.SqlServer ? "Sql" 
                             : string.Empty;
            var root = configurationBuilder.Build();
            return root[$"ConnectionStrings:{gestor_base_datos}_BDConexion"];
        }

    }
}