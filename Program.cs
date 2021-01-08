using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmertriskKryptering
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Encryption encryption = new Encryption();
                Console.WriteLine("Choose:");
                Console.WriteLine("1) Encrypt");
                Console.WriteLine("2) Decrypt");
                int chosen1 = int.Parse(Console.ReadLine());
                if (chosen1 == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Choose way to encrypt:");
                    Console.WriteLine("1) DES");
                    Console.WriteLine("2) TripleDES");
                    Console.WriteLine("3) Aes");
                    int chosen2 = int.Parse(Console.ReadLine());
                    encryption.GenerateSymmetricAlg(chosen2);
                    Console.Clear();
                    Console.WriteLine("Write text to encrypt");
                    string text = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Plaintext: " + text);
                    Console.WriteLine("Encrypted: " + Convert.ToBase64String(encryption.Encrypt(Encoding.ASCII.GetBytes(text))));
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Choose way to decrypt:");
                    Console.WriteLine("1) DES");
                    Console.WriteLine("2) TripleDES");
                    Console.WriteLine("3) Aes");
                    int chosen3 = int.Parse(Console.ReadLine());
                    encryption.GenerateSymmetricAlg(chosen3);
                    Console.WriteLine("Write encrypted text");
                    string text = Console.ReadLine();


                    Console.WriteLine("Decrypted : " + Convert.ToBase64String(encryption.Decrypt(Encoding.ASCII.GetBytes(text))));

                }
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
