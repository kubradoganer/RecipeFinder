using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Queries.GetRecipe
{
    public class GetRecipeQuery : IQuery<RecipeDto>
    {
        public GetRecipeQuery(Guid recipeId)
        {
            RecipeId = recipeId;
        }

        public Guid RecipeId { get; set; }
    }
}
