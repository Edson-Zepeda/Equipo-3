using System;
using System.Security.Cryptography;
using System.Text;

namespace Prototipo2
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            string salt = Guid.NewGuid().ToString("N");
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(salt + password);
                var hash = sha.ComputeHash(bytes);
                var digest = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                return salt + "$" + digest;
            }
        }

        public static bool VerifyPassword(string password, string stored)
        {
            try
            {
                var parts = stored.Split('$');
                if (parts.Length != 2) return false;
                var salt = parts[0];
                var digest = parts[1];
                using (var sha = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(salt + password);
                    var hash = sha.ComputeHash(bytes);
                    var computed = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    return string.Equals(computed, digest, StringComparison.OrdinalIgnoreCase);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
