using RecipeFinder.Domain.SeedWork;
using System;

namespace RecipeFinder.Domain.Entities
{
    public class Measurement : BaseRootEntity
    {
        public Measurement(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public string Name { get; private set; }

        public static Measurement Create(string name)
        {
            return new Measurement(name);
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
