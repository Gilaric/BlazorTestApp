using System.Security.Cryptography;

namespace BlazorTestApp.Encryption
{
    public class AsymmetricDecrypter
    {
        public static string Decrypt(string textToDecrypt, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                byte[] byteArrayTextToDecrypt = System.Text.Encoding.UTF8.GetBytes(textToDecrypt);
                byte[] byteArrayEncryptedValue = rsa.Encrypt(byteArrayTextToDecrypt, true);
                var encryptedDataAsString = Convert.ToBase64String(byteArrayEncryptedValue);

                return encryptedDataAsString;
            }
        }
    }
}
