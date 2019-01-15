using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool;
using Microsoft.AspNetCore.Mvc;
using DataGovernanceTool.Data.Models.Metadata;

namespace DataGovernanceTool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnotationBasesController : BaseController<AnnotationBase> 
    {
        public AnnotationBasesController(IAnnotationBasesManager manager) : base(manager)
        {
        }

        [HttpGet("annotation/{id}")]
        public async Task<IEnumerable<AnnotationBase>> FromIdList(int id)
        {
            return await manager.Filter(k => k.AnnotationId == id);
        }

        [HttpGet("Base/{id}")]
        public async Task<IEnumerable<AnnotationBase>> ToIdList(int id)
        {
            return await manager.Filter(k => k.BaseId == id);
        }
    }
}
