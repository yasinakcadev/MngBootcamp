using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomer.Rules
{
    public class IndividualCustomerBusinessRules
    {
        IIndividualCustomerRepository _individualCustomerRepository;
        IUserRepository _userRespository;

        public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task NationalIdCanBotBeDublicated(string nationalId)
        {
            var result = await _individualCustomerRepository.GetListAsync(c => c.NationalId == nationalId);
            if (result.Items.Any())
            {
                throw new BusinessException("NationalId cannot be dublicated");
            }
        }

    }
}
