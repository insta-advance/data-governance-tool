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
    public class DatastoresManager: RepositoryManager<Datastore>, IDatastoresManager
    {
        public DatastoresManager(IDatastoresRepository repository)
            : base(repository)
        {
        }

        public new async Task<IEnumerable<Datastore>> GetAsync()
        {
            return await Repository.All()
                .Include(d => d.PostgresDatabases)
                .Include(d => d.MongoDatabases)
                .Include(d => d.StructuredFiles)
                .Include(d => d.UnstructuredFiles)
                .ToListAsync();
        }

        public new async Task<Datastore> GetAsync(int id)
        {
            var datastore = await Repository
                .Filter(d => d.Id == id)
                .Include(d => d.PostgresDatabases)
                .Include(d => d.MongoDatabases)
                .Include(d => d.StructuredFiles)
                .Include(d => d.UnstructuredFiles)
                .ToListAsync();
            if (datastore.Count == 0) {
                throw new EntityNotFoundException($@"{typeof(Datastore).Name} with id {id} not found.");
            } 
            return datastore[0];
        }

        public new async Task<Datastore> ReplaceAsync(int id, Datastore entity)
        {
            var existing = await GetAsync(id);
            existing.Name = entity.Name ?? existing.Name;
            return await Repository.ReplaceAsync(id, existing);
        }
    }
}
