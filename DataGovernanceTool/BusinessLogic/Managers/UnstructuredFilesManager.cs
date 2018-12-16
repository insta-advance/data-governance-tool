using DataGovernanceTool.Data.Access.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.Managers
{
    public class UnstructuredFilesManager: RepositoryManager<UnstructuredFile>, IUnstructuredFilesManager
    {
        public UnstructuredFilesManager(IUnstructuredFilesRepository repository)
            : base(repository)
        {
        }
        public new async Task<UnstructuredFile> ReplaceAsync(int id, UnstructuredFile entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            existing.FilePath = entity.FilePath ?? existing.FilePath;
            existing.DatastoreId = entity.DatastoreId > 0 ? 
            entity.DatastoreId : existing.DatastoreId;
            return await Repository.ReplaceAsync(id, existing);
        }
       
    }
}
