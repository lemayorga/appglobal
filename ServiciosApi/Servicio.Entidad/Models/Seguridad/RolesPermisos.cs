using System.Collections.Generic;

namespace Servicio.Entidad.Models.Seguridad
{
    public class RolesPermisos
    {
        public int cod_rol_permiso { get; set; }
        public int cod_rol { get; set; }
        public int cod_permiso { get; set; }
        public Roles Rol { get; set; }
        public Permisos Permiso { get; set; }
    }
}