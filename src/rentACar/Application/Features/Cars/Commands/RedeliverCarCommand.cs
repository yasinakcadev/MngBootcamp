using Application.Features.Cars.Rules;
using Application.Features.Rents.Command;
using Application.Features.Rents.Queries;
using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Features.Cars.Commands;

public class RedeliverCarCommand : IRequest<NoContent>
{
    public int Id { get; set; }
    public int CarIndicatorValue { get; set; }

    public class RedeliverCarCommandHandler : IRequestHandler<RedeliverCarCommand, NoContent>
    {
        private ICarRepository _carRepository;
        private CarBusinessRules _businessRules;
        private IMediator _mediator;


        public RedeliverCarCommandHandler(CarBusinessRules businessRules, ICarRepository carRepository, IMediator mediator)
        {
            _businessRules = businessRules;
            _carRepository = carRepository;
            _mediator = mediator;
        }

        public async Task<NoContent> Handle(RedeliverCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetAsync(x => x.Id == request.Id);

            await _businessRules.CarCannotBeNull(car);
            await _businessRules.CarMustNotBeAvailable(car);
            await _businessRules.CarIndicatorValueMustBeGreaterThanBeforeValue(car,request.CarIndicatorValue);

            var rent = await _mediator.Send(new GetRentByCarIdQuery() { CarId = request.Id });
            if (rent == null)
                throw new BusinessException("Rent cannot found");

            car.CarState = CarState.Available;
            car.CurrentIndicatorValueAsKilometer = request.CarIndicatorValue;
            car.CityId = rent.GivingCityId.Value;

            await _carRepository.UpdateAsync(car);

            rent.IsCompleted = true;
            rent.EndIndicatorValueAsKilometer = request.CarIndicatorValue;

            await _mediator.Send(new UpdateRentCommand() { Rent = rent });

            return new NoContent();

        }
    }
}

public class RedeliverCarCommandValidator : AbstractValidator<RedeliverCarCommand>
{
    public RedeliverCarCommandValidator()
    {
        RuleFor(r => r.Id).NotEmpty().NotNull();
    }
}