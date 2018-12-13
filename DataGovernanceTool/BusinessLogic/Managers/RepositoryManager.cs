using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Metadata.Structure;
namespace DataGovernanceTool.BusinessLogic.Managers
{

    public abstract class RepositoryManager<TEntity> : IRepositoryManager<TEntity>//where TEntity : Base
    {
        protected readonly IRepository<TEntity> Repository;

        protected RepositoryManager(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await Repository.CreateAsync(entity);
        }

        public virtual async Task<TEntity> ReplaceAsync(int id, TEntity entity)
        {
            return await Repository.ReplaceAsync(id, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
        }
    }
}
