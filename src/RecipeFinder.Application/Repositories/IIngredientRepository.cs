using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System;

namespace RecipeFinder.Application.Repositories
{
    public interface IIngredientRepository : ICrudRepository<Ingredient, Guid>
    {
    }
}
