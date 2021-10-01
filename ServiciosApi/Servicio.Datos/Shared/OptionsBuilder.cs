using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Servicio.Datos.Context;

namespace Servicio.Datos.Shared
{
    public static class OptionsBuilder
    {
        public static IConfigurationRoot configurationBuilder
        {
            get
            {
                var configurationBuilder = new ConfigurationBuilder();
                // var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                // configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();

                return root;
            }
        }


        public static EnumGestor myGestorBD 
        { 
            get => ((EnumGestor) int.Parse(OptionsBuilder.configurationBuilder["MyGestorBD"].ToString()));
        }
    }
}