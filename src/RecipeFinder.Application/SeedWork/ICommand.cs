using MediatR;

namespace RecipeFinder.Application.SeedWork
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
