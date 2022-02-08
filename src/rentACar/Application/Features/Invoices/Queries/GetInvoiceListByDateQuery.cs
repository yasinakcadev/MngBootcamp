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
    public class GetInvoiceListByDateQuery: IRequest<InvoiceListModel>
    {
        public PageRequest PageRequest { get; set; }
        public DateTime? RentStartDate { get; set; } = new DateTime(1990, 01, 01);
        public DateTime? RentEndDate { get; set; } = DateTime.Now;
        public int InvoiceNo { get; set; }
        public class GetInvoiceListByDateHandler : IRequestHandler<GetInvoiceListByDateQuery, InvoiceListModel>
        {
            IInvoiceRepository _invoiceRepository;
            IMapper _mapper;

            public GetInvoiceListByDateHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<InvoiceListModel> Handle(GetInvoiceListByDateQuery request, CancellationToken cancellationToken)
            {
                var invoices = await _invoiceRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize, predicate: p => p.CreationDate >= request.RentStartDate && p.CreationDate <= request.RentEndDate);
                var mappedInvoice = _mapper.Map<InvoiceListModel>(invoices);
                return mappedInvoice;
            }
        }
    }
}