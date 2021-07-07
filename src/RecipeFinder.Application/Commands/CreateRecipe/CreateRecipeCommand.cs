using System;

namespace RecipeFinder.Application.Commands.CreateRecipe
{
    public class CreateRecipeCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RecipeTypeId { get; set; }
    }
}
