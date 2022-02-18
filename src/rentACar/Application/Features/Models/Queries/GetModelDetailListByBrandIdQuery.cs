using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries
{
    public class GetModelDetailListByBrandIdQuery : IRequest<ModelDetailListModel>
    {
        public int BrandId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetModelDetailListByBrandIdQueryHandler : IRequestHandler<GetModelDetailListByBrandIdQuery, ModelDetailListModel>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public GetModelDetailListByBrandIdQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelDetailListModel> Handle(GetModelDetailListByBrandIdQuery request, CancellationToken cancellationToken)
            {
                var modelDetails = await _modelRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,predicate: (p => p.BrandId == request.BrandId) ,include: (m => m.Include(m => m.Transmission).Include(m => m.Fuel).Include(m => m.Brand))
                    );

                var mappedModelDetails = _mapper.Map<ModelDetailListModel>(modelDetails);
                return mappedModelDetails;
            }
        }
    }
}
