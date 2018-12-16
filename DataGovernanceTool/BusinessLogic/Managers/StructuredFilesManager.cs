using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class StructuredFilesManager: RepositoryManager<StructuredFile>, IStructuredFilesManager
    {
        public StructuredFilesManager(IStructuredFilesRepository repository)
            : base(repository)
        {
        }
        public new async Task<StructuredFile> ReplaceAsync(int id, StructuredFile entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
