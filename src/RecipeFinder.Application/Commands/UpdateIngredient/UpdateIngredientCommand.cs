using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.UpdateIngredient
{
    public class UpdateIngredientCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
