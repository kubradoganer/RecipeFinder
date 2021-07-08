using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Infrastructure.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure
{
    public static class StartupExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();


        }
    }
}
