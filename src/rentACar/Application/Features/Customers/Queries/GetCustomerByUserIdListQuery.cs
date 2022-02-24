using Application.Features.Customers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries
{
    public class GetCustomerByUserIdListQuery : IRequest<CustomerDto>
    {
      
        public int UserId { get; set; }

        public class GetCustomerByUserIdListQueryHandler : IRequestHandler<GetCustomerByUserIdListQuery, CustomerDto>
        {
            ICustomerRepository _customerRepository;
            IMapper _mapper;

            public GetCustomerByUserIdListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(GetCustomerByUserIdListQuery request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetAsync(
                    
                    predicate:c=>c.UserId==request.UserId);
                var mappedCustomer = _mapper.Map<CustomerDto>(customer);
                return mappedCustomer;
            }
        }
    }
}
