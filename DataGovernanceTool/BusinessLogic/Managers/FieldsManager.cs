using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class FieldsManager: RepositoryManager<Field>, IFieldsManager
    {
        public FieldsManager(IFieldsRepository repository)
            : base(repository)
        {
        }
       
        public new async Task<Field> ReplaceAsync(int id, Field entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.Type = entity.Type ?? existing.Type;
            existing.StructuredId = entity.StructuredId > 0 ? 
            entity.StructuredId : existing.StructuredId;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
