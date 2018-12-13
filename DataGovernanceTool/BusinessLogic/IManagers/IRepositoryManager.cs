using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.IManagers
{
    public interface IRepositoryManager<TEntity> : IManager
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReplaceAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
    }
}
