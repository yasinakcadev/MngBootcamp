using Application.Services.Repositories;

namespace Application.Features.Invoices.Rules
{
    public class InvoiceBusinessRules
    {
        private IInvoiceRepository _invoiceRepository;

        public InvoiceBusinessRules(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
    }
}
