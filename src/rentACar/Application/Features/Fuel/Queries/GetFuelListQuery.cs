using Application.Features.Fuel.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Queries
{
    public class GetFuelListQuery : IRequest<FuelListModel>
    {
        public PageRequest pageRequest;

        public class GetFuelListHandler : IRequestHandler<GetFuelListQuery, FuelListModel>
        {
            private IFuelRepository _fuelRepository;
            private IMapper _mapper;

            public GetFuelListHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<FuelListModel> Handle(GetFuelListQuery request, CancellationToken cancellationToken)
            {
                var fuels = await _fuelRepository.GetListAsync(index: request.pageRequest.Page,
                    size: request.pageRequest.PageSize);

                var mappedFuels = _mapper.Map<FuelListModel>(fuels);

                return mappedFuels;
            }
        }
    }
}
