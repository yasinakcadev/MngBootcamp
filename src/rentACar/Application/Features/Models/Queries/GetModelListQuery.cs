using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries;

public class GetModelListQuery : IRequest<ModelListModel>
    
{
    public PageRequest PageRequest { get; set; }


    public class GetModelListQueryHandler : IRequestHandler<GetModelListQuery, ModelListModel>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;

        public GetModelListQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ModelListModel> Handle(GetModelListQuery request, CancellationToken cancellationToken)
        {
            var models = await _modelRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);

            var mappedModels = _mapper.Map<ModelListModel>(models);
            return mappedModels;
        }
    }
}