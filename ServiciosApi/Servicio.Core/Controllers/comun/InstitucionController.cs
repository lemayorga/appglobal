using System;
using Microsoft.AspNetCore.Mvc;
using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Comun;

namespace Servicio.Core.Controllers.comun
{
   [ApiController]
   [Route("api/comun/[controller]")]
   public class InstitucionController : ControllerBaseApp<Institucion>
   {
        public InstitucionController(IBaseRepository<Institucion> repo) : base(repo)
        {

        }
    }
}