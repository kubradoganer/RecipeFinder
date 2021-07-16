using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.CreateMeasurement
{
    public class CreateMeasurementHandler : ICommandHandler<CreateMeasurementCommand, Guid>
    {
        private readonly IMeasurementRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMeasurementHandler(IMeasurementRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateMeasurementCommand command, CancellationToken cancellationToken)
        {
            Measurement measurement = Measurement.Create(command.Name);

            _repository.Add(measurement);

            await _unitOfWork.CompleteAsync();

            return measurement.Id;
        }
    }
}
