using System.Collections.Generic;

namespace Servicio.Entidad.Models.Seguridad
{
    public class Permisos
    {
        public int cod_permiso { get; set; }
        public string permiso { get; set; } 
        public char cod_estado { get; set; }
        public int? cod_padre_permiso { get; set; }
        public int orden { get; set; }
        public string icono { get; set; }
        public string url_permiso { get; set; }
        public IList<RolesPermisos> RolesPermisos { get; set; }
    }
}