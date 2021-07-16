using AutoMapper;
using System;

namespace RecipeFinder.Application.Dtos
{
    [AutoMap(typeof(Domain.Entities.Ingredient), ReverseMap = true)]
    public class IngredientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
