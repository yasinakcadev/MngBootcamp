using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        ICarRepository _carRepository;
        private ICityRepository _cityRepository;

      
        public CarBusinessRules(ICarRepository carRepository,ICityRepository cityRepository)
        {
            _carRepository = carRepository;
            _cityRepository = cityRepository;
        }

        public async Task PlateCanNotBeDuplicatedWhenInsertedAndUpdated(string plate)
        {
            var result = await _carRepository.GetListAsync(b => b.Plate == plate);
            if (result.Items.Any())
            {
                throw new BusinessException("Car plate exists");
            }
        }

        public async Task CanNotBeMaintainWhenCarIsRented(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);
            if (car.CarState == Domain.Enums.CarState.Rented)
                throw new BusinessException("Car can not be maintain while it is rented");
        }

        public async Task IsExist(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);
            if (car == null)
                throw new BusinessException("Car is not exist");
        }

        public async Task CarCanNotBeRentWhenIsInMaintenanceOrRented(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);
            if (car.CarState == Domain.Enums.CarState.Maintenance || car.CarState == CarState.Rented)
                throw new BusinessException("Car can not be rent while it is maintained or rented");
        }

        public async Task FindexScoreMustBeBetween(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);
            if (car.CarState == Domain.Enums.CarState.Maintenance)
                throw new BusinessException("Car can not be rent while it is maintained");
        }

        public async Task IsCarCityExist(int cityId)
        {
            var city = await _cityRepository.GetAsync(x => x.Id == cityId);
            if (city == null)
                throw new BusinessException("City is not exist");
        }

        public Task CarCannotBeNull(Car car)
        {
            if (car == null)
                throw new BusinessException("Car is not exist");

            return Task.CompletedTask;
        }

        public Task CarMustNotBeAvailable(Car car)
        {
            if (car.CarState == CarState.Available)
                throw new BusinessException("Car is already avaible");

            return Task.CompletedTask;
        }


        public Task CarIndicatorValueMustBeGreaterThanBeforeValue(Car car, int requestCarIndicatorValue)
        {
            if(car.CurrentIndicatorValueAsKilometer > requestCarIndicatorValue)
                throw new BusinessException("Car Indicator Value Must Be Greater Than Before Value");
            return Task.CompletedTask;
        }
    }
}
