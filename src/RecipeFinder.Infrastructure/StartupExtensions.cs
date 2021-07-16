using Microsoft.Extensions.DependencyInjection;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Infrastructure.Domain.Ingredients;
using RecipeFinder.Infrastructure.Domain.Measurements;
using RecipeFinder.Infrastructure.Domain.Recipes;

namespace RecipeFinder.Infrastructure
{
    public static class StartupExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();
        }
    }
}
