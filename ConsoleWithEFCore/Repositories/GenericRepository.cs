using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ConsoleWithEFCore.Repositories
{
    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type.
    /// </typeparam>
    /// <typeparam name="TContext">
    /// The database context.
    /// </typeparam>
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly TContext context;

        /// <summary>
        /// The db set.
        /// </summary>
        private readonly DbSet<TEntity> dataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity,TContext}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public GenericRepository(TContext context)
        {
            this.context = context;
            this.dataSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dataSet.Where(predicate);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <typeparam name="TKey">
        /// The parameter type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity Get<TKey>(TKey id)
        {
            return this.dataSet.Find(id);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.dataSet;
        }
    }
}
