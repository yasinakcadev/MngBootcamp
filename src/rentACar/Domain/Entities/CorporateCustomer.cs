using Domain.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CorporateCustomer: Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public CorporateCustomer()
        {

        }

        public CorporateCustomer(int id,string companyName, string taxNumber): this()
        {
            Id = id;
            CompanyName = companyName;
            TaxNumber = taxNumber;
        }
    }
}
