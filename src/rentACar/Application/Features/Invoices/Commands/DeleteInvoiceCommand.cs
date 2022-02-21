using Application.Services.Repositories;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands
{
    public class DeleteInvoiceCommand: IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, NoContent>
        {
            public IInvoiceRepository _invoiceRepository { get; set; }

            public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
            {
                _invoiceRepository = invoiceRepository;
            }

            public async Task<NoContent> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
            {
                var invoice = await _invoiceRepository.GetAsync(i => i.Id == request.Id);
                if (invoice == null) throw new BusinessException("Invoice cannot found");
                await _invoiceRepository.DeleteAsync(invoice);
                return new NoContent();
            }
        }
    }
}
