using DoctorVisit.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Users
{
    /// <summary>
    /// User service interface
    /// </summary>
    public interface IUserService
    {

        /// <summary>
        /// Get user by username or email
        /// </summary>
        /// <param name="usernameOrEmail">Username or Email</param>
        /// <returns>User</returns>
        User GetUserByUsernameOrEmail(string usernameOrEmail);
    }
}
