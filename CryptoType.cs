using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using System.IO;
namespace Business
{
    public class CryptoEncryption : IEncryptAndDecrypt
    {
        private readonly Aes myAes;
        private byte[] key = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private byte[] vector = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        public CryptoEncryption()
        { 
            myAes = Aes.Create();
            myAes.Key = key;
            myAes.IV = vector;
        }

        public string Encrypt(string plainText)
        {
            byte[] encrypted;
            
            ICryptoTransform encryptor = myAes.CreateEncryptor(key, vector);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            
                return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string text)
        {
            byte[] value = Convert.FromBase64String(text);
            
            string plainText = null;

             ICryptoTransform decryptor = myAes.CreateDecryptor(key, vector);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(value))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
                    return plainText;
            }
        }
    }

