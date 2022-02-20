using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Dtos
{
    public class InvoiceListDto
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public DateTime? RentStartDate { get; set; }
        public int TotalRentDay { get; set; }
        public double TotalRentAmount { get; set; }
        public int UserId { get; set; }
    }
}
