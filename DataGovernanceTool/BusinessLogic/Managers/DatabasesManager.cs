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
    public class DatabasesManager: RepositoryManager<Database>, IDatabasesManager
    {
        public DatabasesManager(IDatabasesRepository repository)
            : base(repository)
        {
        }
        public new async Task<IEnumerable<Database>> GetAsync()
        {
            return await Repository.All().Include(d => d.Schemas).ToListAsync();
        }
        public new async Task<Database> GetAsync(int id)
        {
            var database = await Repository.Filter(d => d.Id == id).Include(d => d.Schemas).ToListAsync();
            if (database.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(Database).Name} with id {id} not found.");
            } 
            return database[0];
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
