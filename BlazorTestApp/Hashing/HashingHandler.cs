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
        [Obsolete("MD5 was not designed for password security")]
        public string MD5Hashing(string textToHash)
        {

            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);

            byte[] hashedValue = MD5.HashData(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValue);
        }

        public string SHA2Hashing(string textToHash)
        {

            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);

            byte[] hashedValue = SHA256.HashData(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValue);
        }

        public string SHA3Hashing(string textToHash)
        {
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);

            byte[] hashedValue = SHA3_256.HashData(byteArrayTextToHash);

            return Convert.ToBase64String(hashedValue);
        }

        public string HMACHashing(string textToHash, string myKey)
        {
            byte[] byteArrayTextToHash = Encoding.ASCII.GetBytes(textToHash);
            byte[] myKey1 = Encoding.ASCII.GetBytes(myKey);

            HMACSHA256 hmac = new()
            {
                Key = myKey1
            };

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

            return format switch
            {
                HashedFormat.String => Convert.ToBase64String(byteValue),
                HashedFormat.ByteArray => byteValue,
                HashedFormat.Int => BitConverter.ToInt32(byteValue, 0),
                HashedFormat.HexString => BitConverter.ToString(byteValue).Replace("-", ""),
                HashedFormat.UTFString => Encoding.UTF8.GetString(byteValue),
                _ => throw new ArgumentException("Du skal vælge et format"),
            };
        }
    }
}
