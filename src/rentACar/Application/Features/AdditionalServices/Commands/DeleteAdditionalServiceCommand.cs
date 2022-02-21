using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdditionalServices.Commands
{
    public class DeleteAdditionalServiceCommand: IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteAdditionalServiceHandler : IRequestHandler<DeleteAdditionalServiceCommand, NoContent>
        {
            public IAdditionalServiceRepository _additionalServiceRepository { get; set; }

            public DeleteAdditionalServiceHandler(IAdditionalServiceRepository additionalServiceRepository)
            {
                _additionalServiceRepository = additionalServiceRepository;
            }

            public async Task<NoContent> Handle(DeleteAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                var additionalService = await _additionalServiceRepository.GetAsync(a => a.Id == request.Id);
                if (additionalService == null) throw new BusinessException("Additional service does not exist");
                await _additionalServiceRepository.DeleteAsync(additionalService);
                return new NoContent();
            }
        }
    }
}
