using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();

            string pass1 = "123";
            string pass2 = "456";

            byte[] hash1 = sha.ComputeHash(Encoding.UTF8.GetBytes(pass1));
            byte[] hash2 = sha.ComputeHash(Encoding.UTF8.GetBytes(pass2));

            string hash1Base64 = Convert.ToBase64String(hash1);
            string hash2Base64 = Convert.ToBase64String(hash2);

            Console.WriteLine(hash1Base64);
            Console.WriteLine(hash2Base64);

            Console.ReadLine();
        }
    }
}
