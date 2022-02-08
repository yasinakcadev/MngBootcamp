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
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string NationalId { get; set; }

        public IndividualCustomer(int id,string firstName, string lastname, string nationalId): this()
        {
            Id = id;
            FirstName = firstName;
            Lastname = lastname;
            NationalId = nationalId;
        }

        public IndividualCustomer()
        {

        }
    }
}
