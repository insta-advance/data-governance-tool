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
    public class FieldsManager: RepositoryManager<Field>, IFieldsManager
    {
        public FieldsManager(IFieldsRepository repository)
            : base(repository)
        {
        }

        public new async Task<IEnumerable<Field>> GetAsync()
        {
            return await Repository.All().Include(f => f.Fields).ToListAsync();
        }

        public new async Task<Field> GetAsync(int id)
        {
            /* For nested fields (json, document, anything really...) get the whole nesting tree. */
            Stack<int> ids = new Stack<int>(new int[] {id});
            while (ids.Count > 0) {
                var currentId = ids.Pop();
                var fields = await Repository.Filter(f => f.StructuredId == currentId).ToListAsync();   
                fields.ForEach(f => ids.Push(f.Id));
            }
            /* Get the actual field */
            /* If something is queried once (code above) it is eagerly populated in all navigation properties if Inlude() is used. */
            var field = await Repository.Filter(f => f.Id == id).Include(f => f.Fields).ToListAsync();
            if (field.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(Field).Name} with id {id} not found.");
            } 
            return field[0];
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
