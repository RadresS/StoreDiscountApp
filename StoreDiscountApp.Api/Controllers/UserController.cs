using Microsoft.AspNetCore.Mvc;
using StoreDiscountApp.Models;
using StoreDiscountApp.Services;
using System;
using System.Collections.Generic;

namespace UserDiscountApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserManager Manager { get; set; }
        public UserController()
        {
            Manager = new UserManager();
        }
        [HttpGet]
        public IList<User> Get()
        {
            return Manager.GetAll();
        }
        [HttpPost]
        public bool Add(User User)
        {
            return Manager.Insert(User);
        }
        [HttpPut]
        public bool Update(User User)
        {
            return Manager.Update(User);
        }
        [HttpDelete]
        public bool Delete(Guid Id)
        {
            return Manager.Delete(Id);
        }

    }
}
