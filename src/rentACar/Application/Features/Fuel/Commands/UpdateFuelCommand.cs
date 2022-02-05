using Application.Features.Brands.Rules;
using Application.Features.Fuel.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Commands
{
    public class UpdateFuelCommand: IRequest<FuelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateFuelHandler : IRequestHandler<UpdateFuelCommand, FuelDto>
        {
            private IFuelRepository _fuelRepository;
            private IMapper _mapper;
            private FuelBusinessRules _fuelBusinessRules;

            public UpdateFuelHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
                _fuelBusinessRules = fuelBusinessRules;
            }

            public async Task<FuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                var fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id);
                if (fuel == null)
                    throw new BusinessException("Fuel cannot found");
                
                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);
                _mapper.Map(request, fuel);
               
                await _fuelRepository.UpdateAsync(fuel);
                return _mapper.Map<FuelDto>(fuel);
                
            }
        }
    }
}
