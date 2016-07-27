using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DoctorVisit.Core.Domain.Users;
using System.Web;
using DoctorVisit.Core.Basis;

namespace DoctorVisit.Service.Authentication
{
    public class DoctorVisitPrincipalService : GenericPrincipal, IDoctorVisitPrincipalService
    {
        #region Fields

        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;

        #endregion Fields

        public DoctorVisitPrincipalService(string[] roles,
            HttpContextBase httpContext,
            IWorkContext workContext)
            : base(httpContext.User.Identity, roles)
        {
            _httpContext = httpContext;
            _workContext = workContext;
            
            Identity = _httpContext.User.Identity;
            User = _workContext.CurrentUser;
        }

        public override IIdentity Identity { get; }

        public User User { get; }
    }
}
