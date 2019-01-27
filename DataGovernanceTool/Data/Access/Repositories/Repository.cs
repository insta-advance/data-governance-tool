using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using DataGovernanceTool.Data.Models.Metadata.Structure;

namespace DataGovernanceTool.Data.Access.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : SuperBase 
    {
        protected readonly BaseDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(BaseDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        public virtual IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await All().ToListAsync();
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<TEntity> FilterWithPagination(Expression<Func<TEntity, bool>> filter, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? DbSet.Where(filter) : DbSet;
            return skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
        }

        public async Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException($@"{typeof(TEntity).Name} with id {id} not found.");
            }

            return entity;
        }

        public virtual async Task<TEntity> FindAsync(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try{
                var newEntry = DbSet.Add(entity);
                await DbContext.SaveChangesAsync();
                return newEntry.Entity;
            }
            catch(DbUpdateException ex){
                throw new EntityAlreadyExistsException($@"{typeof(TEntity).Name} already exists.");
            }
            
        }

        public virtual async Task<TEntity> ReplaceAsync(int id, TEntity entity)
        {
            var existingEntity = await DbSet.FindAsync(id);
            if (existingEntity == null)
            {
                throw new EntityNotFoundException($@"{typeof(TEntity).Name} with id {id} not found.");
            }

            entity.Id = id;

            return await ReplaceAsync(existingEntity, entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity != null)
            {
                await DeleteAsync(entity);
            }
            else 
                throw new EntityNotFoundException($@"{typeof(TEntity).Name} with id {id} not found.");
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entityToDelete in entitiesToDelete)
            {
                DbSet.Remove(entityToDelete);
            }
            await DbContext.SaveChangesAsync();
        }

        protected virtual async Task DeleteAsync(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        protected async Task<TEntity> ReplaceAsync(TEntity existingEntity, TEntity entity)
        {
            // Ensure that existing entity is replaced by a new one.
            DbContext.Entry(existingEntity).State = EntityState.Detached;
            var trackedEntity = DbSet.Update(entity);

            await DbContext.SaveChangesAsync();
            return trackedEntity.Entity;
        }
    }

}
