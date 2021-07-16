using AutoMapper;
using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Queries.GetMeasurement
{
    public class GetMeasurementHandler : IQueryHandler<GetMeasurementQuery, MeasurementDto>
    {
        private readonly IMeasurementRepository _repository;
        private readonly IMapper _mapper;

        public GetMeasurementHandler(IMeasurementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<MeasurementDto> Handle(GetMeasurementQuery query, CancellationToken cancellationToken)
        {
            Measurement measurement = _repository.Find(query.Id);
            if (measurement is null)
            {
                throw new ItemNotFoundException("Measurement is not found");
            }

            return Task.FromResult(_mapper.Map<MeasurementDto>(measurement));
        }
    }
}
