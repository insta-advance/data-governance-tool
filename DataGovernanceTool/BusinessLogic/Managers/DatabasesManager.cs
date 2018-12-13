using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class DatabasesManager: RepositoryManager<Database>, IDatabasesManager
    {
        public DatabasesManager(IDatabasesRepository repository)
            : base(repository)
        {
        }
    }
}
