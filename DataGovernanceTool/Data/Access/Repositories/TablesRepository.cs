using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class TablesRepository : Repository<Table>, ITablesRepository
    {
        public TablesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
