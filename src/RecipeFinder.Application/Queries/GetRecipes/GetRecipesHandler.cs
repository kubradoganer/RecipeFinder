using AutoMapper;
using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Queries.GetRecipes
{
    public class GetRecipesHandler : IQueryHandler<GetRecipesQuery, IEnumerable<RecipeDto>>
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;

        public GetRecipesHandler(IRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<RecipeDto>> Handle(GetRecipesQuery query, CancellationToken cancellationToken)
        {
            var recipes = _repository.Get();

            return Task.FromResult(_mapper.Map<IEnumerable<RecipeDto>>(recipes));
        }
    }
}
