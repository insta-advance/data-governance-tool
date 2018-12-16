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
    public class CollectionsController : ControllerBase
    {
        ICollectionsManager manager;
        public CollectionsController(ICollectionsManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<Collection>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<Collection> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<Collection> Create(Collection collection)
        {
            return await manager.CreateAsync(collection);
        }

        [HttpPut("{id}")]
        public async Task<Collection> Replace(int id, Collection collection)
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
