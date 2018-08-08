using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleWithEFCore.Services
{
	public interface IRepository<TEntity>
    {
		IEnumerable<TEntity> GetAll();
		TEntity Get<TKey>(TKey id);

		IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

	}
}
