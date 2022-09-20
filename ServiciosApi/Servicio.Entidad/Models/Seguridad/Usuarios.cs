using System;
using System.Collections.Generic;

using Servicio.Entidad.Helpers;
using Servicio.Entidad.interfaces;

namespace Servicio.Entidad.Models.Seguridad
{
    public class Usuarios   : IEntity
    {

        #region Propiedades_privadas


        // [NotMapped]
        private string _xcontrasena { get; set; }

        #endregion

        public Guid cod_usuario { get; set; }
        public string xusuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string xcontrasena { get => PasswordHasher.HashPasswordV3(_xcontrasena); set =>  _xcontrasena = value; }
        public string correo { get; set; }
        public bool esActivo { get; set; }
        public IList<UsuariosRoles> UsuariosRoles { get; set; }
    }
}

