using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class BasesRepository : Repository<Base>, IBasesRepository
    {
        public BasesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
