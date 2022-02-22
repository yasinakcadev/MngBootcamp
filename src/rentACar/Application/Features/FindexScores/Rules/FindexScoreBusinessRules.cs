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

        public async Task IsFindexScoreExistsForTheCustomer(int customerId)
        {
            var findexScores = await _findexScoreRespository.GetAsync(x => x.CustomerId == customerId);
            if(findexScores==null)
            {
                throw new BusinessException("Findex Score cannot be found for the customer");
            }
        }
        public async Task CustomerIdCanNotBeDublicated(int customerId)
        {
            var findexScores = await _findexScoreRespository.GetListAsync(x => x.CustomerId == customerId);
            if (findexScores.Items.Any())
            {
                throw new BusinessException("Customer cannot be dublicated");
            }
        }
       
    }
}
