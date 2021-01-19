using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Seeds;

namespace Servicio.Datos.Context
{
    public class BDContext_Npgsql : DbContext
    {
        private readonly string _connectionString;
        public BDContext_Npgsql(DbContextOptions<BDContext_Npgsql> options): base(options) {}
        public BDContext_Npgsql(string connectionString) : base(GetOptions(connectionString)) { _connectionString = connectionString; }
        private static DbContextOptions GetOptions(string connectionString) => 
                SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            SeedInitialize.Seed(modelBuilder);
    }
}