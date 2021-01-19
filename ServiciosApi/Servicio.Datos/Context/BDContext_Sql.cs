using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Seeds;
using Servicio.Entidad.Models.Comun;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Datos.Context
{
    public partial class BDContext_Sql : DbContext , IBDContext
    {
        private readonly string _connectionString;
        public BDContext_Sql(DbContextOptions<BDContext_Sql> options): base(options) {}
        public BDContext_Sql(string connectionString) : base(GetOptions(connectionString)) =>  
                _connectionString = connectionString; 
        private static DbContextOptions GetOptions(string connectionString) => 
                SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
                SeedInitialize.Seed(modelBuilder);   
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesPermisos> RolesPermisos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }
    }
}