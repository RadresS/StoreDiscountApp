using StoreDiscountApp.Models;

namespace StoreDiscountApp.Services
{
    public interface IInvoice {
        bool AddInvoice(Invoice invoice);
    }
}
