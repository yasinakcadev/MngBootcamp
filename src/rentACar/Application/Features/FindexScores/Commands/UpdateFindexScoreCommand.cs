using Application.Features.FindexScores.Dtos;
using Application.Services.CredibilityServices;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;

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
            IFindexCreditService _findexCreditService;
            public UpdateFindexScoreHandler(IFindexScoreRepository findexScoreRepository, IMapper mapper, IFindexCreditService findexCreditService)
            {
                _findexScoreRepository = findexScoreRepository;
                _mapper = mapper;
                _findexCreditService = findexCreditService;
            }

            public async Task<FindexScoreDto> Handle(UpdateFindexScoreCommand request, CancellationToken cancellationToken)
            {
                var findexScore = await _findexScoreRepository.GetAsync(c => c.Id == request.Id);
                if (findexScore == null)
                    throw new BusinessException("Findex score cannot found");

                _mapper.Map(request, findexScore);
                var score = _findexCreditService.GetFindexScore(request.CustomerId);
                request.Score = score;
                await _findexScoreRepository.UpdateAsync(findexScore);
                return _mapper.Map<FindexScoreDto>(findexScore);
            }
        }
    }
}
