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

        /// <summary>Get a list of relationships between an annotation and entities.</summary>
        /// <example>User wants to know all entities annotated with an annotation.</example>
        /// <param name="id">Id of the annotation.</param>
        /// <returns>JSON containing an array of Annotation-Base relationships.</returns>
        [HttpGet("annotation/{id}")]
        public async Task<IEnumerable<AnnotationBase>> FromIdList(int id)
        {
            return await manager.Filter(k => k.AnnotationId == id);
        }

        /// <summary>Get a list of relationships between an entitiy and annotations.</summary>
        /// <example>User wants to know all annotations made to an entity.</example>
        /// <param name="id">Id of the entity.</param>
        /// <returns>JSON containing an array of Annotation-Base relationships.</returns>
        [HttpGet("Base/{id}")]
        public async Task<IEnumerable<AnnotationBase>> ToIdList(int id)
        {
            return await manager.Filter(k => k.BaseId == id);
        }
    }
}
