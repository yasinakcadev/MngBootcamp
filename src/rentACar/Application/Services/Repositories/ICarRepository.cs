using Core.Persistence.Repositories;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
   
        public interface ICarRepository : IAsyncRepository<Car>
        {

            Task<List<CarDetailDto>> GetCarDetailToRental(int id);
            Task<List<CarDetailDto>> GetAllCarDetailToRental();
        }
  
}
