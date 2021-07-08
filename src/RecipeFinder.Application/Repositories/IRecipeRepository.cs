using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Repositories
{
    public interface IRecipeRepository : ICrudRepository<Recipe, Guid>
    {
    }
}
