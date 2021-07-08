using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.UpdateRecipe
{
    public class UpdateRecipeCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RecipeTypeId { get; set; }
    }
}
