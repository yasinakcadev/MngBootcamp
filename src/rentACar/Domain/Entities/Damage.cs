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
        public Damage()
        {

        }

        public Damage(int carId, string damageDetail, Car car): this()
        {
            CarId = carId;
            DamageDetail = damageDetail;
        }

        public int CarId { get; set; }
        public string DamageDetail { get; set; }
        public virtual Car Car { get; set; }
    }
}
