using Microsoft.AspNetCore.Http;
using RecipeFinder.Application.Exceptions;

namespace RecipeFinder.Api.ProblemDetails
{
    public class ItemNotFoundExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public ItemNotFoundExceptionProblemDetails(ItemNotFoundException exception)
        {
            Title = "Item not found.";
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Message;
            Type = "http://localhost/item-not-found-exception";
        }
    }
}
