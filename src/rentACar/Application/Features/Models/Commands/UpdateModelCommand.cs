using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands
{
    public class UpdateModelCommand: IRequest<ModelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public int TransmissionId { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }

        public class UpdateModelHandler : IRequestHandler<UpdateModelCommand, ModelDto>
        {
            private IModelRepository _modelRepository;
            private ModelBusinessRules _modelBusinessRules;
            private IMapper _mapper;

            public UpdateModelHandler(IModelRepository modelRepository, ModelBusinessRules modelBusinessRules, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _modelBusinessRules = modelBusinessRules;
                _mapper = mapper;
            }

            public async Task<ModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.ModelNameCanNotBeDuplicateWhenInserted(request.Name);
                await _modelBusinessRules.BrandIsExist(request.BrandId);

                var modelToUpdate = await _modelRepository.GetAsync(m => m.Id == request.Id);
                if (modelToUpdate == null)
                    throw new BusinessException("Model cannot found");

                _mapper.Map(request,modelToUpdate);
                var model = _modelRepository.UpdateAsync(modelToUpdate);
                var dto = _mapper.Map<ModelDto>(model);
                return dto;
            }
        }
    }
}
