using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.UpdateIngredient
{
    public class UpdateIngredientHandler : ICommandHandler<UpdateIngredientCommand, Guid>
    {
        private readonly IIngredientRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIngredientHandler(IIngredientRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(UpdateIngredientCommand command, CancellationToken cancellationToken)
        {
            var ingredient = _repository.Find(command.Id);

            if (ingredient == null)
            {
                throw new ItemNotFoundException("Ingredient is not found");
            }

            ingredient.Update(command.Name);
            await _unitOfWork.CompleteAsync();

            return ingredient.Id;
        }
    }
}
