using Microsoft.AspNetCore.Mvc;
using StoreDiscountApp.Models;
using StoreDiscountApp.Services;
using System;
using System.Collections.Generic;

namespace InvoiceDiscountApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public InvoiceManager Manager { get; set; }
        public InvoiceController()
        {
            Manager = new InvoiceManager();
        }
        [HttpGet]
        public IList<Invoice> Get()
        {
            return Manager.GetAll();
        }
        [HttpPost]
        public bool Add(Invoice Invoice)
        {
            return Manager.AddInvoice(Invoice);
        }
        [HttpPut]
        public bool Update(Invoice Invoice)
        {
            return Manager.Update(Invoice);
        }
        [HttpDelete]
        public bool Delete(Guid Id)
        {
            return Manager.Delete(Id);
        }

    }
}
