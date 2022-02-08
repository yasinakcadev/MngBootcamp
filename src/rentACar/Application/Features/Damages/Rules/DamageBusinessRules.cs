using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Rules
{
    public class DamageBusinessRules
    {
        IDamageRepository _damageRepository;

        public DamageBusinessRules(IDamageRepository damageRepository)
        {
            _damageRepository = damageRepository;
        }

        public async Task CarIdCanNotBeNull(int carId)
        {
            var result = await _damageRepository.GetListAsync(d => d.CarId == carId);
            if (result.Items.Any())
                throw new BusinessException("Car can not be null");
        }
    }
}
