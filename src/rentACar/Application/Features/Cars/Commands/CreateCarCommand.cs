using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class CreateCarCommand: IRequest<Car>
    {
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public int CityId { get; set; }
        public int ModelYear { get; set; }
        public short MinFindexScore { get; set; }
        public CarState CarState { get; set; }

        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
        {
            ICarRepository _carRepository;
            IMapper _mapper;
            CarBusinessRules _businessRules;

            public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules businessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.PlateCanNotBeDuplicatedWhenInsertedAndUpdated(request.Plate);
                var mappedCar = _mapper.Map<Car>(request);
                var createdCar = await _carRepository.AddAsync(mappedCar);
                return createdCar;
            }
        }
    }
}
