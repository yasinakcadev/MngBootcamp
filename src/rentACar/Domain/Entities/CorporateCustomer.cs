using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CorporateCustomer: Customer
    {
  
        public CorporateCustomer()
        {

        }

        public CorporateCustomer(int id, int userId,string companyName, string taxNumber): this()
        {
            Id = id;
            UserId = userId;
            CompanyName = companyName;
            TaxNumber = taxNumber;
        }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

    }
}
