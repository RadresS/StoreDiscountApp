using Microsoft.AspNetCore.Mvc;
using StoreDiscountApp.Models;
using StoreDiscountApp.Services;
using System;
using System.Collections.Generic;

namespace RoleDiscountApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public RolManager Manager { get; set; }
        public RoleController()
        {
            Manager = new RolManager();
        }
        [HttpGet]
        public IList<Role> Get()
        {
            return Manager.GetAll();
        }
        [HttpPost]
        public bool Add(Role Role)
        {
            return Manager.Insert(Role);
        }
        [HttpPut]
        public bool Update(Role Role)
        {
            return Manager.Update(Role);
        }
        [HttpDelete]
        public bool Delete(Guid Id)
        {
            return Manager.Delete(Id);
        }
    }
}
