using Application.Features.CorporateCustomers.Models;
using Application.Features.Customers.Models;
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
    public class GetCustomerListQuery : IRequest<CustomerListModel>
    {
        public PageRequest PageRequest;

        public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, CustomerListModel>
        {
            ICustomerRepository _customerRepository;
            IMapper _mapper;

            public GetCustomerListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<CustomerListModel> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedCustomers = _mapper.Map<CustomerListModel>(customer);
                return mappedCustomers;
            }
        }
    }
}
