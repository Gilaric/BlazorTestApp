using Microsoft.AspNetCore.DataProtection;

namespace BlazorTestApp.Encryption
{
    public class SymmetricEncryptionHandler
    {
        private readonly IDataProtector? _protector;
        public SymmetricEncryptionHandler(IDataProtectionProvider protector)
        {
            _protector = protector.CreateProtector("PhilipThomsen");
        }

        public string EncryptSymmetric(string textToEncrypt) =>  
            _protector.Protect(textToEncrypt);

        public string DecryptSymmetric(string textToDecrypt) =>
            _protector.Unprotect(textToDecrypt);
    }
}
