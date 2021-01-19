using Microsoft.EntityFrameworkCore;
using Servicio.Entidad.Models.Comun;

namespace Servicio.Datos.Seeds
{
    public static class SeedInitialize
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institucion>().ToTable("Institucion","Comun")
                                              .HasKey(entidad => entidad.cod_institucion);
            modelBuilder.Entity<Institucion>(entidad =>
            {
                entidad.Property(propiedad => propiedad.cod_institucion).IsRequired().UseIdentityColumn();
                entidad.Property(propiedad => propiedad.nombre).IsRequired().HasMaxLength(550);
                entidad.Property(propiedad => propiedad.siglas).IsRequired().HasMaxLength(10);
            });   
        }
    }
}