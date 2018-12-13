using IntopaloApi.Data.Access.IRepositories;
using IntopaloApi.System_for_data_governance;
using IntopaloApi.BusinessLogic.IManagers;

namespace IntopaloApi.BusinessLogic.Managers
{
    public class DatabasesManager: RepositoryManager<Database>, IDatabasesManager
    {
        public DatabasesManager(IDatabasesRepository repository)
            : base(repository)
        {
        }
    }
}
