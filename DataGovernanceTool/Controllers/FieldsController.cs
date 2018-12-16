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
    public class FieldsController : ControllerBase
    {
        IFieldsManager manager;
        public FieldsController(IFieldsManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public async Task<IEnumerable<Field>> List(int id)
        {
            return await manager.GetAsync();
        }


        [HttpGet("{id}")]
        public async Task<Field> GetById(int id)
        {
            return await manager.GetAsync(id);
        }

        [HttpPost]
        public async Task<Field> Create(Field field)
        {
            return await manager.CreateAsync(field);
        }

        [HttpPut("{id}")]
        public async Task<Field> Replace(int id, Field field)
        {
            return await manager.ReplaceAsync(id, field);
        }

        [HttpDelete("{id}")]
        public async Task Replace(int id)
        {
            await manager.DeleteAsync(id);
        }
    }
}
