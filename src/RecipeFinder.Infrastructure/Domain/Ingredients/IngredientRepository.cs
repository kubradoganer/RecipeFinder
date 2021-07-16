using RecipeFinder.Application.Repositories;
using RecipeFinder.Domain.Entities;
using RecipeFinder.Infrastructure.Database.Contexts;
using RecipeFinder.Infrastructure.SeedWork;
using System;

namespace RecipeFinder.Infrastructure.Domain.Ingredients
{
    public class IngredientRepository : CrudRepository<RecipeFinderContext, Ingredient, Guid>, IIngredientRepository
    {
        public IngredientRepository(RecipeFinderContext context) : base(context)
        {
        }
    }
}
