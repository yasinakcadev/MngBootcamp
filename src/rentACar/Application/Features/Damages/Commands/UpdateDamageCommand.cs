using Application.Features.Damages.Dtos;
using Application.Features.Damages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Commands
{
    public class UpdateDamageCommand: IRequest<DamageDto>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string DamageDetail { get; set; }

        public class UpdateDamageCommandHandler : IRequestHandler<UpdateDamageCommand, DamageDto>
        {
            DamageBusinessRules _damageBusinessRules;
            IMapper _mapper;
            IDamageRepository _damageRepository;

            public UpdateDamageCommandHandler(DamageBusinessRules damageBusinessRules, IMapper mapper, IDamageRepository damageRepository)
            {
                _damageBusinessRules = damageBusinessRules;
                _mapper = mapper;
                _damageRepository = damageRepository;
            }

            public async Task<DamageDto> Handle(UpdateDamageCommand request, CancellationToken cancellationToken)
            {
                var damage = await _damageRepository.GetAsync(d => d.Id == request.Id);
                if (damage == null)
                    throw new BusinessException("Damage cannot found");
                await _damageBusinessRules.CarIdCanNotBeNull(request.CarId);
                _mapper.Map(request,damage);
                await _damageRepository.UpdateAsync(damage);
                var dto = _mapper.Map<DamageDto>(damage);
                return dto;
            }
        }
    }
}
