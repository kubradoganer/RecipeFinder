using Microsoft.EntityFrameworkCore;
using RecipeFinder.Domain.Entities;

namespace RecipeFinder.Infrastructure.Database.Contexts
{
    public class RecipeFinderContext : DbContext
    {
        public RecipeFinderContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeFinderContext).Assembly);

            modelBuilder.UseIdentityAlwaysColumns();
        }
    }
}
