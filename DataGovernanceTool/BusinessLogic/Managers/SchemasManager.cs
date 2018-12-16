using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class SchemasManager: RepositoryManager<Schema>, ISchemasManager
    {
        public SchemasManager(ISchemasRepository repository)
            : base(repository)
        {
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
