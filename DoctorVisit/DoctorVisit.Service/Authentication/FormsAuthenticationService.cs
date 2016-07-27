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
        private readonly HttpContextBase _httpContext;
        private readonly IUserService _userService;

        public FormsAuthenticationService(HttpContextBase httpContext,
            IUserService userService)
        {
            _httpContext = httpContext;
            _userService = userService;
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
