using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool;
using Microsoft.AspNetCore.Mvc;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace DataGovernanceTool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeyRelationshipsController : ControllerBase
    {
        IKeyRelationshipsManager manager;
        public KeyRelationshipsController(IKeyRelationshipsManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<KeyRelationship>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<KeyRelationship> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<KeyRelationship> Create(KeyRelationship keyRelationship)
        {
            return await manager.CreateAsync(keyRelationship);
        }

        [HttpPut("{id}")]
        public async Task<KeyRelationship> Replace(int id, KeyRelationship keyRelationship)
        {
            return await manager.ReplaceAsync(id, keyRelationship);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}