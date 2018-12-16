using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class TablesManager: RepositoryManager<Table>, ITablesManager
    {
        public TablesManager(ITablesRepository repository)
            : base(repository)
        {
        }
        public new async Task<Table> ReplaceAsync(int id, Table entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.TableName = entity.TableName ?? existing.TableName;
            existing.SchemaId = entity.SchemaId > 0 ? 
            entity.SchemaId : existing.SchemaId;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
