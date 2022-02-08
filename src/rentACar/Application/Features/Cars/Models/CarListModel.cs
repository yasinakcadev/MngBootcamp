using Application.Features.Cars.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Cars.Models
{
    public class CarListModel: BasePageableModel
    {
        public IList<CarListDto> Items{ get; set; }
    }

    public class CarListWithModelEntityModel : BasePageableModel
    {
        public CarListWithModelEntityModel(IList<Car> items)
        {
            Items = items;
        }

        public IList<Car> Items { get; set; }
    }
}
