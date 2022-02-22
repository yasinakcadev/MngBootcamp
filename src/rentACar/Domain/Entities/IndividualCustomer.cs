using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IndividualCustomer: Customer
    {


        public IndividualCustomer(int id, int userId, string firstName, string lastName, string nationalId): this()
        {
            Id = id;
            UserId = userId;
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
