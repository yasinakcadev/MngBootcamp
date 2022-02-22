using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Commands
{
    public class CreateCorporateCustomerCommand : IRequest<CorporateCustomer>
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CorporateCustomer>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;
            CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
            IUserRepository _userRespository;


            public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules corporateCustomerBusinessRules, IUserRepository userRespository)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
                _userRespository = userRespository;
            }

            public async Task<CorporateCustomer> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
             
                var user= await _userRespository.GetAsync(u=>u.Id==request.UserId);
                if (user == null)
                {
                    throw new BusinessException("User can not be found");
                }
                await _corporateCustomerBusinessRules.TaxNumberCanBotBeDublicated(request.TaxNumber);
                await _corporateCustomerBusinessRules.UserIdCanBotBeDublicated(request.UserId);


                var mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                var createdCorporateCustomer = await _corporateCustomerRepository.AddAsync(mappedCorporateCustomer);
                return createdCorporateCustomer;
            }
        }
    }
}
