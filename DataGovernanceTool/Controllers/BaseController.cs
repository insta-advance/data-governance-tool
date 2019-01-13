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

        [HttpGet]
        public async Task<IEnumerable<T>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<T> Create(T collection)
        {
            return await manager.CreateAsync(collection);
        }

        [HttpPut("{id}")]
        public async Task<T> Replace(int id, T collection)
        {
            return await manager.ReplaceAsync(id, collection);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
