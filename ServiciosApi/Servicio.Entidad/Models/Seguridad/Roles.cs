using System.Collections.Generic;
using Servicio.Entidad.interfaces;

namespace Servicio.Entidad.Models.Seguridad
{
    public class Roles : IEntity
    {
        public int cod_rol { get; set; }
        public string nombre { get; set; }
        public IList<RolesPermisos> RolesPermisos { get; set; }
        public IList<UsuariosRoles> UsuariosRoles { get; set; }
    }
}