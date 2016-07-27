using DoctorVisit.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Authentication
{
    public interface IDoctorVisitPrincipalService : IPrincipal
    {
        User User { get; }
    }
}
