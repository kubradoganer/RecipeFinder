using MediatR;
using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.DeleteIngredient
{
    public class DeleteIngredientHandler : ICommandHandler<DeleteIngredientCommand>
    {
        private readonly IIngredientRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteIngredientHandler(IIngredientRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteIngredientCommand command, CancellationToken cancellationToken)
        {
            var recipe = _recipeRepository.Find(command.Id);

            if (recipe is null)
            {
                throw new ItemNotFoundException("Ingredient is not found");
            }

            _recipeRepository.Delete(recipe);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
