using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Relationships;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class KeyRelationshipsManager: RepositoryManager<KeyRelationship>, IKeyRelationshipsManager
    {
        public KeyRelationshipsManager(IKeyRelationshipsRepository repository)
            : base(repository)
        {
        }
        /*public new async Task<KeyRelationship> ReplaceAsync(int id, KeyRelationship entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.Type = entity.Type ?? existing.Type;
            existing.DatastoreId = entity.DatastoreId > 0 ? 
            entity.DatastoreId : existing.DatastoreId;
            return await Repository.ReplaceAsync(id, existing);
        }*/
    }
}