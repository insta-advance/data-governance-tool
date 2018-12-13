using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntopaloApi.System_for_data_governance;

namespace IntopaloApi.BusinessLogic.IManagers
{
    public interface IRepositoryManager<TEntity> : IManager where TEntity : Base
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReplaceAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
    }
}
