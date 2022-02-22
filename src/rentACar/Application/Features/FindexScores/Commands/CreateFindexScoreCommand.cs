
using Application.Features.FindexScores.Rules;
using Application.Services.CredibilityServices;
using Application.Services.Repositories;
using AutoMapper;
using Domain.FindexScore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Commands
{
    public class CreateFindexScoreCommand : IRequest<FindexScore>
    {
        public int CustomerId { get; set; }
        public short Score { get; set; }

        public class CreateFindexScoreCommandHandler : IRequestHandler<CreateFindexScoreCommand, FindexScore>
        {
            private IFindexScoreRepository _findexScoreRepository;
            private IMapper _mapper;
            private FindexScoreBusinessRules _findexScoreBusinessRules;
            IFindexCreditService _findexCreditService;

            public CreateFindexScoreCommandHandler(IFindexScoreRepository colorRepository, IMapper mapper, FindexScoreBusinessRules colorBusiness, IFindexCreditService findexCreditService)
            {
                _findexScoreRepository = colorRepository;
                _mapper = mapper;
                _findexScoreBusinessRules = colorBusiness;
                _findexCreditService = findexCreditService;
            }

            public async Task<FindexScore> Handle(CreateFindexScoreCommand request, CancellationToken cancellationToken)
            {
                await _findexScoreBusinessRules.CustomerIdCanNotBeDublicated(request.CustomerId);
                var score = _findexCreditService.GetFindexScore(request.CustomerId);
                request.Score = score;
                var mappedFindexScore = _mapper.Map<FindexScore>(request);
                var findexScore =  await _findexScoreRepository.AddAsync(mappedFindexScore);
                return findexScore;
            }
        }
    }
}
