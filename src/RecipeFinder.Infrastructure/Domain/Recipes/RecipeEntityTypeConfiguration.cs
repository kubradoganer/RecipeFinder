using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinder.Domain.Entities;

namespace RecipeFinder.Infrastructure.Domain.Recipes
{
    public class RecipeEntityTypeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable(nameof(Recipe));

            builder.Property(r => r.Name);
            builder.Property(r => r.RecipeTypeId).IsRequired();
        }
    }
}
