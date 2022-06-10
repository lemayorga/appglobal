using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Servicio.Datos.Shared
{
    public static class OptionsBuilder
    {
        public static IConfigurationRoot configurationBuilder
        {
            get
            {
               // Variable de entorno de ejecucion
               string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
               string currectDirectory = Directory.GetCurrentDirectory();
               Console.WriteLine(currectDirectory);

               if(Directory.Exists($"{currectDirectory}/ServiciosApi/Servicio.Core/"))
                currectDirectory = $"{currectDirectory}/ServiciosApi/Servicio.Core/";

               Console.WriteLine(currectDirectory);
               var configurationBuilder = new ConfigurationBuilder();
                // var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                // configurationBuilder.AddJsonFile(path, false);
                configurationBuilder
                .SetBasePath(currectDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
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