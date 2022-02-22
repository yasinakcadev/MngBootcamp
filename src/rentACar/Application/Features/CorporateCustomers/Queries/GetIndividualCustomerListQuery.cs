using Application.Features.CorporateCustomers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Queries
{
    public class GetCorporateCustomerListQuery : IRequest<CorporateCustomerListModel>
    {
        public PageRequest PageRequest;

        public class GetCorporateCustomerListQueryHandler : IRequestHandler<GetCorporateCustomerListQuery, CorporateCustomerListModel>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;

            public GetCorporateCustomerListQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<CorporateCustomerListModel> Handle(GetCorporateCustomerListQuery request, CancellationToken cancellationToken)
            {
                var corporateCustomer = await _corporateCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedCorporateCustomers = _mapper.Map<CorporateCustomerListModel>(corporateCustomer);
                return mappedCorporateCustomers;
            }
        }
    }
}
