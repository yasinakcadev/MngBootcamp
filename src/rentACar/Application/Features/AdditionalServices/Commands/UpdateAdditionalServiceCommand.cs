using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AdditionalServices.Commands;

public class UpdateAdditionalServiceCommand : IRequest<AdditionalService>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double DailyPrice { get; set; }
    public class UpdateAdditionalServiceCommandHandler : IRequestHandler<UpdateAdditionalServiceCommand, AdditionalService>
    {
        private IAdditionalServiceRepository _additionalServiceRepository;
        private AdditionelServicesBusinessRules _additionelServicesBusinessRules;
        private IMapper _mapper;

        public UpdateAdditionalServiceCommandHandler(IAdditionalServiceRepository additionalServiceRepository, AdditionelServicesBusinessRules additionelServicesBusinessRules, IMapper mapper)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _additionelServicesBusinessRules = additionelServicesBusinessRules;
            _mapper = mapper;
        }

        public async Task<AdditionalService> Handle(UpdateAdditionalServiceCommand request, CancellationToken cancellationToken)
        {
            await _additionelServicesBusinessRules.AdditionalServiceNameCannotDublicatedWhenInsertedOrUpdated(request.Name);

            var additionalService = _mapper.Map<AdditionalService>(request);

            await _additionalServiceRepository.UpdateAsync(additionalService);

            return additionalService;
        }
    }
}