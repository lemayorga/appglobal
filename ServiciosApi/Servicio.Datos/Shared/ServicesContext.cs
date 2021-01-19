using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Context;

namespace Servicio.Datos.Shared
{
    public class ServicesContext
    {
        private IBDContext context_;
        public BDContext_Npgsql ctx;
        private readonly IDbContextFactory<BDContext_Npgsql> _contextFactory;
        public static BDContext_Npgsql _context { get => new ServicesContext().ctx;   }

        public ServicesContext(IBDContext context)
        {
            this.context_ = context;
            this.ctx = _contextFactory.CreateDbContext();
        }

        public ServicesContext(IDbContextFactory<BDContext_Npgsql> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public ServicesContext()
        {
            this.context_ = _contextFactory.CreateDbContext();
            this.ctx = _contextFactory.CreateDbContext();
        }

    }
}