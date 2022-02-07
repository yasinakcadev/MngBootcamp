using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomer.Rules
{
    public class CorporateCustomerBusinessRules
    {
        ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }

        public async Task CompanyNameCanNotBeDuplicated(string companyName)
        {
            var result = await _corporateCustomerRepository.GetListAsync(c => c.CompanyName == companyName);
            if (result.Items.Any()) throw new BusinessException("");
        }
    }
}
