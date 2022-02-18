using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries;

public class GetModelDetailListQuery : IRequest<ModelDetailListModel>
{
   public PageRequest PageRequest { get; set; }

    public class GetModelDetailListQueryHandler : IRequestHandler<GetModelDetailListQuery, ModelDetailListModel>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;

        public GetModelDetailListQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ModelDetailListModel> Handle(GetModelDetailListQuery request, CancellationToken cancellationToken)
        {
            var modelDetails = await _modelRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,include: (m=>m.Include(m=>m.Transmission).Include(m=>m.Fuel).Include(m=>m.Brand))
                );

           var mappedModelDetails = _mapper.Map<ModelDetailListModel>(modelDetails);
            return mappedModelDetails;
        }
    }
}