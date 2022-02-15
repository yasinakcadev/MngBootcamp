using Domain.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IndividualCustomer: Customer
    {


        public IndividualCustomer(int id,string firstName, string lastName, string nationalId): this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NationalId = nationalId;
        }

        public IndividualCustomer()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
    }
}
