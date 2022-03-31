using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDiscountApp.Models;
using StoreDiscountApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDiscountApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public StoreManager Manager { get; set; }
        public StoreController()
        {
            Manager = new StoreManager();
        }
        [HttpGet]
        public IList<Store> Get()
        {
            return Manager.GetAll();
        }
        [HttpPost]
        public bool Add(Store store)
        {
            return Manager.Insert(store);
        }
        [HttpPut]
        public bool Update(Store store)
        {
            return Manager.Update(store);
        }
        [HttpDelete]
        public bool Delete(Guid Id)
        {
            return Manager.Delete(Id);
        }

    }
}
