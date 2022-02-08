using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CredibilityServices.MyFindexScoreImplementation
{
    public class MyFindexScore : IFindexCreditService
    {
        public short GetFindexScore(string Id)
        {
            Random random = new();
            short score = Convert.ToInt16(random.Next(1900));
            return score;
        }
    }
}
