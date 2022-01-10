using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Servicio.Datos.Context;
using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Repository;
using Servicio.Datos.Shared;
using System.Reflection;
using Servicio.Core.Config;
using System.IO;

namespace Servicio.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {            
            Configuration = configuration;
            Configuration = OptionsBuilder.configurationBuilder;  //ConfigConfiguration();
        }

        readonly string CorsPolicy = "_corsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string[] urlOrigins = (Configuration["Origins"] ?? "").Split(new char[]{',',';'});
            Console.WriteLine($"IP permitidas: {String.Join(",",urlOrigins)}");

            services.AddCors(o =>
            {
                o.AddPolicy(name: CorsPolicy, builder =>
                {
                    builder.WithOrigins(urlOrigins)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials()
                                    .Build();
                });
            }); 

            services.AddControllers();  
            SwaggerConfig.ConfigureServices(services);
            DatabaseConfig.ConfigureServices(services, Configuration);

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        
            SwaggerConfig.Configure(app, env);
            app.UseHttpsRedirection();

            app.UseCors(CorsPolicy);

            app.UseRouting();
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        
        // IConfigurationRoot ConfigConfiguration()
        // {
        //    // Variable de entorno de ejecucion
        //     string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        //     string currectDirectory = Directory.GetCurrentDirectory();
        //     Console.WriteLine(currectDirectory);

        //     if(Directory.Exists($"{currectDirectory}/ServiciosApi/Servicio.Core/"))
        //         currectDirectory = $"{currectDirectory}/ServiciosApi/Servicio.Core/";

        //     Console.WriteLine(currectDirectory);

        //    // Creando objeto de configuracion para lectura de archivo json
        //     IConfigurationRoot configuration = new ConfigurationBuilder()
        //         .SetBasePath(currectDirectory)
        //         .AddJsonFile("appsettings.json", optional:false, reloadOnChange: true)
        //         .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
        //         .AddEnvironmentVariables()
        //         .Build();

        //     return configuration;
        // }
    }
}

