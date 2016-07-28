namespace DoctorVisit.Core.Domain.Users
{
    /// <summary>
    /// Represents the user login result enumeration
    /// </summary>
    public enum UserLoginResults
    {
        /// <summary>
        /// Login successful
        /// </summary>
        Successful = 1,

        /// <summary>
        /// User does not exist (email or username)
        /// </summary>
        UserNotExist = 2,

        /// <summary>
        /// Wrong password
        /// </summary>
        WrongPassword = 3,

        /// <summary>
        /// Account has not been activated
        /// </summary>
        NotActive = 4
    }
}
