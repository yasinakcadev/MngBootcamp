using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands
{
    public class MaintenanceCarCommand : IRequest<Car>
    {
        public int Id { get; set; }

        public class MaintenanceCarCommandHandler : IRequestHandler<MaintenanceCarCommand, Car>
        {

            ICarRepository _carRepository;
            CarBusinessRules _businessRules;

            public MaintenanceCarCommandHandler(ICarRepository carRepository, CarBusinessRules businessRules)
            {
                _carRepository = carRepository;
                _businessRules = businessRules;
            }

            public async Task<Car> Handle(MaintenanceCarCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.IsExist(request.Id);
                await _businessRules.CanNotBeMaintainWhenCarIsRented(request.Id);

                var car = await _carRepository.GetAsync(c => c.Id == request.Id);
                car.CarState = Domain.Enums.CarState.Maintenance;
                await _carRepository.UpdateAsync(car);
                return car;
            }
        }
    }
}
