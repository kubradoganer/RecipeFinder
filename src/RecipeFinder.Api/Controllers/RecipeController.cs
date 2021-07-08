using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Api.Requests;
using RecipeFinder.Application.Commands.CreateRecipe;
using RecipeFinder.Application.Commands.DeleteRecipe;
using RecipeFinder.Application.Commands.UpdateRecipe;
using RecipeFinder.Application.Queries.GetRecipe;
using RecipeFinder.Application.Queries.GetRecipes;
using RecipeFinder.Application.Queries.SearchRecipe;
using RecipeFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : BaseApiController
    {
        /// <summary>
        /// Get list of recipe.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var recipes = await Mediator.Send(new GetRecipesQuery());

            return Ok(recipes);
        }

        /// <summary>
        /// Get recipe by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var recipe = await Mediator.Send(new GetRecipeQuery(id));

            return Ok(recipe);
        }

        /// <summary>
        /// Add new recipe
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecipeCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        /// <summary>
        /// Updates exist recipe
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> Update(Guid id, UpdateRecipeRequest request)
        {
            var command = new UpdateRecipeCommand()
            {
                Id = id,
                Name = request.Name,
                RecipeTypeId = request.RecipeTypeId
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Delete recipe by id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteRecipeCommand()
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost("search")]
        public ActionResult SearchRecipes([FromBody] SearchRecipeQuery query)
        {
            return Ok();
        }
    }
}
