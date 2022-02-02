using Application.Features.Models.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;

namespace Application.Features.Models.Commands
{
    public class CreateModelCommand: IRequest<Model>
    {
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }

        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Model>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;
            ModelBusinessRules _modelBusinessRules;

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<Model> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.ModelNameCanNotBeDuplicateWhenInserted(request.Name);
                await _modelBusinessRules.BrandIsExist(request.BrandId);    
                await _modelBusinessRules.FuelIsExist(request.FuelId);
                await _modelBusinessRules.TransmissionIsExist(request.TransmissionId);
                await _modelBusinessRules.DailyPriceRangeMustZeroToInfWhenInserted(request.DailyPrice);

                var mappedModel = _mapper.Map<Model>(request);
                var createdBrand = await _modelRepository.AddAsync(mappedModel);
                return createdBrand;
            }
        }
    }
}
