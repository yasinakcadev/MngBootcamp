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
        ICarRepository _carRepository;

        public DamageBusinessRules(IDamageRepository damageRepository, ICarRepository carRepository)
        {
            _damageRepository = damageRepository;
            _carRepository = carRepository;
        }

        public async Task CarIdCanNotBeNull(int carId)
        {
            var car = await _carRepository.GetAsync(d => d.Id == carId);
            if (car == null)
                throw new BusinessException("Car can not be null");
        }
    }
}
