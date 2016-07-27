using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorVisit.Core.Domain.Users;
using DoctorVisit.Data;

namespace DoctorVisit.Service.Users
{
    /// <summary>
    /// User service
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private readonly IDoctorVisitRepository<User> _userRepository;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userRepository">user repository</param>
        public UserService(IDoctorVisitRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Get user by username or email
        /// </summary>
        /// <param name="usernameOrEmail">Username or Email</param>
        /// <returns>User</returns>
        public User GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            User user = _userRepository.Table.Where(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail).SingleOrDefault();
            return user;
        }

        #endregion Methods
    }
}
