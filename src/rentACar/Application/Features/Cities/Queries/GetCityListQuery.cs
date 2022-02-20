using Application.Features.Cities.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries
{
    public class GetCityListQuery : IRequest<CityListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, CityListModel>
        {
            ICityRepository _cityRepository;
            IMapper _mapper;

            public GetCityListQueryHandler(ICityRepository colorRepository, IMapper mapper)
            {
                _cityRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<CityListModel> Handle(GetCityListQuery request, CancellationToken cancellationToken)
            {
                var cities = await _cityRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedCity = _mapper.Map<CityListModel>(cities);
                return mappedCity;
            }
        }
    }
}
