using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Abstarct
{
    public class Customer: Entity
    {


        public Customer(int id,string email):this()
        {
            Id = id;
            Email = email;
        }

        public Customer()
        {

        }
        public string Email { get; set; }
    }
}
