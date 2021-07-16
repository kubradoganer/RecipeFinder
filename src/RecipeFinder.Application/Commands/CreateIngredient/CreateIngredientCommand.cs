using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.CreateIngredient
{
    public class CreateIngredientCommand : ICommand<Guid>
    {
        public string Name { get; set; }
    }
}
