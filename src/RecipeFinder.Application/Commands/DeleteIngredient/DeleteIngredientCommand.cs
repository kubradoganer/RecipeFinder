using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.DeleteIngredient
{
    public class DeleteIngredientCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
