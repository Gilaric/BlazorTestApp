using System.IO;
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
            string privateKeyPath = Path.Combine("PrivateKeys.pem");
            string publicKeyPath = Path.Combine("PublicKeys.pem");
            using (RSA rsa = RSA.Create())
            {

                // ExportParameters: true = private, false = public
                // Private key
                RSAParameters privateKeyParams = rsa.ExportParameters(true);
                _privateKey = rsa.ToXmlString(true);
                if (!File.Exists(privateKeyPath))
                {
                    File.WriteAllText(privateKeyPath, _privateKey);
                }

                // ExportParameters: true = private, false = public
                // Public key
                RSAParameters publicKeyParams = rsa.ExportParameters(false);
                _publicKey = rsa.ToXmlString(false);
                if (!File.Exists(publicKeyPath))
                {
                    File.WriteAllText(publicKeyPath, _publicKey);
                }
            }
        }

        public string Encrypt(string textToEncrypt)
        {
            if (File.Exists("PublicKeys.pem"))
            {
                _publicKey = File.ReadAllText("PublicKeys.pem");
            }
            string encryptedValue = AsymmetricEncrypter.Encrypt(textToEncrypt, _publicKey);
            return encryptedValue;
        }

        public string Decrypt(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                if (File.Exists("PrivateKeys.pem"))
                {
                    _privateKey = File.ReadAllText("PrivateKeys.pem");
                }
                rsa.FromXmlString(_privateKey);

                byte[] byteArrayTextToDecrypt = Convert.FromBase64String(textToDecrypt);
                byte[] byteArrayDecryptedValue = rsa.Decrypt(byteArrayTextToDecrypt, true);
                var decryptedDataAsString = System.Text.Encoding.UTF8.GetString(byteArrayDecryptedValue);

                return decryptedDataAsString;
            }
        }

        //public void ExportPublicAndPrivateKeys()
        //{
        //    if (!File.Exists("PrivateKeys.pem"))
        //    {
        //        string path = Path.Combine("C:\\Temp\\Storage", "", "PrivateKey.pem");
        //        File.Create(path);
        //        File.WriteAllText(path, _privateKey);
        //    }
        //    else if (!File.Exists("PublicKeys.pem"))
        //    {
        //        string path = Path.Combine("C:\\Temp\\Storage", "", "PublicKeys.pem");
        //        File.Create(path);
        //        File.WriteAllText(path, _publicKey);
        //        string encyptedPublicKeysLines = File.ReadAllText(path);
        //    }
        //}
        //public void ImportPublicAndPrivateKeys()
        //{
        //    string privateKeysPath = Path.Combine("C:\\Temp\\Storage", "", "PrivateKey.pem");
        //    _privateKey = File.ReadAllText(privateKeysPath);

        //    string publicKeysPath = Path.Combine("C:\\Temp\\Storage", "", "PublicKeys.pem");
        //    _publicKey = File.ReadAllText(publicKeysPath);
        //}
    }
}
