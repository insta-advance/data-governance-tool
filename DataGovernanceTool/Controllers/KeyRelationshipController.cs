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

        // [HttpGet("{id}")]
        // public async Task<T> GetById(int id)
        // {
        //     return await manager.GetAsync(id);
        // }

        [HttpGet("from/{id}")]
        public async Task<KeyRelationship> GetByFromId(int id)
        {
            return await manager.GetAsync(id);
        }
    }
}