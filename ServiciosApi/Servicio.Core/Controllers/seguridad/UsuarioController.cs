using System;
using Microsoft.AspNetCore.Mvc;
using Servicio.Datos.Repository;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Core.Controllers.seguridad
{
   [ApiController]
   [Route("api/seguridad/[controller]")]
   public class UsuarioController : ControllerBaseApp<Usuarios>
   {
        public UsuarioController(IBaseRepository<Usuarios> repo) : base(repo)
        {
        }
    }
}