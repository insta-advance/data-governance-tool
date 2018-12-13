using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class DatabasesManager: RepositoryManager<Database>, IDatabasesManager
    {
        public DatabasesManager(IDatabasesRepository repository)
            : base(repository)
        {
        }
        public new async Task<Database> ReplaceAsync(int id, Database entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.Type = entity.Type ?? existing.Type;
            existing.DatastoreId = entity.DatastoreId > 0 ? 
            entity.DatastoreId : existing.DatastoreId;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
