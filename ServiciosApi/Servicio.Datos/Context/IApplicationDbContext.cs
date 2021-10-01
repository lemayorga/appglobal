using Microsoft.EntityFrameworkCore;
using Servicio.Entidad.interfaces;
using Servicio.Entidad.Models.Comun;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Datos.Context
{
    public interface IApplicationDbContext  
    {
        DbSet<Institucion> Instituciones { get; set; }
        DbSet<Sucursales> Sucursales { get; set; }
        DbSet<Permisos> Permisos { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<RolesPermisos> RolesPermisos { get; set; }
        DbSet<Usuarios> Usuarios { get; set; }
        DbSet<UsuariosRoles> UsuariosRoles { get; set; }
    }
}