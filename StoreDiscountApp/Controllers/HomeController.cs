using StoreDiscountApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreDiscountApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region Store
        public ActionResult Store()
        {
            return View(ApiManager.Get("Store")?.GetData<Store>(true));
        }
        public ActionResult AddStore()
        {
            return View(new Store { CreatedDate = DateTime.Now });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStore(Store store)
        {
            if (ModelState.IsValid)
            {
                ApiManager.Post<Store>(store);
                return RedirectToAction("Store", "Home");
            }
            return View(store);
        }
        public ActionResult EditStore(Guid Id)
        {
            Store SelectedStore = null;
            if (ModelState.IsValid)
            {
                var Stores = ApiManager.Get("Store").GetData<Store>(true);
                if (Stores != null)
                    SelectedStore = Stores.FirstOrDefault(x => x.Id == Id);
            }
            return View(SelectedStore);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStore(Store store)
        {
            if (ModelState.IsValid)
            {
                ApiManager.Put<Store>(store);
                return RedirectToAction("Store", "Home");
            }
            return View(store);
        }
        public ActionResult DeleteStore(Guid Id)
        {
            ApiManager.Delete("Store", "?Id=" + Id);
            return RedirectToAction("Store", "Home");
        }
        #endregion
        #region User
        public ActionResult Users()
        {
            return View(ApiManager.Get("User")?.GetData<User>(true));
        }
        public ActionResult AddUser()
        {
            ViewBag.RolList = new SelectList(ApiManager.Get("Role")?.GetData<Role>(true), "Id", "Name");
            return View(new User { CreatedDate = DateTime.Now });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(User User)
        {
            if (ModelState.IsValid)
            {
                ApiManager.Post<User>(User);
                return RedirectToAction("Users", "Home");
            }
            return View(User);
        }
        public ActionResult EditUser(Guid Id)
        {
            User SelectedUser = null;
            if (ModelState.IsValid)
            {
                var Users = ApiManager.Get("User").GetData<User>(true);
                if (Users != null)
                    SelectedUser = Users.FirstOrDefault(x => x.Id == Id);
                ViewBag.RolList = new SelectList(ApiManager.Get("Role")?.GetData<Role>(true), "Id", "Name", SelectedUser.RoleId);
            }
            return View(SelectedUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User User)
        {
            if (ModelState.IsValid)
            {
                ApiManager.Put<User>(User);
                return RedirectToAction("Users", "Home");
            }
            return View(User);
        }
        public ActionResult DeleteUser(Guid Id)
        {
            ApiManager.Delete("User", "?Id=" + Id);
            return RedirectToAction("Users", "Home");
        }
        #endregion
        #region Role
        public ActionResult Roles()
        {
            return View(ApiManager.Get("Role")?.GetData<Role>(true));
        }
        public ActionResult AddRole()
        {
            ViewBag.StoreList = new SelectList(ApiManager.Get("Store")?.GetData<Store>(true), "Id", "Name");
            return View(new Role { CreatedDate = DateTime.Now });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(Role Role)
        {
            if (ModelState.IsValid)
            {
                ApiManager.Post<Role>(Role);
                return RedirectToAction("Roles", "Home");
            }
            return View(Role);
        }
        public ActionResult EditRole(Guid Id)
        {
            Role SelectedRole = null;
            if (ModelState.IsValid)
            {
                var Roles = ApiManager.Get("Role").GetData<Role>(true);
                if (Roles != null)
                    SelectedRole = Roles.FirstOrDefault(x => x.Id == Id);
                ViewBag.StoreList = new SelectList(ApiManager.Get("Store")?.GetData<Store>(true), "Id", "Name",SelectedRole.StoreId);
            }
            return View(SelectedRole);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRole(Role Role)
        {
            if (ModelState.IsValid)
            {
                ApiManager.Put<Role>(Role);
                return RedirectToAction("Roles", "Home");
            }
            return View(Role);
        }
        public ActionResult DeleteRole(Guid Id)
        {
            ApiManager.Delete("Role", "?Id=" + Id);
            return RedirectToAction("Roles", "Home");
        }
        #endregion
        #region Invoice
        [ChildActionOnly]
        public ActionResult Invoices()
        {
            return PartialView("../Home/Partials/Invoices", ApiManager.Get("Invoice")?.GetData<Invoice>(true));
        }
        [ChildActionOnly]
        public ActionResult AddInvoice()
        {
            ViewBag.UserList = new SelectList(ApiManager.Get("User")?.GetData<User>(true), "Id", "Name");
            return PartialView("../Home/Partials/AddInvoice", new Invoice { CreatedDate = DateTime.Now });

        }
        [HttpPost]
        public ActionResult AddInvoice(Invoice Invoice)
        {
            ApiManager.Post<Invoice>(Invoice);
            return RedirectToAction("Index","Home");
        }
        public ActionResult DeleteInvoice(Guid Id)
        {
            ApiManager.Delete("Invoice", "?Id=" + Id);
            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}