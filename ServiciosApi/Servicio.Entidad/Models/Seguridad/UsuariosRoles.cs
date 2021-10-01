using System;
using Servicio.Entidad.interfaces;

namespace Servicio.Entidad.Models.Seguridad
{
    public class UsuariosRoles  : IEntity
    {
        public int cod_usuario_rol { get; set; }
        public Guid cod_usuario { get; set; }
        public int cod_rol { get; set; }
        public Roles Rol { get; set; }
        public Usuarios Usuario { get; set; }
    }
}