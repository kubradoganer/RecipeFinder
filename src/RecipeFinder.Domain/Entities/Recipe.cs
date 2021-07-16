using RecipeFinder.Domain.SeedWork;
using System;

namespace RecipeFinder.Domain.Entities
{
    public class Recipe : BaseRootEntity
    {
        private Recipe()
        {
        }

        private Recipe(string name, int recipeTypeId)
        {
            Id = Guid.NewGuid();
            Name = name;
            RecipeTypeId = recipeTypeId;
            CreatedByUserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");
            CreatedDate = DateTime.Now;
            UpdatedByUserId = new Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA");
            UpdatedDate = DateTime.Now;
            RecordStatus = 1;
        }

        public string Name { get; private set; }
        public int RecipeTypeId { get; set; }

        public static Recipe Create(string name, int recipeTypeId)
        {
            return new Recipe(name, recipeTypeId);
        }

        public void Update(string name, int recipeTypeId)
        {
            Name = name;
            RecipeTypeId = recipeTypeId;
        }
    }
}