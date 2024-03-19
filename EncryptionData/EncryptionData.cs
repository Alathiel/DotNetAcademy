using System.Security.Cryptography;
using System.Text;

namespace EncryptionData
{
    public class EncryptionData
    {
        public static string Sha256Encrypt(string notEncrypted)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(notEncrypted);

            if(notEncrypted.Length > 0 )
            {
                try
                {
                    byte[] hash = sha256.ComputeHash(bytes);
                    return BitConverter.ToString(hash, 0, hash.Length).Replace("-","");
                }
                catch( Exception e) { Console.WriteLine(e); }
            }
            return string.Empty;

        }
    }
}
