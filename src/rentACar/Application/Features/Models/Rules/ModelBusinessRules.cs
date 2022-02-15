using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Rules
{
    public class ModelBusinessRules
    {
        IModelRepository _modelRepository;
        IBrandRepository _brandRepository;

        public ModelBusinessRules(IModelRepository modelRepository, IBrandRepository brandRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        public async Task ModelNameCanNotBeDuplicate(string name)
        {
            var result = await _modelRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Model name exists");
            }
        }

        public async Task BrandIsExist(int brandId)
        {

            var result = await _brandRepository.GetAsync(b => b.Id == brandId);
            if (result == null)
            {
                throw new BusinessException("Brand doesn't exist");
            }
        }
        public Task DailyPriceRangeMustZeroToInfWhenInserted(double price)
        {
            if (price < 0)
            {
                throw new BusinessException("Model daily price out of range");
            }
            return Task.CompletedTask;
        }

        public async Task TransmissionIsExist(int trasmissionId)
        {
            //todo : check transmission id from transmission id
            //var result = await _modelRepository.GetListAsync(b => b.Name == name);
            //if (result.Items.Any())
            //{
            //   throw new BusinessException("Brand name exists");
            //}
        }

        public async Task FuelIsExist(int fuelId)
        {
            //todo : check fuel id from fuel repo
            //var result = await _modelRepository.GetListAsync(b => b.Name == name);
            //if (result.Items.Any())
            //{
            //   throw new BusinessException("Brand name exists");
            //}
        }

        
    }
}
