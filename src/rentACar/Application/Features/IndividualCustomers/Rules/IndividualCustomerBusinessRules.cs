using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusinessRules
    {
        IIndividualCustomerRepository _individualCustomerRepository;
        ICustomerRepository _customerRepository;



        public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository, ICustomerRepository customerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _customerRepository = customerRepository;
        }

        public async Task NationalIdCanBotBeDublicated(string nationalId)
        {
            var result = await _individualCustomerRepository.GetListAsync(c => c.NationalId == nationalId);
            if (result.Items.Any())
            {
                throw new BusinessException("NationalId cannot be dublicated");
            }
        }
        public async Task UserIdCanBotBeDublicated(int userId)
        {
            //var result = await _individualCustomerRepository.GetListAsync(c => c.UserId == userId);
            var result = await _customerRepository.GetListAsync(c => c.UserId == userId);
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
