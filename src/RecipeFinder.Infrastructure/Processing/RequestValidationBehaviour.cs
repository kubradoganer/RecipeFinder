using FluentValidation;
using FluentValidation.Results;
using MediatR;
using RecipeFinder.Application.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeFinder.Infrastructure.Processing
{
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            List<ValidationFailure> errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Any())
            {
                string errorMessage = BuildErrorMessage(errors);
                throw new InvalidRequestException(errorMessage);
            }

            return next();
        }

        private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (ValidationFailure error in errors)
            {
                if (!dictionary.ContainsKey(error.PropertyName))
                {
                    dictionary[error.PropertyName] = new List<string>();
                }

                dictionary[error.PropertyName].Add(error.ErrorMessage);
            }

            return JsonSerializer.Serialize(dictionary);
        }
    }
}
