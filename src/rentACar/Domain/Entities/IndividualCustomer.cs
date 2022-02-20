using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IndividualCustomer: User
    {


        public IndividualCustomer(int id, string email, byte[] passwordSalt, byte[] passwordHash, bool status,string firstName, string lastName, string nationalId): this()
        {
            Id = id;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
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
