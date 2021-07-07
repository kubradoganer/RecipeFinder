using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.DependencyInjection;
using RecipeFinder.Api.ProblemDetails;
using RecipeFinder.Application.Exceptions;
using RecipeFinder.Domain.Exceptions;

namespace RecipeFinder.Api.Extensions
{
    public static class ProblemDetailsExtensions
    {
        public static IServiceCollection AddProblemDetailsFromExceptions(this IServiceCollection services)
        {
            services.AddProblemDetails(p =>
            {
                p.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
                p.Map<InvalidRequestException>(ex => new InvalidRequestExceptionProblemDetails(ex));
            });

            return services;
        }
    }
}
