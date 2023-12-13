using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Password_Manager.MVVM.Model.Static_Helpers
{
    internal static class Encryptor
    {
        public static byte[] saltBytes = [1, 2, 3, 4, 5, 6, 7, 8];

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = [];

            using (MemoryStream ms = WithMemoryStream())
            {
                using (RijndaelManaged AES = WithAES())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = CreateDeriveBytesInstance(passwordBytes, saltBytes, 1000);
                    AES.Key = GetKeyBytes(key, AES.KeySize / 8);
                    AES.IV = GetKeyBytes(key, AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = WithCryptoStream(ms, CreateEncryptor(AES), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = [];


            using (MemoryStream ms = WithMemoryStream())
            {
                using (RijndaelManaged AES = WithAES())
                {

                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = CreateDeriveBytesInstance(passwordBytes, saltBytes, 1000);
                    AES.Key = GetKeyBytes(key, AES.KeySize / 8);
                    AES.IV = GetKeyBytes(key, AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = WithCryptoStream(ms, CreateDecryptor(AES), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();

                }
            }

            return decryptedBytes;
        }

        public static ICryptoTransform CreateEncryptor(RijndaelManaged managed)
        {
            return managed.CreateEncryptor();
        }
        public static ICryptoTransform CreateDecryptor(RijndaelManaged managed)
        {
            return managed.CreateDecryptor();
        }

        public static byte[] GetKeyBytes(Rfc2898DeriveBytes key, int size)
        {
            return key.GetBytes(size);
        }

        public static MemoryStream WithMemoryStream()
        {
            return new MemoryStream();
        }
        public static RijndaelManaged WithAES()
        {
            return new RijndaelManaged();
        }
        public static Rfc2898DeriveBytes CreateDeriveBytesInstance(byte[] passwordBytes, byte[] saltBytes, int iterations)
        {
            return new Rfc2898DeriveBytes(passwordBytes, saltBytes, iterations);
        }
        public static CryptoStream WithCryptoStream(Stream ms, ICryptoTransform transform, CryptoStreamMode mode)
        {
            return new CryptoStream(ms, transform, mode);
        }
    }
}
