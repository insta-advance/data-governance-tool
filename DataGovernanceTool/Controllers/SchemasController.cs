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
    public class SchemasController : ControllerBase
    {
        ISchemasManager manager;
        public SchemasController(ISchemasManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<Schema>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<Schema> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<Schema> Create(Schema schema)
        {
            return await manager.CreateAsync(schema);
        }

        [HttpPut("{id}")]
        public async Task<Schema> Replace(int id, Schema schema)
        {
            return await manager.ReplaceAsync(id, schema);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
