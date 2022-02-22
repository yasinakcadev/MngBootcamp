
using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands
{
    public class UpdateCorporateCustomerCommand : IRequest<CorporateCustomerDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, CorporateCustomerDto>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;
            CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
            IUserRepository _userRespository;

            public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules corporateCustomerBusinessRules, IUserRepository userRespository)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
                _userRespository = userRespository;
            }

            public async Task<CorporateCustomerDto> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var corporateCustomer = await _corporateCustomerRepository.GetAsync(i => i.Id == request.Id);
                if (corporateCustomer == null) throw new BusinessException("Corporate customer cannot found");
                var user = await _userRespository.GetAsync(u => u.Id == request.UserId);
                if (user == null)
                {
                    throw new BusinessException("User can not be found");
                }
                await _corporateCustomerBusinessRules.TaxNumberCanBotBeDublicated(request.TaxNumber);
                _mapper.Map(request, corporateCustomer);
                await _corporateCustomerRepository.UpdateAsync(corporateCustomer);
                var dto = _mapper.Map<CorporateCustomerDto>(corporateCustomer);
                return dto;

           
            }
        }
    }
}
