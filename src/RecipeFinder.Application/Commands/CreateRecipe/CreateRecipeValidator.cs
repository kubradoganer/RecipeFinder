using FluentValidation;

namespace RecipeFinder.Application.Commands.CreateRecipe
{
    public class CreateRecipeValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
        }
    }
}
