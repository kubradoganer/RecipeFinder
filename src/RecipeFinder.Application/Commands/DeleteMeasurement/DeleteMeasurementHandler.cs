using MediatR;
using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Commands.DeleteMeasurement
{
    public class DeleteMeasurementHandler : ICommandHandler<DeleteMeasurementCommand>
    {
        private readonly IMeasurementRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMeasurementHandler(IMeasurementRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteMeasurementCommand command, CancellationToken cancellationToken)
        {
            var measurement = _repository.Find(command.Id);

            if (measurement is null)
            {
                throw new ItemNotFoundException("Measurement is not found");
            }

            _repository.Delete(measurement);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
