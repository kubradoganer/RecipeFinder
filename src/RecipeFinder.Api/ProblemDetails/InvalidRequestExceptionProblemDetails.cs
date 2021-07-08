using Microsoft.AspNetCore.Http;
using RecipeFinder.Application.Exceptions;

namespace RecipeFinder.Api.ProblemDetails
{
    public class InvalidRequestExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InvalidRequestExceptionProblemDetails(InvalidRequestException exception)
        {
            Title = "Invalid request validation.";
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Message;
            Type = "https://localhost/invalid-request-exception";
        }
    }
}
