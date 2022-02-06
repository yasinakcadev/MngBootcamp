using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands;

public class MaintenanceCarCommandValidator : AbstractValidator<MaintenanceCarCommand>
{
    public MaintenanceCarCommandValidator()
    {
        RuleFor(m => m.Id).NotEmpty().NotNull();
    }
}
