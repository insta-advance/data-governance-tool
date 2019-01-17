using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class PostgresDatabasesRepository : Repository<PostgresDatabase>, IPostgresDatabasesRepository
    {
        public PostgresDatabasesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
