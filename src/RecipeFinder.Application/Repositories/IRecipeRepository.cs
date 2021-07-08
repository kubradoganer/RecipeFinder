using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System;

namespace RecipeFinder.Application.Repositories
{
    public interface IRecipeRepository : ICrudRepository<Recipe, Guid>
    {
        Recipe GetByName(string name);
    }
}
