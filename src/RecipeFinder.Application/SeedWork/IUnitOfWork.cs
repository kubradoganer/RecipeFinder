using System;
using System.Threading.Tasks;

namespace RecipeFinder.Application.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
    }
}
