using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class RentalCarCommandValidator: AbstractValidator<RentalCarCommand>
    {
        public RentalCarCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty().NotNull();
        }
    }
}
