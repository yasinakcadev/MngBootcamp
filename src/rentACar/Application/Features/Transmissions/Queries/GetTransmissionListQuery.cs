using Application.Features.Transmissions.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Transmissions.Queries
{
    public class GetTransmissionListQuery : IRequest<TransmissionListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetTransmissionListQueryHandler : IRequestHandler<GetTransmissionListQuery, TransmissionListModel>
        {
            private IMapper _mapper;
            private ITransmissionRepository _transmissionRepository;

            public GetTransmissionListQueryHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
            {
                _mapper = mapper;
                _transmissionRepository = transmissionRepository;
            }

            public async Task<TransmissionListModel> Handle(GetTransmissionListQuery request, CancellationToken cancellationToken)
            {
                var transmissions = await _transmissionRepository.GetListAsync(size: request.PageRequest.PageSize, index: request.PageRequest.Page);
                var mappedTransmission = _mapper.Map<TransmissionListModel>(transmissions);
                return mappedTransmission;
            }
        }
    }
}
