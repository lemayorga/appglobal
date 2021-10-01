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

namespace Servicio.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {            
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
    
            services.AddControllers();
            SwaggerConfig.ConfigureServices(services);

            switch (OptionsBuilder.myGestorBD)
            {
                case  EnumGestor.SqlServer:
                      services.AddDbContext<ApplicationDbContext>(options => 
                             options.UseSqlServer(Configuration.GetConnectionString("Sql_BDConexion") ));  
                break;
                case  EnumGestor.PostgreSql:
                 services.AddDbContext<ApplicationDbContext>(options => 
                        options.UseNpgsql(Configuration.GetConnectionString("Npgsql_BDConexion")));  
                break;
            }

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


           // https://stackoverflow.com/questions/33566075/generic-repository-in-asp-net-core-without-having-a-separate-addscoped-line-per

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapAreaControllerRoute(
                //     name: "areas",
                //     "areas",
                //     pattern: "{area}/{controller=Default}/{action=Index}/{id?}"
                // );
                endpoints.MapControllers();
            });
        }
    }
}
