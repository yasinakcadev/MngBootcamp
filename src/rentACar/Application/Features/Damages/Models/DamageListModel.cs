using Application.Features.Damages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Models
{
    public class DamageListModel: BasePageableModel
    {
        public IList<DamageListDto> Items { get; set; }
    }
}
