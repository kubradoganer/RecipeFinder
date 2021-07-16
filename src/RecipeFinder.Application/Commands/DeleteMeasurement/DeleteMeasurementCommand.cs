using RecipeFinder.Application.SeedWork;
using System;

namespace RecipeFinder.Application.Commands.DeleteMeasurement
{
    public class DeleteMeasurementCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
