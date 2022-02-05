using Application.Features.Transmission.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmission.Models
{
    public class TransmissionListModel: BasePageableModel
    {
        public IList<TransmissionListDto> Items { get; set; }
    }
}
