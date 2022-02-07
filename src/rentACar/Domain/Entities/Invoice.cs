using Core.Persistence.Repositories;
using Domain.Entities.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice: Entity
    {
        public int InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public DateTime RentStartDate { get; set; }
        public int TotalRentDay { get; set; }
        public double TotalRentAmount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Invoice(int id,int invoiceNo, DateTime creationDate, DateTime rentEndDate, DateTime rentStartDate, int totalRentDay, double totalRentAmount, int customerId, Customer customer): this()
        {
            Id = id;
            InvoiceNo = invoiceNo;
            CreationDate = creationDate;
            RentEndDate = rentEndDate;
            RentStartDate = rentStartDate;
            TotalRentDay = totalRentDay;
            TotalRentAmount = totalRentAmount;
            CustomerId = customerId;
            Customer = customer;
        }

        public Invoice()
        {
            Cars = new HashSet<Car>();
        }
    }
}
