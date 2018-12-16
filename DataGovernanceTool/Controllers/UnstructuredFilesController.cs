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
    public class UnstructuredFilesController : ControllerBase
    {
        IUnstructuredFilesManager manager;
        public UnstructuredFilesController(IUnstructuredFilesManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<UnstructuredFile>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<UnstructuredFile> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<UnstructuredFile> Create(UnstructuredFile unstructuredFile)
        {
            return await manager.CreateAsync(unstructuredFile);
        }

        [HttpPut("{id}")]
        public async Task<UnstructuredFile> Replace(int id, UnstructuredFile unstructuredFile)
        {
            return await manager.ReplaceAsync(id, unstructuredFile);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
