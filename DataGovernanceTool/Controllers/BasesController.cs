using System;
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
    public class BasesController : BaseController<Base> 
    {
        public BasesController(IBasesManager manager) : base(manager)
        {
        }

        /// <summary>Get the type of an entity.</summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>Error message if classification fails.</returns>
        [HttpGet("GetType/{id}")]
        public async Task<Object> GetType(int id)
        {
            return new { Type = await manager.GetType(id) };
        }
    }
}