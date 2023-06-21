using Servicio.Datos.Context;
using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Seguridad;
using Servicio.Logica.Interface.Seguridad;

namespace Servicio.Logica.Implements.Seguridad;
public class RolRepository : BaseRepository<Roles>, IRolRepository {
    private readonly ApplicationDbContext db;
    public RolRepository (ApplicationDbContext context) : base (context) 
    {
        db = context;
    }

}