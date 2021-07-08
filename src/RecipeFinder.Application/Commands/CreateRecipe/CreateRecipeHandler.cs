using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.CreateRecipe
{
    public class CreateRecipeHandler : ICommandHandler<CreateRecipeCommand, Guid>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRecipeHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateRecipeCommand command, CancellationToken cancellationToken)
        {
            Recipe recipe = Recipe.Create(command.Name,
                                       command.RecipeTypeId);

            _recipeRepository.Add(recipe);

            await _unitOfWork.CompleteAsync();

            return recipe.Id;
        }
    }
}
