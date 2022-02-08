using Application.Features.Cars.Rules;
using Application.Services.CredibilityServices;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class RentalCarCommand:IRequest<Car>
    {
        public int Id { get; set; }

        public class RentalCarCommandHandler : IRequestHandler<RentalCarCommand, Car>
        {

            private CarBusinessRules _carBusinessRule;
            private ICarRepository _carRepository;
            IFindexScoreRepository _findexScoreRepository;
            IFindexCreditService _findexCreditService;



            public RentalCarCommandHandler(CarBusinessRules carBusinessRule, ICarRepository carRepository, IFindexCreditService findexCreditService, IFindexScoreRepository findexScoreRepository)
            {
                _carBusinessRule = carBusinessRule;
                _carRepository = carRepository;
                _findexScoreRepository = findexScoreRepository;
                _findexCreditService = findexCreditService;
            }

            public async Task<Car> Handle(RentalCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRule.IsExist(request.Id);
                await _carBusinessRule.CarCanNotBeRentWhenIsInMaintenance(request.Id);

                var car = await _carRepository.GetAsync(c => c.Id == request.Id);
                car.CarState = Domain.Enums.CarState.Rented;
                await _carRepository.UpdateAsync(car);
                return car;
            }
        }
    }
}
