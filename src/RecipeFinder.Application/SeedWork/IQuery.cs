using MediatR;

namespace RecipeFinder.Application.SeedWork
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
