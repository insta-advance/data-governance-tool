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
    public class TablesController : ControllerBase
    {
        ITablesManager manager;
        public TablesController(ITablesManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<Table>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<Table> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<Table> Create(Table table)
        {
            return await manager.CreateAsync(table);
        }

        [HttpPut("{id}")]
        public async Task<Table> Replace(int id, Table table)
        {
            return await manager.ReplaceAsync(id, table);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
