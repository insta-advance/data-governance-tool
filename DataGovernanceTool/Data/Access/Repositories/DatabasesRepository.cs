using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class DatabasesRepository : Repository<Database>, IDatabasesRepository
    {
        public DatabasesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
