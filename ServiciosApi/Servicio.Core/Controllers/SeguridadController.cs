using Microsoft.AspNetCore.Mvc;
using Servicio.Entidad.Models.Seguridad;
using Servicio.Logica.Interfaces.Seguridad;

namespace Servicio.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguridadController: ControllerBase
    {
        public readonly ISeguridadServices _services;
        public SeguridadController(ISeguridadServices _services) => this._services = _services;

        #region Roles

        [HttpPost("AddRol")]
        public IActionResult AddRol([FromBody] Roles record)
        {
           _services.AddRol(record);
            return Ok(record);
        }

        [HttpPut("UpdateRol")]
        public IActionResult UpdateRol([FromBody] Roles record)
        {
           _services.UpdateRol(record);
            return Ok(record);
        }

        [HttpDelete("DeleteRol/{id}")]
        public IActionResult DeleteRol(int id)
        {
            return Ok(_services.DeleteRol(id));  
        }

        [HttpGet("ListarRoles")]
        public IActionResult ListarRoles() 
        {
            return Ok(_services.ListarRoles());  
        }

        #endregion

        #region Permiso

        [HttpPost("AddPermiso")]
        public IActionResult AddPermiso([FromBody] Permisos record)
        {
           _services.AddPermiso(record);
            return Ok(record);
        }

        [HttpPut("UpdatePermiso")]
        public IActionResult UpdatePermiso([FromBody] Permisos record)
        {
           _services.UpdatePermiso(record);
            return Ok(record);
        }

        [HttpDelete("DeletePermiso/{id}")]
        public IActionResult DeletePermiso(int id)
        {
            return Ok(_services.DeletePermiso(id));  
        }

        [HttpGet("ListarPermisos")]
        public IActionResult ListarPermiso() 
        {
            return Ok(_services.ListarPermisos());  
        }

        #endregion

        #region Usuario

        [HttpPost("AddUsuario")]
        public IActionResult AddUsuario([FromBody]Usuarios record)
        {
           _services.AddUsuario(record);
            return Ok(record);
        }

        [HttpPut("UpdateUsuario")]
        public IActionResult UpdateUsuario([FromBody]Usuarios record)
        {
           _services.UpdateUsuario(record);
            return Ok(record);
        }

        [HttpDelete("DeleteUsuario/{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            return Ok(_services.DeleteUsuario(id));  
        }

        [HttpGet("ListarUsuarios")]
        public IActionResult ListarUsuarios() 
        {
            return Ok(_services.ListarUsuarios());  
        }

        #endregion

    }
}