using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class CompositeKeysManager: RepositoryManager<CompositeKey>, ICompositeKeysManager
    {
        public CompositeKeysManager(ICompositeKeysRepository repository)
            : base(repository)
        {
        }
    }
}