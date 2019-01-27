using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool;
using Microsoft.AspNetCore.Mvc;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : SuperBase
    {
        protected IRepositoryManager<T> manager;
        public BaseController(IRepositoryManager<T> manager)
        {
            this.manager = manager;
        }

        /// <summary>Get a all entities from the controller.</summary>
        /// <returns>JSON containing an array of entites.</returns>
        [HttpGet]
        public async Task<IEnumerable<T>> List()
        {
            return await manager.GetAsync();
        }


        /// <summary>Get single entity by Id.</summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>Json containing an entity.</returns>
        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        /// <summary>Create new entity. Entity is passed as JSON in the POST request.</summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>Error message is returned if creation fails.</returns>
        [HttpPost]
        public async Task<T> Create(T collection)
        {
            return await manager.CreateAsync(collection);
        }

        /// <summary>
        /// Modify existing entity. Entity is passed as JSON in the PUT request.
        /// If a member in the entity is not specified then value of that member is left unchanged.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>Error message is returned modification fails</returns>
        [HttpPut("{id}")]
        public async Task<T> Replace(int id, T collection)
        {
            return await manager.ReplaceAsync(id, collection);
        }

        /// <summary>Delete entity including all related entities.</summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>Error message if delete fails.</returns>
        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
