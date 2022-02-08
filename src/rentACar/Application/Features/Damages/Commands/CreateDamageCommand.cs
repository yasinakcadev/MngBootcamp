using Application.Features.Damages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Commands
{
    public class CreateDamageCommand: IRequest<Damage>
    {
        public int CardId { get; set; }
        public string DamageDetail { get; set; }

        public class CreateDamageCommandHandler : IRequestHandler<CreateDamageCommand, Damage>
        {
            IMapper _mapper;
            IDamageRepository _damageRepository;
            DamageBusinessRules _damageBusinessRules;

            public CreateDamageCommandHandler(IMapper mapper, IDamageRepository damageRepository, DamageBusinessRules damageBusinessRules)
            {
                _mapper = mapper;
                _damageRepository = damageRepository;
                _damageBusinessRules = damageBusinessRules;
            }

            public async Task<Damage> Handle(CreateDamageCommand request, CancellationToken cancellationToken)
            {
                await _damageBusinessRules.CarIdCanNotBeNull(request.CardId);
                var mappedDamage = _mapper.Map<Damage>(request);
                var createdDamage = await _damageRepository.AddAsync(mappedDamage);
                return createdDamage;
            }
        }
    }
}
