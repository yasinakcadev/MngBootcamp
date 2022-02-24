using Application.Features.Customers.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Models
{
    public class CustomerListModel : BasePageableModel
    {
        public IList<CustomerListDto> Items { get; set; }
    }
}
