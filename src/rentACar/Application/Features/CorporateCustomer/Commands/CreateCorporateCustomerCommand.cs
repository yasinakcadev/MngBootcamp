using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomer.Commands
{
    public class CreateCorporateCustomerCommand: IRequest<Domain.Entities.CorporateCustomer>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public class CreateCorporateCustomerHandler : IRequestHandler<CreateCorporateCustomerCommand, Domain.Entities.CorporateCustomer>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;

            public Task<Domain.Entities.CorporateCustomer> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
