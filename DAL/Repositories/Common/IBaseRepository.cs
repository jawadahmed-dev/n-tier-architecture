﻿using DataAccess.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Common
{
	public interface IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

		Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

		Task<TEntity> AddAsync(TEntity entity);

		Task<TEntity> UpdateAsync(TEntity entity);

		Task<TEntity> DeleteAsync(TEntity entity);
	}
}
