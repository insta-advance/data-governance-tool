using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class KeyRelationshipsRepository: Repository<KeyRelationship>, IKeyRelationshipsRepository
    {
        public KeyRelationshipsRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
