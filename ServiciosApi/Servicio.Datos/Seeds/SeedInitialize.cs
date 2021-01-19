using Microsoft.EntityFrameworkCore;
using Servicio.Entidad.Models.Comun;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Datos.Seeds
{
    public static class SeedInitialize
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            #region Institucion y Sucursales

            modelBuilder.Entity<Institucion>().ToTable("Institucion","Comun").HasKey(entidad => entidad.cod_institucion);
            modelBuilder.Entity<Institucion>(entidad =>
            {
                entidad.Property(propiedad => propiedad.cod_institucion).IsRequired().UseIdentityColumn();
                entidad.Property(propiedad => propiedad.nombre).IsRequired().HasMaxLength(550);
                entidad.Property(propiedad => propiedad.siglas).IsRequired().HasMaxLength(10);
            }); 
            modelBuilder.Entity<Sucursales>().ToTable("Sucursales","Comun").HasKey(entidad => entidad.cod_sucursal);
            modelBuilder.Entity<Sucursales>(entidad =>
            {
                entidad.Property(propiedad => propiedad.cod_sucursal).IsRequired().UseIdentityColumn();
                entidad.Property(propiedad => propiedad.sucursal).IsRequired().HasMaxLength(550);
            });             
              
            modelBuilder.Entity<Sucursales>()
            .HasOne<Institucion>(s => s.Institucion)
            .WithMany(g => g.Surcursales)
            .HasForeignKey(s => s.cod_institucion);

            #endregion

            #region Seguridad

            modelBuilder.Entity<Permisos>().ToTable("Permisos","Seguridad").HasKey(entidad => entidad.cod_permiso);
            modelBuilder.Entity<Roles>().ToTable("Roles","Seguridad").HasKey(entidad => entidad.cod_rol);
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios","Seguridad").HasKey(entidad => entidad.cod_usuario);
            
            modelBuilder.Entity<Permisos>(entidad =>
            {
                entidad.Property(propiedad => propiedad.cod_permiso).IsRequired().UseIdentityColumn();
                entidad.Property(propiedad => propiedad.permiso).IsRequired().HasMaxLength(550);
                entidad.Property(propiedad => propiedad.cod_estado).HasDefaultValue("V").IsRequired().HasMaxLength(1);
                entidad.Property(propiedad => propiedad.icono).HasMaxLength(80);
                entidad.Property(propiedad => propiedad.url_permiso).HasMaxLength(500);
            }); 

            modelBuilder.Entity<Roles>(entidad =>
            {
                entidad.Property(propiedad => propiedad.cod_rol).IsRequired().UseIdentityColumn();
                entidad.Property(propiedad => propiedad.nombre_rol).IsRequired().HasMaxLength(250);
            }); 
            
            modelBuilder.Entity<Usuarios>(entidad =>
            {
                entidad.Property(propiedad => propiedad.cod_usuario).IsRequired().UseIdentityColumn();
                entidad.Property(propiedad => propiedad.xusuario).IsRequired().HasMaxLength(80);
                 entidad.Property(propiedad => propiedad.xcontrasena).IsRequired();
            }); 

            modelBuilder.Entity<RolesPermisos>().ToTable("RolesPermisos","Seguridad")
                        .HasKey(entidad => new {entidad.cod_rol_permiso, entidad.cod_rol, entidad.cod_permiso});
            modelBuilder.Entity<RolesPermisos>().Property(p => p.cod_rol_permiso).IsRequired().UseIdentityColumn(); 
          
            modelBuilder.Entity<UsuariosRoles>().ToTable("UsuariosRoles","Seguridad")
                        .HasKey(entidad => new { entidad.cod_usuario_rol, entidad.cod_rol, entidad.cod_usuario });
            modelBuilder.Entity<UsuariosRoles>().Property(p => p.cod_usuario_rol).IsRequired().UseIdentityColumn(); 
          
            modelBuilder.Entity<RolesPermisos>()
                .HasOne<Roles>(sc => sc.Rol).WithMany(s => s.RolesPermisos)
                .HasForeignKey(sc => sc.cod_rol);

            modelBuilder.Entity<RolesPermisos>()
                .HasOne<Permisos>(sc => sc.Permiso).WithMany(s => s.RolesPermisos)
                .HasForeignKey(sc => sc.cod_permiso);

            modelBuilder.Entity<UsuariosRoles>()
                .HasOne<Roles>(sc => sc.Rol).WithMany(s => s.UsuariosRoles)
                .HasForeignKey(sc => sc.cod_rol);

            modelBuilder.Entity<UsuariosRoles>()
                .HasOne<Usuarios>(sc => sc.Usuario).WithMany(s => s.UsuariosRoles)
                .HasForeignKey(sc => sc.cod_usuario);

            #endregion
        }
    }
}

