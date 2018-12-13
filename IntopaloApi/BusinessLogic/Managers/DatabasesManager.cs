using IntopaloApi.Data.Access.IRepositories;
using IntopaloApi.System_for_data_governance;

namespace IntopaloApi.BusinessLogic.Managers
{
    public class DatabasesManager: RepositoryManager<Database>
    {
        public DatabasesManager(IDatabasesRepository repository)
            : base(repository)
        {
        }
    }
}
