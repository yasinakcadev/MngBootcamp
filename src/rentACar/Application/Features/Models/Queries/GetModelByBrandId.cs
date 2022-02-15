using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries
{
    public class GetModelByBrandIdQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int BrandId { get; set; }

        public class GetModelByBrandIdQueryHandler : IRequestHandler<GetModelByBrandIdQuery, ModelListModel>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public GetModelByBrandIdQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetModelByBrandIdQuery request, CancellationToken cancellationToken)
            {
                var models = await _modelRepository.GetListAsync(
                    index: request.PageRequest.Page,size: request.PageRequest.PageSize, predicate:p => p.BrandId == request.BrandId);

                var mappedModels = _mapper.Map<ModelListModel>(models);
                return mappedModels;
            }
        }
    }
}
