using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.CreateMeasurement
{
    public class CreateMeasurementCommand : ICommand<Guid>
    {
        public string Name { get; set; }
    }
}
