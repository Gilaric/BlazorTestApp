using System.Security.Cryptography;

namespace BlazorTestApp.Encryption
{
    public class AsymmetricEncrypter
    {
        public static string Encrypt(string textToEncrypt, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                byte[] byteArrayTextToEncrypt = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                byte[] byteArrayEncryptedValue = rsa.Encrypt(byteArrayTextToEncrypt, true);
                var encryptedDataAsString = Convert.ToBase64String(byteArrayEncryptedValue);

                return encryptedDataAsString;
            }
        }
    }
}
