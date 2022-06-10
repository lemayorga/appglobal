using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Servicio.Datos.Repository;
using Servicio.Entidad.Dtos.Seguridad.Rol;
using Servicio.Entidad.Models.Seguridad;

namespace Servicio.Core.Controllers.seguridad
{
   [ApiController]
   [Route("api/seguridad/[controller]")]
   public class RolController : ControllerBaseAppMapper<Roles, RolAddDto, RolUpdateDto, RolGetDto, RolGetDto>
   {
        public RolController(IBaseRepository<Roles> repo,IMapper mapper) : base(repo, mapper)
        {
           
        }
    }
}