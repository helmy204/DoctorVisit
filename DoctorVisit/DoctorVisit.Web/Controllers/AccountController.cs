using DoctorVisit.Core.Domain.Users;
using DoctorVisit.Service.Authentication;
using DoctorVisit.Service.Users;
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
        #region Fields

        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRegistrationService _userRegistrationService;

        #endregion Fields

        #region Ctor

        public AccountController(IAuthenticationService authenticationService,
            IUserRegistrationService userRegistrationService)
        {
            _authenticationService = authenticationService;
            _userRegistrationService = userRegistrationService;
        }

        #endregion Ctor

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
            // TODO check if user already registered

            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    IsActive = true,
                    InsertedOn = DateTime.Now
                };


                var registrationResult = _userRegistrationService.RegisterUser(user);
                if (registrationResult.Success)
                {
                    _authenticationService.SignIn(user, true);
                    return RedirectToAction("Index", "Home");
                }

                // errors
                foreach (var error in registrationResult.Errors)
                    ModelState.AddModelError("error", error);

            }

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

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(AccountLogin model)
        {
            User user = new User()
            {
                Username = model.UsernameOrEmail,
                Email = model.UsernameOrEmail,
                Password = model.Password
            };

            var loginResult = _userRegistrationService.ValidateUser(model.UsernameOrEmail, model.Password);
            switch (loginResult)
            {
                case UserLoginResults.Successful:
                    {
                        // sign in user
                        // TODO add remember me
                        _authenticationService.SignIn(user, true);

                        // TODO save login activity log

                        // TODO redirect to return url

                        return RedirectToAction("Index", "Home");
                    }

                    // TODO check other login results for login errors
            }

            return View(model);
        }

        // GET: /Acount/Logout
        public ActionResult Logout()
        {
            // TODO save logout avtivity log

            _authenticationService.SignOut();

            return RedirectToAction("Login", "Account");
        }

        #endregion Login / Logout
    }
}