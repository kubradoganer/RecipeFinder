using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Api.Requests;
using RecipeFinder.Application.Commands.CreateIngredient;
using RecipeFinder.Application.Commands.DeleteIngredient;
using RecipeFinder.Application.Commands.UpdateIngredient;
using RecipeFinder.Application.Queries.GetIngredient;
using RecipeFinder.Application.Queries.GetIngredients;
using System;
using System.Threading.Tasks;

namespace RecipeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientController : BaseApiController
    {
        /// <summary>
        /// Get list of ingredient.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var ingredients = await Mediator.Send(new GetIngredientsQuery());

            return Ok(ingredients);
        }

        /// <summary>
        /// Get ingredient by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var ingredient = await Mediator.Send(new GetIngredientQuery(id));

            return Ok(ingredient);
        }

        /// <summary>
        /// Add new ingredient
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIngredientCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        /// <summary>
        /// Updates exist ingredient
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> Update(Guid id, UpdateIngredientRequest request)
        {
            var command = new UpdateIngredientCommand()
            {
                Id = id,
                Name = request.Name
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Delete ingredient by id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteIngredientCommand()
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
