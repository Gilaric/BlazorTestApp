using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace BlazorTestApp.Hashing
{

    public enum HashedFormat
    {
        String,
        ByteArray,
        Int,
        UTFString,
        HexString
    }
    public class HashingHandler
    {
        [Obsolete]
        public string MD5Hashing(string textToHash)
        {
            MD5 mD5 = MD5.Create();

            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);

            byte[] hashedValue = mD5.ComputeHash(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValue);
        }

        public string SHA2Hashing(string textToHash)
        {
            SHA256 sha2 = SHA256.Create();

            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);

            byte[] hashedValue = sha2.ComputeHash(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValue);
        }

        public string SHA3Hashing(string textToHash)
        {
            SHA3_256 sha3 = SHA3_256.Create();

            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);

            byte[] hashedValue = sha3.ComputeHash(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValue);
        }

        public string HMACHashing(string textToHash, string myKey)
        {
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);
            byte[] myKey1 = Encoding.ASCII.GetBytes(myKey);

            HMACSHA256 hmac = new HMACSHA256();
            hmac.Key = myKey1;

            byte[] hashedValue = hmac.ComputeHash(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValue);
        }

        public string PBKDF2Hashing(string textToHash, string mySalt)
        {
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);
            byte[] byteArraySalt = Encoding.ASCII.GetBytes(mySalt);
            var hashingAlgo = new HashAlgorithmName("SHA256");
            var iteration = 10;

            // 
            byte[] hashedValue = Rfc2898DeriveBytes.Pbkdf2(byteArrayTextToHash, byteArraySalt, iteration, hashingAlgo, 32);

            return Convert.ToBase64String(hashedValue);
        }

        public string BCryptHashing(string textToHash)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, true, BCrypt.Net.HashType.SHA256);
        }

        public bool BCryptVerify(string textToHash, string hashedValue)
        {
            return BCrypt.Net.BCrypt.Verify(textToHash, hashedValue, true, BCrypt.Net.HashType.SHA256);
        }

        public object ConvertValue(string hashedValue, HashedFormat format)
        {
            byte[] byteValue = Encoding.UTF8.GetBytes(hashedValue);

            switch (format)
            {
                case HashedFormat.String:
                    return Convert.ToBase64String(byteValue);
                case HashedFormat.ByteArray:
                    return byteValue;
                case HashedFormat.Int:
                    return BitConverter.ToInt32(byteValue, 0);
                case HashedFormat.HexString:
                    return BitConverter.ToString(byteValue).Replace("-", "");
                case HashedFormat.UTFString:
                    return Encoding.UTF8.GetString(byteValue);
                default:
                    throw new ArgumentException("Du skal vælge et format");
            }
        }
    }
}
