using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace BlazorTestApp.Encryption
{
    public class AsymmetricEncryptionHandler
    {
        private string _privateKey;

        private string _publicKey;

        public AsymmetricEncryptionHandler()
        {
            using (RSA rsa = RSA.Create())
            {
                // ExportParameters: true = private, false = public
                // Private key
                RSAParameters privateKeyParams = rsa.ExportParameters(true);
                _privateKey = rsa.ToXmlString(true);

                // ExportParameters: true = private, false = public
                // Public key
                RSAParameters publicKeyParams = rsa.ExportParameters(false);
                _publicKey = rsa.ToXmlString(false);
            }
        }

        public string Encrypt(string textToEncrypt)
        {
            string encryptedValue = AsymmetricEncrypter.Encrypt(textToEncrypt, _publicKey);
            return encryptedValue;
        }

        public string Decrypt(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_privateKey);

                byte[] byteArrayTextToDecrypt = Convert.FromBase64String(textToDecrypt);
                byte[] byteArrayDecryptedValue = rsa.Decrypt(byteArrayTextToDecrypt, true);
                var decryptedDataAsString = System.Text.Encoding.UTF8.GetString(byteArrayDecryptedValue);

                return decryptedDataAsString;
            }
        }
    }
}
