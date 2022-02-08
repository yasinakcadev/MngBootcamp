using Application.Features.Color.Dtos;
using Application.Features.Color.Rules;
using Application.Features.FindexScores.Dtos;
using Application.Features.FindexScores.Rules;
using Application.Services.CredibilityServices;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Commands
{
    public class UpdateFindexScoreCommand : IRequest<FindexScoreDto>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public short Score { get; set; } 

        public class UpdateFindexScoreHandler : IRequestHandler<UpdateFindexScoreCommand, FindexScoreDto>
        {
            private IFindexScoreRepository _findexScoreRepository;
            private IMapper _mapper;
            private FindexScoreBusinessRules _findexScoreBusinessRules;
            IFindexCreditService _findexCreditService;
            public UpdateFindexScoreHandler(IFindexScoreRepository findexScoreRepository, IMapper mapper, FindexScoreBusinessRules findexScoreBusinessRules, IFindexCreditService findexCreditService)
            {
                _findexScoreRepository = findexScoreRepository;
                _mapper = mapper;
                _findexScoreBusinessRules = findexScoreBusinessRules;
                _findexCreditService = findexCreditService;
            }

            public async Task<FindexScoreDto> Handle(UpdateFindexScoreCommand request, CancellationToken cancellationToken)
            {
                var findexScore = await _findexScoreRepository.GetAsync(c => c.Id == request.Id);
                if (findexScore == null)
                    throw new BusinessException("Color cannot found");
                
                await _findexScoreBusinessRules.CustomerIdCanNotBeDublicated(request.CustomerId);
                _mapper.Map(request, findexScore);
                var score = _findexCreditService.GetFindexScore(request.CustomerId);
                request.Score = score;
                await _findexScoreRepository.UpdateAsync(findexScore);
                return _mapper.Map<FindexScoreDto>(findexScore);
            }
        }
    }
}
