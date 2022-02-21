using Application.Features.Invoices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands
{
    public class UpdateInvoiceCommand: IRequest<InvoiceDto>
    {
        public int Id { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public DateTime RentStartDate { get; set; }
        public int TotalRentDay { get; set; }
        public double TotalRentAmount { get; set; }
        public int UserId { get; set; }

        public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, InvoiceDto>
        {
            private IInvoiceRepository _invoiceRepository;
            private IMapper _mapper;
            public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
            {
                _invoiceRepository = invoiceRepository;
                _mapper = mapper;
            }

            public async Task<InvoiceDto> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoice = await _invoiceRepository.GetAsync(i => i.Id == request.Id);
                if (invoice == null) throw new BusinessException("Invoice does not exist");

                _mapper.Map(request,invoice);
                await _invoiceRepository.UpdateAsync(invoice);
                return _mapper.Map<InvoiceDto>(invoice);
            }
        }
    }
}
