using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Core.Controllers.seguridad
{
   [ApiController]
   [Route("api/seguridad/[controller]")]
   public class RolController : ControllerBaseeApp<Roles>
   {
        public RolController(IBaseRepository<Roles> repo) : base(repo)
        {
        }
    }
}