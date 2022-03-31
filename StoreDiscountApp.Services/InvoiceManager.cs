using StoreDiscountApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreDiscountApp.Services
{
    public class InvoiceManager : MyRepository<Invoice>, IInvoice
    {
        public bool AddInvoice(Invoice invoice)
        {
            if (invoice.UserId != null && invoice.UserId != System.Guid.Empty)
                using (var usermanager = new UserManager())
                {
                    var user = usermanager.GetById(invoice.UserId.GetValueOrDefault());
                    if (user != null)
                        using (var rolmanager = new RolManager())
                        {
                            var rol = rolmanager.GetById(user.RoleId);
                            if (rol != null)
                            {
                                invoice = SetInvoice(invoice, rol, user);
                            }
                        }
                }
            else
                invoice = SetInvoice(invoice);
            var List_ = GetAll() ?? new List<Invoice>();
            List_?.Add(invoice);
            return List_.WriteFile<Invoice>();
        }
        private Invoice SetInvoice(Invoice invoice, Role rol = null, User user = null)
        {
            if (!CheckUser(user))
            {
                var price = Util.CalcDiscount(invoice.Price, rol, user);
                invoice.DiscountRate = price.Item3;
                invoice.Discount = price.Item2;
                invoice.Remaining = price.Item1;
            }
            else
                invoice.Remaining = invoice.Price;
            invoice.UserName = user?.Name ?? "##Groceries##";
            invoice.RolName = rol?.Name;
            return invoice;
        }
        private bool CheckUser(User user)
        {
            var List_ = GetAll();
            if(List_ != null)
                return List_.Any(x => x.UserId == user.Id && x.Discount > 0 && x.DiscountRate > 0);
            return false;
        }
    }
}
