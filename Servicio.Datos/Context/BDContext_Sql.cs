using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Seeds;

namespace Servicio.Datos.Context
{
    public class BDContext_Sql : DbContext
    {
        private readonly string _connectionString;
        public BDContext_Sql(DbContextOptions<BDContext_Sql> options): base(options) {}
        public BDContext_Sql(string connectionString) : base(GetOptions(connectionString)) { _connectionString = connectionString; }
        private static DbContextOptions GetOptions(string connectionString) => 
                SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
                SeedInitialize.Seed(modelBuilder);   
    }
}