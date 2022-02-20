using Application.Features.Cities.Dtos;
using Application.Features.Cities.Rules;
using Application.Features.Color.Dtos;
using Application.Features.Color.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands
{
    public class UpdateCityCommand : IRequest<CityDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, CityDto>
        {
            private ICityRepository _cityRepository;
            private IMapper _mapper;
            private CityBusinessRules _cityBusinessRules;

            public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper, CityBusinessRules cityBusinessRules)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
                _cityBusinessRules = cityBusinessRules;
            }

            public async Task<CityDto> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _cityRepository.GetAsync(c => c.Id == request.Id);
                if (city == null)
                    throw new BusinessException("City cannot found");
                
                await _cityBusinessRules.CityNameCanNotNeDuplicatedWhenInsertedAndUpdated(request.Name);
                _mapper.Map(request, city);

                await _cityRepository.UpdateAsync(city);
                return _mapper.Map<CityDto>(city);
            }
        }
    }
}
