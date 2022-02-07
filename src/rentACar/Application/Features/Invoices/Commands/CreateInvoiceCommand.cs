using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands
{
    public class CreateInvoiceCommand: IRequest<Invoice>
    {
        public int InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public DateTime RentStartDate { get; set; }
        public int TotalRentDay { get; set; }
        public double TotalRentAmount { get; set; }
        public int CustomerId { get; set; }

        public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
        {
            IMapper _mapper;
            IInvoiceRepository _invoiceRepository;
            InvoiceBusinessRules _invoiceBusinessRules;

            public CreateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository, InvoiceBusinessRules invoiceBusinessRules)
            {
                _mapper = mapper;
                _invoiceRepository = invoiceRepository;
                _invoiceBusinessRules = invoiceBusinessRules;
            }

            public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var mappedInvoice = _mapper.Map<Invoice>(request);
                var createInvoice = await _invoiceRepository.AddAsync(mappedInvoice);
                return createInvoice;
            }
        }
    }
}
