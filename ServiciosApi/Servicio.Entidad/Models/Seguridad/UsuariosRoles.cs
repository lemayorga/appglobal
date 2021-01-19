namespace Servicio.Entidad.Models.Seguridad
{
    public class UsuariosRoles
    {
        public int cod_usuario_rol { get; set; }
        public int cod_usuario { get; set; }
        public int cod_rol { get; set; }
        public Roles Rol { get; set; }
        public Usuarios Usuario { get; set; }
    }
}