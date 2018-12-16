using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class CollectionsManager: RepositoryManager<Collection>, ICollectionsManager
    {
        public CollectionsManager(ICollectionsRepository repository)
            : base(repository)
        {
        }
       
    }
}
