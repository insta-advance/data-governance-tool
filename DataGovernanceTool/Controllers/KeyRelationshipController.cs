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
    public class KeyRelationshipsController : BaseController<KeyRelationship> 
    {
        public KeyRelationshipsController(IKeyRelationshipsManager manager) : base(manager)
        {
        }

        [HttpGet("{id1}/{id2}")]
        public async Task<KeyRelationship> GetComposite(int id1, int id2)
        {
            return await manager.FindAsync(id1, id2);
        }

        [HttpGet("from/{id}")]
        public async Task<IEnumerable<KeyRelationship>> FromIdList(int id)
        {
            return await manager.Filter(k => k.FromId == id);
        }

        [HttpGet("to/{id}")]
        public async Task<IEnumerable<KeyRelationship>> ToIdList(int id)
        {
            return await manager.Filter(k => k.ToId == id);
        }
    }
}