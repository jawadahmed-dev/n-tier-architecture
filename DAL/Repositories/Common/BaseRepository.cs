using DataAccess.Entities.Common;
using DemoApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Common
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly DataContext _dataContext;
		protected readonly DbSet<TEntity> _dbSet;

		public BaseRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
			_dbSet = dataContext.Set<TEntity>();
		}
		public async Task<TEntity> AddAsync(TEntity entity)
		{
			var addedEntity =  (await _dbSet.AddAsync(entity)).Entity;
			return addedEntity;
		}
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var removedEntity = _dbSet.Remove(entity).Entity;
            await _dataContext.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _dbSet.Where(predicate).FirstOrDefaultAsync();

            //if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }
    }
}
