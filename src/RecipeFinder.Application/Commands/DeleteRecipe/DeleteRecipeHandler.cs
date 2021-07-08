using MediatR;
using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.DeleteRecipe
{
    public class DeleteRecipeHandler : ICommandHandler<DeleteRecipeCommand>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRecipeHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRecipeCommand command, CancellationToken cancellationToken)
        {
            var recipe = _recipeRepository.Find(command.Id);

            if (recipe is null)
            {
                throw new ItemNotFoundException("Recipe is not found");
            }

            _recipeRepository.Delete(recipe);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
