using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.CreateRecipe
{
    public class CreateRecipeCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public int RecipeTypeId { get; set; }
    }
}
