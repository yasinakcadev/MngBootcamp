using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CorporateCustomer: User
    {
  
        public CorporateCustomer()
        {

        }

        public CorporateCustomer(int id, string email, byte[] passwordSalt, byte[] passwordHash, bool status,string companyName, string taxNumber): this()
        {
            Id = id;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
            CompanyName = companyName;
            TaxNumber = taxNumber;
        }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

    }
}
