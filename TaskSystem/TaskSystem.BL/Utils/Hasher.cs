using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TaskSystem.BL.Utils
{
    public class Hasher
    {
        public static string HashPassword(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }

        }
    }
}
