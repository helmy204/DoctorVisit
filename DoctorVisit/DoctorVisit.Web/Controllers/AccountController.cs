using DoctorVisit.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorVisit.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Register

        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            AccountRegister model = new AccountRegister();
            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountRegister model)
        {
            return View(model);
        }

        #endregion Register

        #region Login / Logout

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        #endregion Login / Logout
    }
}