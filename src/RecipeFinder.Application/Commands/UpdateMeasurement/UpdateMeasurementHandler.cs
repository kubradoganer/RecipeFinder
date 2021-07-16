using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.UpdateMeasurement
{
    public class UpdateMeasurementHandler : ICommandHandler<UpdateMeasurementCommand, Guid>
    {
        private readonly IMeasurementRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMeasurementHandler(IMeasurementRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(UpdateMeasurementCommand command, CancellationToken cancellationToken)
        {
            var measurement = _repository.Find(command.Id);

            if (measurement == null)
            {
                throw new ItemNotFoundException("Measurement is not found");
            }

            measurement.Update(command.Name);
            await _unitOfWork.CompleteAsync();

            return measurement.Id;
        }
    }
}
