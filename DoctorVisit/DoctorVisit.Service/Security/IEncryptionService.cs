using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Security
{
    /// <summary>
    /// Encryption service interface
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Create salt key
        /// </summary>
        /// <param name="size">Key size</param>
        /// <returns>Salt key</returns>
        string CreateSaltKey(int size);

        /// <summary>
        /// Create a password hash
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="saltkey">Salt key</param>
        /// <param name="passwordFormat">Password format (hash algorithm)</param>
        /// <returns>Password hash</returns>
        string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1");
    }
}
