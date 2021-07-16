using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Queries.GetMeasurement
{
    public class GetMeasurementQuery : IQuery<MeasurementDto>
    {
        public GetMeasurementQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
