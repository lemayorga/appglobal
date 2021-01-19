using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Servicio.Entidad.Helpers;
namespace Servicio.Entidad.Models.Seguridad
{
    public class Usuarios 
    {
        public Usuarios() => _passwordHasher = new PasswordHasher();

        #region Propiedades_privadas

        // [NotMapped]
        private PasswordHasher _passwordHasher{ get; set;}

        // [NotMapped]
        private string _xcontrasena { get; set; }

        #endregion

        public int cod_usuario { get; set; }
        public string xusuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string xcontrasena { get => _passwordHasher.MD5(_xcontrasena); set =>  _xcontrasena = value; }
        public string correo { get; set; }
        public bool esActivo { get; set; }
        public IList<UsuariosRoles> UsuariosRoles { get; set; }
    }
}