using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CarRepository : EfRepositoryBase<Car, BaseDbContext>, ICarRepository
    {
        public CarRepository(BaseDbContext context) : base(context)
        {
        }
 
        public Task<List<CarDetailDto>> GetAllCarDetailToRental()
        {
            IQueryable<CarDetailDto> result =
                            from car in Context.Cars
                            join model in Context.Models on car.ModelId equals model.Id
                            join brand in Context.Brands on model.BrandId equals brand.Id
                            join color in Context.Colors on car.ColorId equals color.Id
                            join city in Context.Cities on car.CityId equals city.Id
                            select new CarDetailDto
                            {
                                CarId = car.Id,
                                BrandName = brand.Name,
                                ModelName = model.Name,
                                CityName = city.Name,
                                BrandId=brand.Id,
                                Color = color.Name,
                                Plate = car.Plate,
                                DailyPrice = model.DailyPrice,
                                ImageUrl = model.ImageUrl,
                                ColorName = color.Name,
                                CarState = car.CarState
                            };

            return result.ToListAsync();
        }

        public Task<List<CarDetailDto>> GetCarDetailToRental(int id)
        {
            IQueryable<CarDetailDto> result =
                            from car in Context.Cars
                            join model in Context.Models on car.ModelId equals model.Id
                            join brand in Context.Brands on model.BrandId equals brand.Id
                            join color in Context.Colors on car.ColorId equals color.Id
                            join city in Context.Cities on car.CityId equals city.Id
                            where model.BrandId == id
                            select new CarDetailDto
                            {
                                CarId = car.Id,
                                BrandName = brand.Name,
                                ModelName = model.Name,
                                CityName = city.Name,
                                BrandId = brand.Id,
                                Color = color.Name,
                                Plate = car.Plate,
                                DailyPrice = model.DailyPrice,
                                ImageUrl = model.ImageUrl,
                                ColorName = color.Name,
                                CarState = car.CarState

                            };

            return result.ToListAsync();
          
        }
    }
}
