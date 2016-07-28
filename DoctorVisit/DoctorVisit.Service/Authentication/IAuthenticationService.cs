using DoctorVisit.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Authentication
{
    /// <summary>
    /// Authentication service interface
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="createPersistentCookie">A value indicating whether to create a persistent cookie.</param>
        void SignIn(User user,bool createPersistentCookie);

        /// <summary>
        /// Sign out
        /// </summary>
        void SignOut();

        /// <summary>
        /// Get authenticated user
        /// </summary>
        /// <returns>User</returns>
        User GetAuthenticatedUser();
    }
}
