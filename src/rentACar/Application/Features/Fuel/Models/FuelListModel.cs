using Application.Features.Fuel.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Models
{
    public class FuelListModel : BasePageableModel
    {
        public IList<FuelListItem> Items { get; set; }
    }
}
