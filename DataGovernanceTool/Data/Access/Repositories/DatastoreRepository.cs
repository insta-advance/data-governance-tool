using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class DatastoresRepository : Repository<Datastore>, IDatastoresRepository
    {
        public DatastoresRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
