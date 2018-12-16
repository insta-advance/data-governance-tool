using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class FieldsRepository : Repository<Field>, IFieldsRepository
    {
        public FieldsRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
