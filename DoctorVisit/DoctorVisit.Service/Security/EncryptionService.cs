using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Security
{
    /// <summary>
    /// Encryption service
    /// </summary>
    public class EncryptionService : IEncryptionService
    {
        /// <summary>
        /// Create salt key
        /// </summary>
        /// <param name="size">Key size</param>
        /// <returns>Salt key</returns>
        public string CreateSaltKey(int size)
        {
            // Generate a cryptographic reandom number
            var rng = new RNGCryptoServiceProvider();
            var buffer = new byte[size];
            rng.GetBytes(buffer);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buffer);
        }

        /// <summary>
        /// Create a password hash
        /// </summary>
        /// <param name="password">Password</param>
        /// <param name="saltkey">Salt key</param>
        /// <param name="passwordFormat">Password format (hash algorithm)</param>
        /// <returns>Password hash</returns>
        public string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            string saltAndPassword = string.Concat(password, saltkey);

            var algorithm = HashAlgorithm.Create(passwordFormat);
            if (algorithm == null)
                throw new ArgumentException("Unrecognized hash name");

            var hashByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(saltAndPassword));
            return BitConverter.ToString(hashByteArray).Replace("-", "");
        }
    }
}
