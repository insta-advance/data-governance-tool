using System;
using IntopaloApi.Data.Access.IRepositories;
using IntopaloApi.System_for_data_governance;

namespace IntopaloApi.Data.Access.Repositories
{
    public class DatabasesRepository : Repository<Database>, IDatabasesRepository
    {
        public DatabasesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
