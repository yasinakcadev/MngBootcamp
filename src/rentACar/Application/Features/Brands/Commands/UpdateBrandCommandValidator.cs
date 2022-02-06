using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands
{
    public class UpdateBrandCommandValidator: AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty().NotNull();
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(2);
            RuleFor(b => b.Name).MaximumLength(50);
        }
    }
}
