using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.Datos.Repository;

namespace Servicio.Core.Controllers
{
    public abstract class ControllerBaseAppMapperRepo<TEntity, TAdd, TUpdate, TGetAll, TGetOne> : ControllerBase  
            where TEntity : class
            where TAdd : class
            where TUpdate : class
            where TGetAll : class
            where TGetOne : class
    {
        protected  IBaseRepository<TEntity> repo;
        private readonly IMapper mapper;
        
        public ControllerBaseAppMapperRepo(IBaseRepository<TEntity> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;

        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Get() 
        {
            var resultEntity = await repo.GetAsync();
            var resultado =  CreateMapper<TEntity, TGetAll>().Map<List<TGetAll>>(resultEntity);
            return Ok(resultado);
        }  

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Get(object id)
        {
            TEntity resultEntity = await repo.FindAsync(id);
            if (resultEntity == null)
                return NotFound();

            var resultado = CreateMapper<TEntity, TGetOne>().Map<TEntity,TGetOne>(resultEntity);
            return Ok(resultado);
        }

        [HttpGet("Limit/{skip}/{take}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Get(int skip, int take) 
        {
            var resultEntity = await repo.GetAsync(skip, take);
            var resultado =  CreateMapper<TEntity, TGetAll>().Map<List<TGetAll>>(resultEntity);
            return Ok(resultado);
        }  

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Post([FromBody] TAdd record)
        {
            var resultEntity = CreateMapper<TAdd, TEntity>().Map<TAdd,TEntity>(record);
            var resultado = await repo.AddEntityAsync(resultEntity);
            return Ok(resultEntity);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Put([FromBody] TUpdate record)
        {
            var resultEntity = CreateMapper<TUpdate, TEntity>().Map<TUpdate,TEntity>(record);
            var resultado =  await repo.UpdateEntityAsync(resultEntity);
            return Ok(resultEntity);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public virtual async Task<IActionResult> Delete(int id)
        {
            TEntity entityToDelete = await repo.FindAsync(id);
            if(entityToDelete != null)
            {
                var resultado = await repo.RemoveEntityAsync(entityToDelete);
                if(!resultado)
                    return BadRequest();

                return Ok(resultado);  
            }
            return Ok(false);    
        }


        private IMapper CreateMapper<TEnt, TDto>() 
            where TEnt : class
            where TDto : class
        {
            var configMapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<TEnt, TDto>();
            });

            return configMapper.CreateMapper();
        }
    }
} 