using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool;
using Microsoft.AspNetCore.Mvc;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace DataGovernanceTool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompositeKeysController : BaseController<CompositeKey> 
    {
        public CompositeKeysController(ICompositeKeysManager manager) : base(manager)
        {
        }
    }
}
