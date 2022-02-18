using Core.Persistence.Paging;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Models
{
    public class ModelDetailListModel :BasePageableModel
    {
        public IList<ModelDetailListDto> Items { get; set; }
    }
}
