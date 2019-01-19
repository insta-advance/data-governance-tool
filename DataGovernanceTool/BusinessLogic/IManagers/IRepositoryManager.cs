using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.BusinessLogic.IManagers
{
    public interface IRepositoryManager<TEntity> : IManager// where TEntity : Base
    {
        Task<String> GetType(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> FindAsync(params object[] keys);
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReplaceAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
    }
}
