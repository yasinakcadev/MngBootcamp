using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands
{
    public class CreateCityCommand : IRequest<City>
    {
        public string Name { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, City>
        {
            private ICityRepository _cityRepository;
            private IMapper _mapper;
            private CityBusinessRules _cityBusinessRules;

            public CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper, CityBusinessRules cityBusiness)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
                _cityBusinessRules = cityBusiness;
            }

            public async Task<City> Handle(CreateCityCommand request, CancellationToken cancellationToken)
            {
                await _cityBusinessRules.CityNameCanNotNeDuplicatedWhenInsertedAndUpdated(request.Name);
                var mappedCity = _mapper.Map<City>(request);
                var city =  await _cityRepository.AddAsync(mappedCity);
                return city;
            }
        }
    }
}
