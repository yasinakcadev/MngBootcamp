using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusinessRules
    {
        ICorporateCustomerRepository _corporateCustomerRepository;
       


        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
          
        }

        public async Task TaxNumberCanBotBeDublicated(string taxNumber)
        {
            var result = await _corporateCustomerRepository.GetListAsync(c => c.TaxNumber == taxNumber);
            if (result.Items.Any())
            {
                throw new BusinessException("TaxNumber cannot be dublicated");
            }
        }
        public async Task UserIdCanBotBeDublicated(int userId)
        {
            var result = await _corporateCustomerRepository.GetListAsync(c => c.UserId == userId);
            if (result.Items.Any())
            {
                throw new BusinessException("UserId cannot be dublicated");
            }
        }
        //public async Task UserIdCanBotBeDublicatedWhenUpdated(int userId)
        //{
        //    var result = await _individualCustomerRepository.GetListAsync(c => c.UserId == userId);
        //    if (result.Items.Any())
        //    {
        //        foreach (var item in result.Items)
        //        {

        //        }
        //        throw new BusinessException("UserId cannot be dublicated");
        //    }
        //}


    }
}
