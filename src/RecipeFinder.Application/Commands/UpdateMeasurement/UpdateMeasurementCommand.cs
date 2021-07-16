using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.UpdateMeasurement
{
    public class UpdateMeasurementCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
