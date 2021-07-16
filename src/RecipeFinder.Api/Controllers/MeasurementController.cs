using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Api.Requests;
using RecipeFinder.Application.Commands.CreateMeasurement;
using RecipeFinder.Application.Commands.DeleteMeasurement;
using RecipeFinder.Application.Commands.UpdateMeasurement;
using RecipeFinder.Application.Queries.GetMeasurement;
using RecipeFinder.Application.Queries.GetMeasurements;
using System;
using System.Threading.Tasks;

namespace RecipeFinder.Api.Controllers
{
    [ApiController]
    [Route("api/measurements")]
    public class MeasurementController : BaseApiController
    {
        /// <summary>
        /// Get list of measurement.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var measurements = await Mediator.Send(new GetMeasurementsQuery());

            return Ok(measurements);
        }

        /// <summary>
        /// Get measurement by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var measurement = await Mediator.Send(new GetMeasurementQuery(id));

            return Ok(measurement);
        }

        /// <summary>
        /// Add new measurement
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMeasurementCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        /// <summary>
        /// Updates exist measurement
        /// </summary>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> Update(Guid id, UpdateMeasurementRequest request)
        {
            var command = new UpdateMeasurementCommand()
            {
                Id = id,
                Name = request.Name
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Delete measurement by id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMeasurementCommand()
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
