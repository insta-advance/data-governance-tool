using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class TablesManager: RepositoryManager<Table>, ITablesManager
    {
        public TablesManager(ITablesRepository repository)
            : base(repository)
        {
        }
       
    }
}
