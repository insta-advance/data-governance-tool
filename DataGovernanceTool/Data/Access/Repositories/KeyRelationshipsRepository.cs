using System;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Metadata.Relationships;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Exceptions;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class KeyRelationshipsRepository: Repository<KeyRelationship>, IKeyRelationshipsRepository
    {
        public KeyRelationshipsRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<KeyRelationship> GetAsync(int id)
        {
            Console.WriteLine("asdfasdfadsf");
            var entity = await DbSet.FindAsync(new int[] {5,8,3,3});
            Console.WriteLine("doned");

            if (entity == null)
            {
                throw new EntityNotFoundException($@"{typeof(KeyRelationship).Name} with id {id} not found.");
            }

            return entity;
        }

    }
}
