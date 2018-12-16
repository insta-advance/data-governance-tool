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
    public class StructuredFilesController : ControllerBase
    {
        IStructuredFilesManager manager;
        public StructuredFilesController(IStructuredFilesManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<StructuredFile>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<StructuredFile> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<StructuredFile> Create(StructuredFile structuredFile)
        {
            return await manager.CreateAsync(structuredFile);
        }

        [HttpPut("{id}")]
        public async Task<StructuredFile> Replace(int id, StructuredFile structuredFile)
        {
            return await manager.ReplaceAsync(id, structuredFile);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
