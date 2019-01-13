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
    public class UnstructuredFilesController : BaseController<UnstructuredFile> 
    {
        public UnstructuredFilesController(IUnstructuredFilesManager manager) : base(manager)
        {
        }
    }
}
