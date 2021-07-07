using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Api.Requests;
using RecipeFinder.Application.Commands.CreateRecipe;
using RecipeFinder.Application.Queries.SearchRecipe;
using RecipeFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        /// <summary>
        /// Get list of recipe.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get recipe by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("id")]
        public IEnumerable<Recipe> GetById()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add new recipe
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecipeCommand command)
        {
            return Ok();
        }

        /// <summary>
        /// Updates exist recipe
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        public IEnumerable<Recipe> Update(Guid id, UpdateRecipeRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete recipe by id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        public IEnumerable<Recipe> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("search")]
        public ActionResult SearchRecipes([FromBody] SearchRecipeQuery query)
        {
            return Ok();
        }
    }
}
