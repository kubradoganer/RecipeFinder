using FluentValidation;

namespace RecipeFinder.Application.Commands.UpdateRecipe
{
    public class UpdateRecipeValidator : AbstractValidator<UpdateRecipeCommand>
    {
        public UpdateRecipeValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
        }
    }
}
