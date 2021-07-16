using AutoMapper;
using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Queries.GetIngredients
{
    public class GetIngredientsHandler : IQueryHandler<GetIngredientsQuery, IEnumerable<IngredientDto>>
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public GetIngredientsHandler(IIngredientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<IngredientDto>> Handle(GetIngredientsQuery query, CancellationToken cancellationToken)
        {
            var ingredients = _repository.Get();

            return Task.FromResult(_mapper.Map<IEnumerable<IngredientDto>>(ingredients));
        }
    }
}
