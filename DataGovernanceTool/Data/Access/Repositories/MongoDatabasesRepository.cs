using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class MongoDatabasesRepository : Repository<MongoDatabase>, IMongoDatabasesRepository
    {
        public MongoDatabasesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
