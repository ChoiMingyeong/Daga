using System.Security.Cryptography;
using System.Text;

namespace DagaUtility.Security
{
    public class Password
    {
        public readonly string Hash;

        public Password(string input)
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            Hash = Convert.ToBase64String(hashBytes);
        }
    }
}
