using Servicio.Datos.Context;
using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Seguridad;
using Servicio.Logica.Interface.Seguridad;

namespace Servicio.Logica.Implements.Seguridad;
public class UsuariosRepository : BaseRepository<Usuarios>, IUsuariosRepository {
    private readonly ApplicationDbContext db;
    public UsuariosRepository (ApplicationDbContext context) : base (context) 
    {
        db = context;
    }

}