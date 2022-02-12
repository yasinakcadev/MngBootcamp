using Application.Features.AdditionalServices.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AdditionalServices.Queries;

public class GetAdditionalServicesQuery : IRequest<AdditionalServiceModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetAdditionalServicesQueryHandler : IRequestHandler<GetAdditionalServicesQuery,AdditionalServiceModel>
    {
        private IAdditionalServiceRepository _additionalServiceRepository;
        private IMapper _mapper;

        public GetAdditionalServicesQueryHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
        {
            _additionalServiceRepository = additionalServiceRepository;
            _mapper = mapper;
        }

        public async Task<AdditionalServiceModel> Handle(GetAdditionalServicesQuery request, CancellationToken cancellationToken)
        {
            var additionalservices = await _additionalServiceRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            var mappedAdditionalServices = _mapper.Map<AdditionalServiceModel>(additionalservices);
            return mappedAdditionalServices;
        }
    }
}



