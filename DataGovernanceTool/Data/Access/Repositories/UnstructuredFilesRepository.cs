using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class UnstructuredFilesRepository : Repository<UnstructuredFile>, IUnstructuredFilesRepository
    {
        public UnstructuredFilesRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
