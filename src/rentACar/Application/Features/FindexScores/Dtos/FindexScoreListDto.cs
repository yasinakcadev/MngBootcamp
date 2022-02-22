using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Dtos
{
    public class FindexScoreListDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public short Score { get; set; }
    }
}
