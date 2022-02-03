using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Commands
{
    public class CreateFuelCommand : IRequest<Domain.Entities.Fuel>
    {
        public string Name { get; set; }

        class CreateFuelHandler : IRequestHandler<CreateFuelCommand, Domain.Entities.Fuel>
        {
            private IFuelRepository _fuelRepository;
            private FuelBusinessRules _fuelBusinessRules;
            private IMapper _mapper;

            public CreateFuelHandler(FuelBusinessRules fuelBusinessRules, IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelBusinessRules = fuelBusinessRules;
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<Domain.Entities.Fuel> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);

                var fuel = _mapper.Map<Domain.Entities.Fuel>(request);

                await _fuelRepository.AddAsync(fuel);

                return fuel;
            }
        }
    }
}
