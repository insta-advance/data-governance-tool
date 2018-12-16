using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class StructuredFilesRepository : Repository<StructuredFile>, IStructuredFilesRepository
    {
        public StructuredFilesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
