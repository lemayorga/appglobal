using System.Collections.Generic;

namespace Servicio.Entidad.Models.Seguridad
{
    public class Usuarios
    {
        public int cod_usuario { get; set; }
        public string xusuario { get; set; }
        public string xcontrasena { get; set; }
        public IList<UsuariosRoles> UsuariosRoles { get; set; }
    }
}