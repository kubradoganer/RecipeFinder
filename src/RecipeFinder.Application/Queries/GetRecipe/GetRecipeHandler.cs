using AutoMapper;
using RecipeFinder.Application.Dtos;
using RecipeFinder.Application.Exceptions;
using RecipeFinder.Application.Repositories;
using RecipeFinder.Application.SeedWork;
using RecipeFinder.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Application.Queries.GetRecipe
{
    public class GetRecipeHandler : IQueryHandler<GetRecipeQuery, RecipeDto>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipeHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public Task<RecipeDto> Handle(GetRecipeQuery query, CancellationToken cancellationToken)
        {
            Recipe recipe = _recipeRepository.Find(query.RecipeId);
            if (recipe is null)
            {
                throw new ItemNotFoundException();
            }

            return Task.FromResult(_mapper.Map<RecipeDto>(recipe));
        }
    }
}
