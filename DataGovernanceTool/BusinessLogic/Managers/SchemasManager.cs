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
    public class SchemasManager: RepositoryManager<Schema>, ISchemasManager
    {
        public SchemasManager(ISchemasRepository repository)
            : base(repository)
        {
        }
        public new async Task<IEnumerable<Schema>> GetAsync()
        {
            return await Repository.All().Include(s => s.Tables).ToListAsync();
        }

        public new async Task<Schema> GetAsync(int id)
        {
            var schema = await Repository.Filter(s => s.Id == id).Include(s => s.Tables).ToListAsync();
            if (schema.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(Schema).Name} with id {id} not found.");
            } 
            return schema[0];
        }
        public new async Task<Schema> ReplaceAsync(int id, Schema entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.SchemaName = entity.SchemaName ?? existing.SchemaName;
            existing.DatabaseId = entity.DatabaseId > 0 ? 
            entity.DatabaseId : existing.DatabaseId;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
