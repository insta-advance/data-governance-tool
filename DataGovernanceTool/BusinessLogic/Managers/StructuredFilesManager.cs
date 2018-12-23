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
    public class StructuredFilesManager: RepositoryManager<StructuredFile>, IStructuredFilesManager
    {
        public StructuredFilesManager(IStructuredFilesRepository repository)
            : base(repository)
        {
        }

        public new async Task<IEnumerable<StructuredFile>> GetAsync()
        {
            return await Repository.All().Include(s => s.Fields).ToListAsync();
        }

        public new async Task<StructuredFile> GetAsync(int id)
        {
            var file = await Repository.Filter(s => s.Id == id).Include(s => s.Fields).ToListAsync();
            if (file.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(UnstructuredFile).Name} with id {id} not found.");
            } 
            return file[0];
        }

        public new async Task<StructuredFile> ReplaceAsync(int id, StructuredFile entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
