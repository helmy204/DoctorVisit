using DoctorVisit.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorVisit.Core.Domain.Users;
using DoctorVisit.Service.Authentication;

namespace DoctorVisit.Web.Framework
{
    public class WebWorkContext : IWorkContext
    {
        #region Fields

        private readonly IAuthenticationService _authenticationService;

        #endregion Fields

        public WebWorkContext(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Gets or sets current user
        /// </summary>
        public virtual User CurrentUser
        {
            get
            {
                User user = null;


                user = _authenticationService.GetAuthenticatedUser();

                return user;
                
            }

            set
            {
                // TODO Set current user
                throw new NotImplementedException();
            }
        }
    }
}
