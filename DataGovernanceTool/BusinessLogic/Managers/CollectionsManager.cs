using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class CollectionsManager: RepositoryManager<Collection>, ICollectionsManager
    {
        public CollectionsManager(ICollectionsRepository repository)
            : base(repository)
        {
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
