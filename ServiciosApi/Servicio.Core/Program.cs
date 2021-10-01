using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace Servicio.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigConfiguration();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


       static void ConfigConfiguration()
        {
           // Variable de entorno de ejecucion
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

           // Creando objeto de configuracion para lectura de archivo json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

        }
    }
}
