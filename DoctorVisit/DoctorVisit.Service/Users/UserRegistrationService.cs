using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorVisit.Core.Domain.Users;
using DoctorVisit.Service.Common;
using DoctorVisit.Service.Security;

namespace DoctorVisit.Service.Users
{
    /// <summary>
    /// User registration service
    /// </summary>
    public partial class UserRegistrationService : IUserRegistrationService
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IDoctorVisitResult _doctorVisitResult;
        private readonly IEncryptionService _encryptionService;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userService">User service</param>
        /// <param name="doctorVisitResult">Doctor Visit Result</param>
        /// /// <param name="encryptionService">Encryption service</param>
        public UserRegistrationService(IUserService userService,
            IDoctorVisitResult doctorVisitResult,
            IEncryptionService encryptionService)
        {
            _userService = userService;

            _doctorVisitResult = doctorVisitResult;
            _encryptionService = encryptionService;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="usernameOrEmail">Username or Email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public UserLoginResults ValidateUser(string usernameOrEmail, string password)
        {
            var user = _userService.GetUserByUsernameOrEmail(usernameOrEmail);

            if (user == null)
                return UserLoginResults.UserNotExist;

            if (!user.IsActive)
                return UserLoginResults.NotActive;

            string hashedPassword = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);
            bool isValid = hashedPassword == user.Password;
            if (!isValid)
                return UserLoginResults.WrongPassword;

            // TODO save last login date

            return UserLoginResults.Successful;
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Result</returns>
        public IDoctorVisitResult RegisterUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            // TODO check if user is registered

            if(string.IsNullOrEmpty(user.Username))
            {
                _doctorVisitResult.AddError("Username is not provided.");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                _doctorVisitResult.AddError("Email is not provided.");
            }

            // TODO check valid email address

            if (string.IsNullOrEmpty(user.Password))
            {
                _doctorVisitResult.AddError("Password is not provided.");
            }

            // TODO: validate unique username
            // TODO: validate unique email

            string saltKey = _encryptionService.CreateSaltKey(5);
            user.PasswordSalt = saltKey;
            user.Password = _encryptionService.CreatePasswordHash(user.Password, saltKey);

            // TODO register roles


            _userService.RegisterUser(user);

            return _doctorVisitResult;
        }

        #endregion Methods
    }
}
