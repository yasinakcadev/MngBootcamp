using Application.Services.Repositories;
using AutoMapper;
using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries
{
    public class GetAllCarsDetailQuery : IRequest<List<CarDetailDto>>
    {

        public class GetAllCarsDetailQueryHandler : IRequestHandler<GetAllCarsDetailQuery,List<CarDetailDto>>
        {
             ICarRepository _carRepository;
             IMapper _mapper;

            public GetAllCarsDetailQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<List<CarDetailDto>> Handle(GetAllCarsDetailQuery request, CancellationToken cancellationToken)
            {
                var response = await _carRepository.GetAllCarDetailToRental();
                return new List<CarDetailDto>(response);
            }
        }
    }
}
