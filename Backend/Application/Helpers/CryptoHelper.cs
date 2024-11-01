using System.Security.Cryptography;
using System.Text;

namespace Backend.Application.Helpers
{
    public class CryptoHelper
    {
        const int keySize = 64;
        const int iterations = 350000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string GenerarHash(string password, out string salt)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(keySize);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            var hashBytes = Rfc2898DeriveBytes.Pbkdf2(
                passwordBytes,
                saltBytes,
                iterations,
                hashAlgorithm,
                keySize
            );

            salt = Convert.ToBase64String(saltBytes);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerificarHash(string password, string hash, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashBytes = Convert.FromBase64String(hash);

            var hashAComparar = Rfc2898DeriveBytes.Pbkdf2(
                password,
                saltBytes,
                iterations,
                hashAlgorithm,
                keySize
            );

            return CryptographicOperations.FixedTimeEquals(hashAComparar, hashBytes);
        }
    }
}
