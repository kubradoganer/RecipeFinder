using RecipeFinder.Domain.SeedWork;
using System;

namespace RecipeFinder.Domain.Entities
{
    public class RecipeIngredient : BaseEntity
    {
        public RecipeIngredient(Guid ingredientId, Guid measurementId, decimal amount)
        {
            IngredientId = ingredientId;
            MeasurementId = measurementId;
            Amount = amount;
        }

        public Guid IngredientId { get; set; }
        public Guid MeasurementId { get; set; }
        public decimal Amount { get; set; }
    }
}
