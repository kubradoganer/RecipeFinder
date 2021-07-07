using RecipeFinder.Application.SeedWork;
using RecipeFinder.Infrastructure.Database.Contexts;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Domain.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipeFinderContext _context;

        public UnitOfWork(RecipeFinderContext context)
        {
            _context = context;
        }

        public async virtual Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
