using Application.Features.FindexScores.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Models
{
    public class FindexScoreListModel : BasePageableModel
    {
        public IList<FindexScoreListDto> Items { get; set; }
    }
}
