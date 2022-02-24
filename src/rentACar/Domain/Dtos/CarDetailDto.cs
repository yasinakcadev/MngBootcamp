using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class CarDetailDto
    {
        public int CarId { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public string CityName { get; set; }
        public double DailyPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? ColorName { get; set; }
        public CarState? CarState { get; set; }


    }
}
