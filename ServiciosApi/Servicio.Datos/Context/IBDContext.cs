using Microsoft.EntityFrameworkCore;
using Servicio.Entidad.Models.Comun;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Datos.Context
{
    public interface IBDContext
    {
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesPermisos> RolesPermisos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }
    }
}