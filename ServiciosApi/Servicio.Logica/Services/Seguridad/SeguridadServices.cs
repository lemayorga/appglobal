using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Seguridad;
using Servicio.Logica.Interfaces.Seguridad;
using Servicio.Datos.Shared;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Servicio.Logica.Services.Seguridad
{
    public class SeguridadServices : ISeguridadServices
    { 
        internal ServicesContext _servicesContext;
        public SeguridadServices() => _servicesContext = new ServicesContext();

        #region Roles

        public void AddRol(Roles entidad)
        {
            _servicesContext.ctx.Roles.AddAsync(entidad);     
        }

        public void UpdateRol(Roles entidad)
        {
            _servicesContext.ctx.Entry(entidad).State = EntityState.Modified;
            _servicesContext.ctx.SaveChanges();
        }

        public bool DeleteRol(int id)
        {
            Roles entidad = _servicesContext.ctx.Roles.Find(id);
            if(entidad != null)
            {
                _servicesContext.ctx.Roles.Remove(entidad);
                return true;
            }
            return false;
        }

        public List<Roles> ListarRoles()
        {
            return  _servicesContext.ctx.Roles.ToList();  
        }

        #endregion
        
        #region Permisos

        public void AddPermiso(Permisos entidad)
        {
            _servicesContext.ctx.Permisos.AddAsync(entidad);     
        }

        public void UpdatePermiso(Permisos entidad)
        {
            _servicesContext.ctx.Entry(entidad).State = EntityState.Modified;
            _servicesContext.ctx.SaveChanges();
        }

        public bool DeletePermiso(int id)
        {
            Permisos entidad = _servicesContext.ctx.Permisos.Find(id);
            if(entidad != null)
            {
                 _servicesContext.ctx.Permisos.Remove(entidad);
                return true;
            }
            return false;
        }

        public List<Permisos> ListarPermisos()
        {
            return  _servicesContext.ctx.Permisos.ToList();  
        }

        #endregion

        #region Usuarios
        
        public void AddUsuario(Usuarios entidad)
        {
            _servicesContext.ctx.Usuarios.AddAsync(entidad);
        }

        public void UpdateUsuario(Usuarios entidad)
        {
            _servicesContext.ctx.Entry(entidad).State = EntityState.Modified;
            _servicesContext.ctx.SaveChanges();
        }

        public bool DeleteUsuario(int id)
        {
            Usuarios entidad = _servicesContext.ctx.Usuarios.Find(id);
            if(entidad != null)
            {
                _servicesContext.ctx.Usuarios.Remove(entidad);
                return true;
            }
            return false;
        }

        public List<Usuarios> ListarUsuarios()
        {
            return  _servicesContext.ctx.Usuarios.ToList();  
        }

        #endregion
    }
}