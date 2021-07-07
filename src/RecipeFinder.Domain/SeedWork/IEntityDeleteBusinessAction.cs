namespace RecipeFinder.Domain.SeedWork
{
    public interface IEntityDeleteBusinessAction<TEntity> where TEntity : Entity
    {
        void Action(TEntity entity);
    }
}
