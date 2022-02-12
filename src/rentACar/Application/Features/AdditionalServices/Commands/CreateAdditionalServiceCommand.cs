using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AdditionalServices.Commands;

public class CreateAdditionalServiceCommand : IRequest<AdditionalService>
{
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public class CreateAdditionalServiceCommandHandler : IRequestHandler<CreateAdditionalServiceCommand,AdditionalService>
    {
        private IAdditionalServiceRepository _additionalServiceRepository;
        private AdditionelServicesBusinessRules _additionelServicesBusinessRules;
        private IMapper _mapper;

        public CreateAdditionalServiceCommandHandler(IAdditionalServiceRepository additionalServiceRepository, AdditionelServicesBusinessRules additionelServicesBusinessRules, IMapper mapper)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _additionelServicesBusinessRules = additionelServicesBusinessRules;
            _mapper = mapper;
        }
        
        public async Task<AdditionalService> Handle(CreateAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            await _additionelServicesBusinessRules.AdditionalServiceNameCannotDublicatedWhenInsertedOrUpdated(request.Name);

            var additionalService = _mapper.Map<AdditionalService>(request);

            var addedAdditionalService = await _additionalServiceRepository.AddAsync(additionalService);

            return addedAdditionalService;
        }
    }
}