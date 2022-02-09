using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Commands
{
    public class DeleteFindexScoreCommand : IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteFindexScoreCommandHandler : IRequestHandler<DeleteFindexScoreCommand, NoContent>
        {
            private IFindexScoreRepository _findexScoreRepository;

            public DeleteFindexScoreCommandHandler(IFindexScoreRepository findexScoreRepository)
            {
                _findexScoreRepository = findexScoreRepository;
            }

            public async Task<NoContent> Handle(DeleteFindexScoreCommand request, CancellationToken cancellationToken)
            {
                var color = await _findexScoreRepository.GetAsync(c => c.Id == request.Id);
                if (color == null)
                    throw new BusinessException("FindexScore not found");
                await _findexScoreRepository.DeleteAsync(color);
                return new NoContent();
            }
        }
    }
}
