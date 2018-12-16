using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class StructuredFilesManager: RepositoryManager<StructuredFile>, IStructuredFilesManager
    {
        public StructuredFilesManager(IStructuredFilesRepository repository)
            : base(repository)
        {
        }
       
    }
}
