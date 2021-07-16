using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Queries.GetIngredient
{
    public class GetIngredientQuery : IQuery<IngredientDto>
    {
        public GetIngredientQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
