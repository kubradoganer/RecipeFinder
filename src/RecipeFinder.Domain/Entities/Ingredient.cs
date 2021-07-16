using RecipeFinder.Domain.SeedWork;
using System;

namespace RecipeFinder.Domain.Entities
{
    public class Ingredient : BaseRootEntity
    {
        public Ingredient(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public string Name { get; private set; }

        public static Ingredient Create(string name)
        {
            return new Ingredient(name);
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
