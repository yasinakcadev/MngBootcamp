using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Dtos
{
    public class DamageDto
    {
        public int Id { get; set; }
        public string DamageDetail { get; set; }
        public int CarId { get; set; }
    }
}
