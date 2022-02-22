using Application.Features.Invoices.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Queries
{
    public class GetInvoiceListByCustomerQuery: IRequest<InvoiceListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int CustomerId { get; set; }

        public class GetInvoicesBuCustomerHandler : IRequestHandler<GetInvoiceListByCustomerQuery, InvoiceListModel>
        {
            IInvoiceRepository _invoiceRepository;
            IMapper _mapper;

            public GetInvoicesBuCustomerHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<InvoiceListModel> Handle(GetInvoiceListByCustomerQuery request, CancellationToken cancellationToken)
            {
                var invoices = await _invoiceRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize, predicate: p => p.CustomerId == request.CustomerId);
                var mappedInvoices = _mapper.Map<InvoiceListModel>(invoices);
                return mappedInvoices;
            }
        }
    }
}
