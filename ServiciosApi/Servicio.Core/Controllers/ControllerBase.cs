using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Shared;

namespace Servicio.Core.Controllers
{
    public abstract class ControllerBase<T> : ControllerBase where T : class
    {
        [HttpPost]
        public virtual async Task<IActionResult> PostCreate([FromBody] T record)
        {
            ServicesContext._context.Set<T>().Add(record);
            await ServicesContext._context.SaveChangesAsync();
            return Ok(record);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            T entityToDelete = ServicesContext._context.Set<T>().Find(id);
            if(entityToDelete != null)
            {
                 if (ServicesContext._context.Entry(entityToDelete).State == EntityState.Detached)
                    ServicesContext._context.Set<T>().Attach(entityToDelete);

                ServicesContext._context.Set<T>().Remove(entityToDelete);

                var resultado = await ServicesContext._context.SaveChangesAsync();
                if(resultado == 0)
                    return BadRequest();

                return Ok(id);  
            }
            return Ok(id);    
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetFind(int id)
        {
            T record = await ServicesContext._context.Set<T>().FindAsync(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> Get() 
        {
            List<T> resultado = await ServicesContext._context.Set<T>().ToListAsync();
            return Ok(resultado);
        }

        [HttpPut("")]
        public virtual async Task<IActionResult> PutUpdate([FromBody] T record)
        {
            ServicesContext._context.Set<T>().Attach(record);
            int resultado =  await ServicesContext._context.SaveChangesAsync();
            if (resultado == 0)
                return BadRequest();
            
            return Ok(record);
        }
    }
}