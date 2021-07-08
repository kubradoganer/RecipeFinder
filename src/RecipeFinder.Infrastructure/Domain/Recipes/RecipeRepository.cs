using RecipeFinder.Application.Repositories;
using RecipeFinder.Domain.Entities;
using RecipeFinder.Infrastructure.Database.Contexts;
using RecipeFinder.Infrastructure.SeedWork;
using System;
using System.Linq;

namespace RecipeFinder.Infrastructure.Domain.Recipes
{
    public class RecipeRepository : CrudRepository<RecipeFinderContext, Recipe, Guid>, IRecipeRepository
    {
        public RecipeRepository(RecipeFinderContext context) : base(context)
        {
        }

        public Recipe GetByName(string name)
        {
            return GetQueryable().FirstOrDefault(i => i.RecordStatus == 1 && i.Name == name);
        }
    }
}
