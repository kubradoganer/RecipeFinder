using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Domain.Entities;

namespace RecipeFinder.Infrastructure.Domain.Ingredients
{
    public class IngredientEntityTypeConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        internal const string TABLE_INGREDIENT = "Ingredient";
        internal const string TABLE_INGREDIENT_COL_NAME = "Name";

        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable(TABLE_INGREDIENT);
            builder.Property(p => p.Name).HasColumnName(TABLE_INGREDIENT_COL_NAME);
        }
    }
}
