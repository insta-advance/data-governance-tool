using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.IRepositories
{

    public interface IRepository<TEntity> where TEntity : Base
    {
        /// <summary>
        ///   Get the total objects count.
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        ///   Gets all objects from database
        /// </summary>
        IQueryable<TEntity> All();

        /// <summary>
        ///   Gets all objects from database
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        ///   Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate"> Specified a filter </param>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///   Gets objects from database with filtering and paging.
        /// </summary>
        /// <param name="filter"> Specified a filter </param>
        /// <param name="index"> Specified the page index. </param>
        /// <param name="size"> Specified the page size </param>
        IQueryable<TEntity> FilterWithPagination(Expression<Func<TEntity, bool>> filter, int index = 0, int size = 50);

        /// <summary>
        ///   Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate"> Specified the filter expression </param>
        Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///   Gets object by primary key.
        /// </summary>
        /// <param name="id"> primary key </param>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        ///   Find object by keys.
        /// </summary>
        /// <param name="keys"> Specified the search keys. </param>
        Task<TEntity> FindAsync(params object[] keys);

        /// <summary>
        ///   Find object by specified expression.
        /// </summary>
        /// <param name="predicate"> </param>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///   Create a new object to database.
        /// </summary>
        /// <param name="entity"> Specified a new object to create. </param>
        Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        ///   Update object changes and save to database.
        /// </summary>
        /// <param name="entity"> Specified the object to save. </param>
        Task<TEntity> ReplaceAsync(int id, TEntity entity);

        /// <summary>
        ///   Deletes the object by primary key
        /// </summary>
        /// <param name="id"> </param>
        Task DeleteAsync(int id);

        /// <summary>
        ///   Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"> </param>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
