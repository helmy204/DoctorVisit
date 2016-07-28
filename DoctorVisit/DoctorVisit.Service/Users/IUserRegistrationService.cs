using DoctorVisit.Core.Domain.Users;
using DoctorVisit.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Users
{
    /// <summary>
    /// User registration service interface
    /// </summary>
    public partial interface IUserRegistrationService
    {
        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="usernameOrEmail">Username or Email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        UserLoginResults ValidateUser(string usernameOrEmail, string password);

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Result</returns>
        IDoctorVisitResult RegisterUser(User user);

    }
}
