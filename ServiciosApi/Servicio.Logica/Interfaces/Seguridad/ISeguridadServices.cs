using Servicio.Entidad.Models.Seguridad;
using System.Linq;
using System.Collections.Generic;

namespace Servicio.Logica.Interfaces.Seguridad
{
    public interface ISeguridadServices
    {
        
        #region Roles
        void AddRol(Roles entidad);
        void UpdateRol(Roles entidad);
        bool DeleteRol(int id);
        List<Roles> ListarRoles();
        
        #endregion

        #region Permisos
        void AddPermiso(Permisos entidad);
        void UpdatePermiso(Permisos entidad);
        bool DeletePermiso(int id);
        List<Permisos> ListarPermisos();

        #endregion

        #region Usuarios

        void AddUsuario(Usuarios entidad);
        void UpdateUsuario(Usuarios entidad);
        bool DeleteUsuario(int id);
        List<Usuarios> ListarUsuarios();

        #endregion
    }
}