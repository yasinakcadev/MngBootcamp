using Application.Features.IndividualCustomer.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomer.Queries
{
    public class GetIndividualCustomerListQuery: IRequest<IndividualCustomerListModel>
    {
        public PageRequest PageRequest;

        public class GetIndividualCustomerListQueryHandler : IRequestHandler<GetIndividualCustomerListQuery, IndividualCustomerListModel>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;

            public GetIndividualCustomerListQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<IndividualCustomerListModel> Handle(GetIndividualCustomerListQuery request, CancellationToken cancellationToken)
            {
                var individualCustomer = await _individualCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedIndividualCustomers = _mapper.Map<IndividualCustomerListModel>(individualCustomer);
                return mappedIndividualCustomers;
            }
        }
    }
}
