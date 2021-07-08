using Microsoft.AspNetCore.Http;
using RecipeFinder.Domain.Exceptions;

namespace RecipeFinder.Api.ProblemDetails
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Business rule validation error";
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Message;
            Type = "http://localhost/business-rule-validation-error";
        }
    }
}
