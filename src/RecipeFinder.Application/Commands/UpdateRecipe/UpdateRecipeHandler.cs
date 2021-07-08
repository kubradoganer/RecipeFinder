using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.UpdateRecipe
{
    public class UpdateRecipeHandler : ICommandHandler<UpdateRecipeCommand, Guid>
    {
        private readonly IRecipeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRecipeHandler(IRecipeRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(UpdateRecipeCommand command, CancellationToken cancellationToken)
        {
            var recipe = _repository.Find(command.Id);

            if (recipe == null)
            {
                throw new ItemNotFoundException("Recipe is not found");
            }

            recipe.Update(command.Name, command.RecipeTypeId);
            await _unitOfWork.CompleteAsync();

            return recipe.Id;
        }
    }
}
