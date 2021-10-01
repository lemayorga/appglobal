using System;
using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Seeds;
using Servicio.Entidad.Models.Comun;
using Servicio.Entidad.Models.Seguridad;
using Servicio.Datos.Shared;

namespace Servicio.Datos.Context
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            SeedInitialize.Seed(modelBuilder);
        }
          

        #region  Comun

        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }

        #endregion

        #region  Seguridad

        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesPermisos> RolesPermisos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }

        #endregion
    }
}