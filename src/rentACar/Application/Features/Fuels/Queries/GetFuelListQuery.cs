using Application.Features.Fuels.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Fuels.Queries
{
    public class GetFuelListQuery : IRequest<FuelListModel>
    {
        public PageRequest PageRequest;

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
                var fuels = await _fuelRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedFuels = _mapper.Map<FuelListModel>(fuels);

                return mappedFuels;
            }
        }
    }
}
