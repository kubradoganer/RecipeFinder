using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.SeedWork;
using System.Collections.Generic;

namespace RecipeFinder.Application.Queries.GetIngredients
{
    public class GetIngredientsQuery : IQuery<IEnumerable<IngredientDto>>
    {
    }
}
