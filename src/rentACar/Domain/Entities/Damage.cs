using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
    public class Damage: Entity
    {
        public int CarId { get; set; }
        public string DamageDetail { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
