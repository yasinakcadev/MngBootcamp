using Application.Features.FindexScores.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Queries
{
    public class GetFindexScoreListQuery : IRequest<FindexScoreListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetFindexScoreListQueryHandler : IRequestHandler<GetFindexScoreListQuery, FindexScoreListModel>
        {
            IFindexScoreRepository _findexScoreRepository;
            IMapper _mapper;

            public GetFindexScoreListQueryHandler(IFindexScoreRepository findexScoreRepository, IMapper mapper)
            {
                _findexScoreRepository = findexScoreRepository;
                _mapper = mapper;
            }

            public async Task<FindexScoreListModel> Handle(GetFindexScoreListQuery request, CancellationToken cancellationToken)
            {
                var findexScores = await _findexScoreRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedFindexScore = _mapper.Map<FindexScoreListModel>(findexScores);
                return mappedFindexScore;
            }
        }
    }
}
