using System.Collections.Generic;

namespace RecipeFinder.Application.SeedWork
{
    /// <summary>
    /// Basic crud repository interface
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity</typeparam>
    /// <typeparam name="TKey">Type of primary key of the entity</typeparam>
    public interface ICrudRepository<TEntity, TKey> where TEntity : class
    {
        IEnumerable<TEntity> Get(bool asNoTracking = true);

        TEntity Find(TKey id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
