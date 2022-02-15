using Application.Features.Brands.Rules;
using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands;

public class CreateModelCommand : IRequest<ModelDto>
{

    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public int BrandId { get; set; }

    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, ModelDto>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;
        ModelBusinessRules _modelBusinessRules;

        public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper,
            ModelBusinessRules modelBusinessRules)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<ModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            await _modelBusinessRules.ModelNameCanNotBeDuplicate(request.Name);
            await _modelBusinessRules.BrandIsExist(request.BrandId);
            await _modelBusinessRules.FuelIsExist(request.FuelId);
            await _modelBusinessRules.TransmissionIsExist(request.TransmissionId);
            await _modelBusinessRules.DailyPriceRangeMustZeroToInfWhenInserted(request.DailyPrice);

            var mappedModel = _mapper.Map<Model>(request);

            var createdModel = await _modelRepository.AddAsync(mappedModel);

            var createdModelDto= _mapper.Map<ModelDto>(createdModel);
            return createdModelDto;
        }
    }
}