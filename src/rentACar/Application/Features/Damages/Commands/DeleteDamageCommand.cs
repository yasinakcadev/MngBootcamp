using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Commands
{
    public class DeleteDamageCommand: IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteDamageCommandHandler : IRequestHandler<DeleteDamageCommand, NoContent>
        {
            IDamageRepository _damageRepository;

            public DeleteDamageCommandHandler(IDamageRepository damageRepository)
            {
                _damageRepository = damageRepository;
            }

            public async Task<NoContent> Handle(DeleteDamageCommand request, CancellationToken cancellationToken)
            {
                var damage = await _damageRepository.GetAsync(d => d.Id == request.Id);
                if (damage == null)
                    throw new BusinessException("Damage cannot found");
                await _damageRepository.DeleteAsync(damage);    
                return new NoContent(); 
            }
        }
    }
}
