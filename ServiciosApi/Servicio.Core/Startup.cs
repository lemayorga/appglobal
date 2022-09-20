using System.Collections.Specialized;
using System.Text;
using System;
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
using Servicio.Core.Config;
using Servicio.Logica;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Certificate;

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
                services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
                .AddCertificate();

            List<string> urlOrigins = ReadCurentsIps(Configuration["Origins"] );

            Console.WriteLine($"*** IP permitidas: {String.Join(",",urlOrigins)}");
            Console.WriteLine($"*** Url defecto: https://localhost:5001/home");
            Console.WriteLine($"*** Url Swagger: https://localhost:5001/swagger/index.html");

            services.AddCors(o =>
            {
                o.AddPolicy(name: CorsPolicy, builder =>
                {
                    builder.WithOrigins(urlOrigins.ToArray())
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
            app.UseAuthentication();
            
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

        private List<string> ReadCurentsIps(string configOrings)
        {
            
            List<string> urlOrigins = (configOrings ?? "").Split(new char[]{',',';'}).ToList();
            string currentLocalIPs = Utils.GetCurrentLocalIps();

            if(!string.IsNullOrEmpty(currentLocalIPs) && urlOrigins.Count() > 0)
            {
                urlOrigins ??= new List<string>();
                Uri uri = new Uri(urlOrigins[0]);

                if (!string.IsNullOrEmpty(currentLocalIPs))
                {
                    var arraycurrentLocalIPs = currentLocalIPs.Split(",").ToList();
                    arraycurrentLocalIPs.ForEach(ip =>
                    {
                        var currentLocalIP = $"{uri.Scheme}{Uri.SchemeDelimiter}{ip}:{uri.Port}";
                        Console.WriteLine($"*** Currente local IP web: {ip}");

                       urlOrigins.Add(currentLocalIP);
                    });
                }
            }

            return urlOrigins;
        }
    }
}

