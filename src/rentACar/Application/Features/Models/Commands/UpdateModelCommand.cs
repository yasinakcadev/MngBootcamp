using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands;

public class UpdateModelCommand : IRequest<ModelDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public int BrandId { get; set; }

    public class UpdateModelHandler : IRequestHandler<UpdateModelCommand, ModelDto>
    {
        private IModelRepository _modelRepository;
        private IMapper _mapper;
        private ModelBusinessRules _modelBusinessRules;

        public UpdateModelHandler(ModelBusinessRules modelBusinessRules, IModelRepository modelRepository, IMapper mapper)
        {
            _modelBusinessRules = modelBusinessRules;
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.GetAsync(x => x.Id == request.Id);

            if (model == null)
                throw new BusinessException("Model cannot found");

            await _modelBusinessRules.ModelNameCanNotBeDuplicate(request.Name);

            _mapper.Map(request, model);

            await _modelRepository.UpdateAsync(model);

            var dto = _mapper.Map<ModelDto>(model);

            return dto;
        }
    }

}