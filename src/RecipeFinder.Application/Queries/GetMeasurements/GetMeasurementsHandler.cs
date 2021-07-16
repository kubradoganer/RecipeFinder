using AutoMapper;
using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Queries.GetMeasurements
{
    public class GetMeasurementsHandler : IQueryHandler<GetMeasurementsQuery, IEnumerable<MeasurementDto>>
    {
        private readonly IMeasurementRepository _repository;
        private readonly IMapper _mapper;

        public GetMeasurementsHandler(IMeasurementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<MeasurementDto>> Handle(GetMeasurementsQuery query, CancellationToken cancellationToken)
        {
            var measurements = _repository.Get();

            return Task.FromResult(_mapper.Map<IEnumerable<MeasurementDto>>(measurements));
        }
    }
}
