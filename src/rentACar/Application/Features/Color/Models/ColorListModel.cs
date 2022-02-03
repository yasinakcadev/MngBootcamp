using Application.Features.Color.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Models
{
    public class ColorListModel: BasePageableModel
    {
        public IList<ColorListDto> Items { get; set; }
    }
}
