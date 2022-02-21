using Application.Features.Cars.Dtos;
using Application.Features.Color.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands
{
    public class UpdateCarCommand : IRequest<CarDto>
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public short MinFindexScore { get; set; }
        public int CurrentIndicatorValueAsKilometer { get; set; }
        public int CityId { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
        public CarState CarState { get; set; }

        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarDto>
        {
            IMapper _mapper;
            ICarRepository _carRepository;
            ColorBusinessRules _colorBusinessRules;

            public UpdateCarCommandHandler(IMapper mapper, ICarRepository carRepository, ColorBusinessRules colorBusinessRules)
            {
                _mapper = mapper;
                _carRepository = carRepository;
                _colorBusinessRules = colorBusinessRules;
            }

            public async Task<CarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var car = await _carRepository.GetAsync(c => c.Id == request.Id);
                if (car == null) throw new BusinessException("Car does not exist");
                _mapper.Map(request, car);
                await _carRepository.UpdateAsync(car);
                return _mapper.Map<CarDto>(car);
            }
        }
    }
}
