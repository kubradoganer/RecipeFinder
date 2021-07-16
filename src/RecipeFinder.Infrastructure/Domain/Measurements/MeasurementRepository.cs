using RecipeFinder.Application.Repositories;
using RecipeFinder.Domain.Entities;
using RecipeFinder.Infrastructure.Database.Contexts;
using RecipeFinder.Infrastructure.SeedWork;
using System;

namespace RecipeFinder.Infrastructure.Domain.Measurements
{
    public class MeasurementRepository : CrudRepository<RecipeFinderContext, Measurement, Guid>, IMeasurementRepository
    {
        public MeasurementRepository(RecipeFinderContext context) : base(context)
        {
        }
    }
}
