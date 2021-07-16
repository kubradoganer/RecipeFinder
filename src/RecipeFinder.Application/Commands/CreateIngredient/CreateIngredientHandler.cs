using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.CreateIngredient
{
    public class CreateIngredientHandler : ICommandHandler<CreateIngredientCommand, Guid>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateIngredientHandler(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateIngredientCommand command, CancellationToken cancellationToken)
        {
            Ingredient ingredient = Ingredient.Create(command.Name);

            _ingredientRepository.Add(ingredient);

            await _unitOfWork.CompleteAsync();

            return ingredient.Id;
        }
    }
}
