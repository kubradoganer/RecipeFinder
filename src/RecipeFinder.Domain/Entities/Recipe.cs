using RecipeFinder.Domain.SeedWork;
using System;

namespace RecipeFinder.Domain.Entities
{
    public class Recipe : BaseRootEntity
    {
        public Recipe(Guid id, string name, int recipeTypeId)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            RecipeTypeId = recipeTypeId;
        }

        public string Name { get; private set; }
        public int RecipeTypeId { get; set; }
    }
}