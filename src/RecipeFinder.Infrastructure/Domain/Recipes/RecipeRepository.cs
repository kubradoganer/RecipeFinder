using RecipeFinder.Application.Repositories;
using RecipeFinder.Domain.Entities;
using RecipeFinder.Infrastructure.Database.Contexts;
using RecipeFinder.Infrastructure.SeedWork;
using System;

namespace RecipeFinder.Infrastructure.Domain.Recipes
{
    public class RecipeRepository : CrudRepository<RecipeFinderContext, Recipe, Guid>, IRecipeRepository
    {
        public RecipeRepository(RecipeFinderContext context) : base(context)
        {
        }
    }
}
