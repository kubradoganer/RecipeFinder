using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.SeedWork;
using System.Collections.Generic;

namespace RecipeFinder.Application.Queries.GetRecipes
{
    public class GetRecipesQuery : IQuery<IEnumerable<RecipeDto>>
    {
    }
}
