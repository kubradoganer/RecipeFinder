using AutoMapper;
using System;

namespace RecipeFinder.Application.Dtos
{
    [AutoMap(typeof(Domain.Entities.Recipe), ReverseMap = true)]

    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RecipeTypeId { get; set; }
    }
}
