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
    public class DatastoresController : ControllerBase
    {
        IDatastoresManager manager;
        public DatastoresController(IDatastoresManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<Datastore>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<Datastore> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<Datastore> Create(Datastore datastore)
        {
            return await manager.CreateAsync(datastore);
        }

        [HttpPut("{id}")]
        public async Task<Datastore> Replace(int id, Datastore datastore)
        {
            return await manager.ReplaceAsync(id, datastore);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
