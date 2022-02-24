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
    public class GetCarsDetailQuery : IRequest<List<CarDetailDto>>
    {
        public int BrandId { get; set; }

        public class GetCarsDetailQueryHandler : IRequestHandler<GetCarsDetailQuery, List<CarDetailDto>>
        {
            ICarRepository _carRepository;
            IMapper _mapper;

            public GetCarsDetailQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                _mapper = mapper;
                _carRepository = carRepository;
            }

            public async Task<List<CarDetailDto>> Handle(GetCarsDetailQuery request, CancellationToken cancellationToken)
            {
                var response =await _carRepository.GetCarDetailToRental(request.BrandId);
                return new List<CarDetailDto>(response);
            }
        }
    }
}
