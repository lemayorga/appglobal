using System.Collections.Generic;

namespace Servicio.Entidad.Models.Seguridad
{
    public class Roles
    {
        public int cod_rol { get; set; }
        public int nombre_rol { get; set; }
        public IList<RolesPermisos> RolesPermisos { get; set; }
        public IList<UsuariosRoles> UsuariosRoles { get; set; }
    }
}