using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands
{
    public class DeleteBrandCommandValidator: AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(b => b.Id).NotNull().NotEmpty();
        }
    }
}
