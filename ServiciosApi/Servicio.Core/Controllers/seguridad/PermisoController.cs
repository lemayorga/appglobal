using System;
using Microsoft.AspNetCore.Mvc;
using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Core.Controllers.seguridad
{
   [ApiController]
   [Route("api/seguridad/[controller]")]
   public class PermisoController : ControllerBaseeApp<Permisos>
   {
        public PermisoController(IBaseRepository<Permisos> repo) : base(repo)
        {
        }
    }
}