using AutoMapper;
using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Queries.GetIngredient
{
    public class GetIngredientHandler : IQueryHandler<GetIngredientQuery, IngredientDto>
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public GetIngredientHandler(IIngredientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IngredientDto> Handle(GetIngredientQuery query, CancellationToken cancellationToken)
        {
            Ingredient ingredient = _repository.Find(query.Id);
            if (ingredient is null)
            {
                throw new ItemNotFoundException("Ingredient is not found");
            }

            return Task.FromResult(_mapper.Map<IngredientDto>(ingredient));
        }
    }
}
