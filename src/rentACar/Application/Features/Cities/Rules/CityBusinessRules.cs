using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Rules
{
    public class CityBusinessRules
    {
        private ICityRepository _cityRespository;

        public CityBusinessRules(ICityRepository cityRespository)
        {
            _cityRespository = cityRespository;
        }

        public async Task CityNameCanNotNeDuplicatedWhenInsertedAndUpdated(string name)
        {
            var cities = await _cityRespository.GetListAsync(x => x.Name == name);
            if(cities.Items.Any())
            {
                throw new BusinessException("City name cannot duplicated");
            }
        }

        public async Task ColorIdShouldExists(string name)
        {
            var cities = await _cityRespository.GetListAsync(x => x.Name == name);
            if (cities.Items.Any())
            if (cities.Items.Any())
            {
                throw new BusinessException("City name cannot duplicated");
            }
        }
    }
}
