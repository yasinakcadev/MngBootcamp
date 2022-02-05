using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Validation
{
    public class RequestValidationBehavior<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse>
        where TRequest : IRequest<Tresponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<Tresponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tresponse> next)
        {
            var context = new ValidationContext<object>(request);
            var failures = _validators.Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if(failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
