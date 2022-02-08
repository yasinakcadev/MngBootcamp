using Application.Features.IndividualCustomer.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomer.Commands
{
    public class CreateIndividualCustomerCommand: IRequest<Domain.Entities.IndividualCustomer>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }

        public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, Domain.Entities.IndividualCustomer>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;
            IndividualCustomerBusinessRules _individualCustomerBusinessRules;
           

            public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public async Task<Domain.Entities.IndividualCustomer> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                await _individualCustomerBusinessRules.NationalIdCanBotBeDublicated(request.NationalId);
                var mappedIndividualCustomer = _mapper.Map<Domain.Entities.IndividualCustomer>(request);
                var createdIndividualCustomer = await _individualCustomerRepository.AddAsync(mappedIndividualCustomer);
                return createdIndividualCustomer;
            }
        }
    }
}
