using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
