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
    public class CollectionsManager: RepositoryManager<Collection>, ICollectionsManager
    {
        public CollectionsManager(ICollectionsRepository repository)
            : base(repository)
        {
        }
        public new async Task<IEnumerable<Collection>> GetAsync()
        {
            return await Repository.All().Include(c => c.Fields).ToListAsync();
        }
        public new async Task<Collection> GetAsync(int id)
        {
            var collection = await Repository.Filter(c => c.Id == id).Include(c => c.Fields).ToListAsync();
            if (collection.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(Collection).Name} with id {id} not found.");
            } 
            return collection[0];
        }
        public new async Task<Collection> ReplaceAsync(int id, Collection entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.DatabaseId = entity.DatabaseId > 0 ? 
            entity.DatabaseId : existing.DatabaseId;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
