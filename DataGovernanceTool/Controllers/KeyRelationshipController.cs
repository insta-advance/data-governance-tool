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

        /// <summary>Get a key relationship between entities.</summary>
        /// <param name="id1">Id of the entity.</param>
        /// <param name="id2">Id of the entity.</param>
        /// <returns>JSON containing a Keyrelationship. Error if Id pair is not found.</returns>
        [HttpGet("{id1}/{id2}")]
        public async Task<KeyRelationship> GetComposite(int id1, int id2)
        {
            return await manager.FindAsync(id1, id2);
        }

        /// <summary>Get all key relationships where given entity is or acts as an primary key.</summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>JSON containing a list of Keyrelationships. Error if Id pair is not found.</returns>
        [HttpGet("from/{id}")]
        public async Task<IEnumerable<KeyRelationship>> FromIdList(int id)
        {
            return await manager.Filter(k => k.FromId == id);
        }

        /// <summary>Get all key relationships where given entity is or acts as an foreign key.</summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>JSON containing a list of Keyrelationships. Error if Id pair is not found.</returns>
        [HttpGet("to/{id}")]
        public async Task<IEnumerable<KeyRelationship>> ToIdList(int id)
        {
            return await manager.Filter(k => k.ToId == id);
        }
    }
}