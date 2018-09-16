using System;
using System.Security.Cryptography;
using System.Text;

namespace AuditoriasCiudadanas.Shared
{
    public static class Cipher
    {
        public static string SHA256Encripta(string input)
        {
            var provider = new SHA256CryptoServiceProvider();

            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashedBytes = provider.ComputeHash(inputBytes);

            var output = new StringBuilder();

            foreach (var t in hashedBytes)
                output.Append(t.ToString("x2").ToLower());

            return output.ToString();
        }
    }
}