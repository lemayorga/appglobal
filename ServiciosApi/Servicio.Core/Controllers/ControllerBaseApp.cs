using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.Datos.Repository;

namespace Servicio.Core.Controllers
{
    [ApiController]
    public abstract class ControllerBaseApp<T> : ControllerBase where T : class
    {
        protected  IBaseRepository<T> repo;

        public ControllerBaseApp(IBaseRepository<T> repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> PostCreate([FromBody] T record)
        {
            var resultado = await repo.AddEntityAsync(record);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Delete(int id)
        {
            T entityToDelete = await repo.FindAsync(id);
            if(entityToDelete != null)
            {
                var resultado = await repo.RemoveEntityAsync(entityToDelete);
                if(!resultado)
                    return BadRequest();

                return Ok(resultado);  
            }
            return Ok(false);    
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> GetFind(int id)
        {
            T record = await repo.FindAsync(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Get() 
        {
            var resultado = await repo.GetAsync();
            return Ok(resultado);
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> PutUpdate([FromBody] T record)
        {
            var resultado =  await repo.UpdateEntityAsync(record);
            return Ok(resultado);
        }
    }
}