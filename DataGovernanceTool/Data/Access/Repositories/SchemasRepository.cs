using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class SchemasRepository : Repository<Schema>, ISchemasRepository
    {
        public SchemasRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
