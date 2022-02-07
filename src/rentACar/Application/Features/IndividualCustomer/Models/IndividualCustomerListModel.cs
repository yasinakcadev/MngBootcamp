using Application.Features.IndividualCustomer.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomer.Models
{
    public class IndividualCustomerListModel: BasePageableModel
    {
        public IList<IndividualCustomerListDto> Items { get; set; }
    }
}
