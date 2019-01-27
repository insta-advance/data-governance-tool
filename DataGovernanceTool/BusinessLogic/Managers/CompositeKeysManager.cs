using DataGovernanceTool.Data.Models.Metadata.Relationships;
using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class CompositeKeysManager: RepositoryManager<CompositeKey>, ICompositeKeysManager
    {
        public CompositeKeysManager(ICompositeKeysRepository repository)
            : base(repository)
        {
        }
        public new async Task<IEnumerable<CompositeKey>> GetAsync()
        {
            return await Repository.All().Include(c => c.CompositeKeyFields).ToListAsync();
        }

        public new async Task<CompositeKey> GetAsync(int id)
        {
            var compositeKey = await Repository.Filter(c => c.Id == id).Include(c => c.CompositeKeyFields).ToListAsync();
            if (compositeKey.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(CompositeKey).Name} with id {id} not found.");
            } 
            return compositeKey[0];
        }
    }
}