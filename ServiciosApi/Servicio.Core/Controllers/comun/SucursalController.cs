
using System;
using Microsoft.AspNetCore.Mvc;
using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Comun;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Core.Controllers.comun
{
   [ApiController]
   [Route("api/comun/[controller]")]
   public class SucursalController : ControllerBaseApp<Sucursales>
   {
        public SucursalController(IBaseRepository<Sucursales> repo) : base(repo)
        {

        }
    }
}