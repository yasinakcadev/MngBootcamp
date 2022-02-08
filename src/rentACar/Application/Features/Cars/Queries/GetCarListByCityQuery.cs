using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries;

public class GetCarListByCityQuery : IRequest<CarListModel>
{
    public PageRequest PageRequest { get; set; }
    public int CityId { get; set; }

    public class GetCarListByCityQueryHandler : IRequestHandler<GetCarListByCityQuery, CarListModel>
    {
        ICarRepository _carRepository;
        IMapper _mapper;

        public GetCarListByCityQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarListModel> Handle(GetCarListByCityQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                predicate: c => c.CarState != Domain.Enums.CarState.Maintenance && c.CityId == request.CityId);
            var mappedCars = _mapper.Map<CarListModel>(cars);
            return mappedCars;
        }
    }
}