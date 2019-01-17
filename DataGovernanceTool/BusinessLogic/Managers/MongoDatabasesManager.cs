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
    public class MongoDatabasesManager: RepositoryManager<MongoDatabase>, IMongoDatabasesManager
    {
        public MongoDatabasesManager(IMongoDatabasesRepository repository)
            : base(repository)
        {
        }
        public new async Task<IEnumerable<MongoDatabase>> GetAsync()
        {
            return await Repository.All().Include(c => c.Collections).ToListAsync();
        }
        public new async Task<MongoDatabase> GetAsync(int id)
        {
            var database = await Repository.Filter(d => d.Id == id).Include(c => c.Collections).ToListAsync();
            if (database.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(MongoDatabase).Name} with id {id} not found.");
            } 
            return database[0];
        }
        public new async Task<MongoDatabase> ReplaceAsync(int id, MongoDatabase entity)
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