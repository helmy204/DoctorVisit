using DoctorVisit.Service.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoctorVisit.Web.Framework.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class UserAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (filterContext.HttpContext.User == null)
                throw new ArgumentNullException("filterContext.HttpContext.User");

            var _principalService = DependencyResolver.Current.GetService<IDoctorVisitPrincipalService>();

            if (_principalService.User == null)
                this.HandleUnauthorizedRequest(filterContext);

            if (!_principalService.Identity.IsAuthenticated)
                this.HandleUnauthorizedRequest(filterContext);

            filterContext.HttpContext.User = _principalService;

            // if using Athorize attribute only
            base.OnAuthorization(filterContext);
        }

    }
}
