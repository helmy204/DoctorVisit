using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorVisit.Core.Domain.Users;
using System.Web;
using System.Web.Security;
using DoctorVisit.Service.Users;

namespace DoctorVisit.Service.Authentication
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public partial class FormsAuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly TimeSpan _expirationTimeSpan;
        private readonly IUserService _userService;

        #endregion Fields

        public FormsAuthenticationService(HttpContextBase httpContext,
            IUserService userService)
        {
            _httpContext = httpContext;
            _userService = userService;
            _expirationTimeSpan = FormsAuthentication.Timeout;
        }


        /// <summary>
        /// Get authenticated user
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <returns>User</returns>
        protected virtual User GetAuthenticatedUserFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var usernameOrEmail = ticket.UserData;

            if (string.IsNullOrWhiteSpace(usernameOrEmail))
                return null;

            var user = _userService.GetUserByUsernameOrEmail(usernameOrEmail);

            return user;
        }

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="createPersistentCookie">A value indicating whether to create a persistent cookie.</param>
        public void SignIn(User user,bool createPersistentCookie)
        {
            var now = DateTime.Now;

            var ticket = new FormsAuthenticationTicket(
                1, // version
                user.Username,
                now,
                now.Add(_expirationTimeSpan),
                createPersistentCookie,
                user.Username,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;

            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;

            cookie.Path = FormsAuthentication.FormsCookiePath;

            if (FormsAuthentication.CookieDomain != null)
                cookie.Domain = FormsAuthentication.CookieDomain;

            _httpContext.Response.Cookies.Add(cookie);

        }

        /// <summary>
        /// Sign out
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Get authenticated user
        /// </summary>
        /// <returns>User</returns>
        public User GetAuthenticatedUser()
        {
            if(_httpContext==null||
                _httpContext.Request==null||
                !_httpContext.Request.IsAuthenticated||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;
            var user = GetAuthenticatedUserFromTicket(formsIdentity.Ticket);

            if (user != null && user.IsActive)
                return user;

            return user;

        }
    }
}
