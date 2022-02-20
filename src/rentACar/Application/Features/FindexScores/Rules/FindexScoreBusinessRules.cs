using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Rules
{
    public class FindexScoreBusinessRules
    {
        private IFindexScoreRepository _findexScoreRespository;

        public FindexScoreBusinessRules(IFindexScoreRepository findexScoreRespository)
        {
            _findexScoreRespository = findexScoreRespository;
        }

        public async Task IsFindexScoreExistsForTheCustomer(int userId)
        {
            var findexScores = await _findexScoreRespository.GetAsync(x => x.UserId== userId);
            if(findexScores==null)
            {
                throw new BusinessException("Findex Score cannot be found for the customer");
            }
        }
        public async Task CustomerIdCanNotBeDublicated(int userId)
        {
            var findexScores = await _findexScoreRespository.GetListAsync(x => x.UserId == userId);
            if (findexScores.Items.Any())
            {
                throw new BusinessException("Customer cannot be dublicated");
            }
        }
       
    }
}
