using System.Collections.Generic;
using System.Threading.Tasks;
using IntopaloApi.BusinessLogic.IManagers;
using IntopaloApi.System_for_data_governance;
using Microsoft.AspNetCore.Mvc;

namespace IntopaloApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabasesController : ControllerBase
    {
        IDatabasesManager manager;
        public DatabasesController(IDatabasesManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<Database>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<Database> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<Database> Create(Database database)
        {
            return await manager.CreateAsync(database);
        }

        [HttpPut("{id}")]
        public async Task<Database> Replace(int id, Database database)
        {
            return await manager.ReplaceAsync(id, database);
        }

        [HttpPut("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
