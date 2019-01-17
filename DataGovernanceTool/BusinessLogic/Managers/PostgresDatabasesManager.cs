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
    public class PostgresDatabasesManager: RepositoryManager<PostgresDatabase>, IPostgresDatabasesManager
    {
        public PostgresDatabasesManager(IPostgresDatabasesRepository repository)
            : base(repository)
        {
        }
        public new async Task<IEnumerable<PostgresDatabase>> GetAsync()
        {
            return await Repository.All().Include(d => d.Schemas).ToListAsync();
        }
        public new async Task<PostgresDatabase> GetAsync(int id)
        {
            var database = await Repository.Filter(d => d.Id == id).Include(d => d.Schemas).ToListAsync();
            if (database.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(PostgresDatabase).Name} with id {id} not found.");
            } 
            return database[0];
        }
        public new async Task<PostgresDatabase> ReplaceAsync(int id, PostgresDatabase entity)
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
