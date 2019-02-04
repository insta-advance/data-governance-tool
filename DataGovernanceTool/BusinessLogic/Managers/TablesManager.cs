using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;
using DataGovernanceTool.Data.Models.Exceptions; 

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class TablesManager: RepositoryManager<Table>, ITablesManager
    {
        public TablesManager(ITablesRepository repository)
            : base(repository)
        {
        }

        public new async Task<IEnumerable<Table>> GetAsync()
        {
            return await Repository.All()
                .Include(t => t.Fields)
                .Include(t => t.PrimaryKey)
                    .ThenInclude(c => c.CompositeKeyFields)
                .Include(t => t.ForeignKeys)
                    .ThenInclude(c => c.CompositeKeyFields)
                .ToListAsync();
        }

        public new async Task<Table> GetAsync(int id)
        {
            var table = await Repository.Filter(t => t.Id == id)
                .Include(t => t.Fields)
                .Include(t => t.PrimaryKey)
                    .ThenInclude(c => c.CompositeKeyFields)
                .Include(t => t.ForeignKeys)
                    .ThenInclude(c => c.CompositeKeyFields)
                .Include(t => t.ForeignKeys)
                .ToListAsync();
            if (table.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(Table).Name} with id {id} not found.");
            } 
            return table[0];
        }

        public new async Task<Table> ReplaceAsync(int id, Table entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.SchemaId = entity.SchemaId > 0 ? 
            entity.SchemaId : existing.SchemaId;

            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
