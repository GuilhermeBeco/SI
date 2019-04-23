using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ws6Extra
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalText = File.ReadAllText("dados.txt");
            byte[] originalBytes = Encoding.UTF8.GetBytes(originalText);
            byte[] signatureAndData = File.ReadAllBytes("assinatura_e_dados.txt");
            string pubKey1 = File.ReadAllText("publica_1.txt");
            string pubKey2 = File.ReadAllText("publica_2.txt");
            string pubKey3 = File.ReadAllText("publica_3.txt");
            string pubKey4 = File.ReadAllText("publica_4.txt");
            string pubKey5 = File.ReadAllText("publica_5.txt");

            List<String> pubKeys = new List<string>();
            pubKeys.Add(pubKey1);
            pubKeys.Add(pubKey2);
            pubKeys.Add(pubKey3);
            pubKeys.Add(pubKey4);
            pubKeys.Add(pubKey5);
            byte[] sign = new byte[128];
            Array.Copy(signatureAndData, sign, 128);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
            foreach(String key in pubKeys)
            {
                rsa.FromXmlString(key);
                if (rsa.VerifyData(originalBytes, sha, sign))
                {
                    Console.WriteLine("The following pub key belongs to who signed the data");
                    Console.WriteLine(key);
                }
            }
            Console.ReadLine();
        }
    }
}
