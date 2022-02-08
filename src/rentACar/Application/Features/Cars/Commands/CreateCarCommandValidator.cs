using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class CreateCarCommandValidator: AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.Plate).NotEmpty().MinimumLength(5);
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ModelYear).NotNull();
            RuleFor(c => c.ModelId).NotNull();
            RuleFor(c => c.CarState).IsInEnum();
            RuleFor(c => c.MinFindexScore).NotNull();
            RuleFor(c => c.MinFindexScore).LessThanOrEqualTo((short)1900);
            RuleFor(c => c.MinFindexScore).GreaterThanOrEqualTo((short)0);

        }
    }
}
