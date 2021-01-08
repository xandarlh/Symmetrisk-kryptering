using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SymmertriskKryptering
{
    public class Encryption
    {
        public SymmetricAlgorithm symmetricAlgorithm;
        
        public void GenerateSymmetricAlg(int number)
        {
            switch (number)
            {
                case 1:
                    symmetricAlgorithm = DES.Create();
                    break;
                case 2:
                    symmetricAlgorithm = TripleDES.Create();
                    break;     
                case 3:
                    symmetricAlgorithm = Aes.Create();
                    break;
                default:
                    break;
            }
            symmetricAlgorithm.GenerateKey();
            symmetricAlgorithm.GenerateIV();
        }

        public byte[] Encrypt(byte[] dataToEncrypt)
        {           
                symmetricAlgorithm.Mode = CipherMode.CBC;
                symmetricAlgorithm.Padding = PaddingMode.PKCS7;
              
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
        }
        public byte[] Decrypt(byte[] dataToDecrypt)
        {          
                symmetricAlgorithm.Mode = CipherMode.CBC;
                symmetricAlgorithm.Padding = PaddingMode.PKCS7;
            
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }            
        }
    }
}
