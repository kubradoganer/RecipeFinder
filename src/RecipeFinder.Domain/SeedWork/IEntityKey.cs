namespace RecipeFinder.Domain.SeedWork
{
    public interface IEntityKey<T>
    {
        public T Id { get; set; }
    }
}
