using System;
using System.IO;
using System.Text;
using Fernet;

namespace aes
{
    class Program
    {
        static void Main(string[] args)
        {
            // var data = "/home/jw/projects/aes/data";
            Console.WriteLine("Fernet");

            // var key = SimpleFernet.GenerateKey().UrlSafe64Decode();
            var key = File.ReadAllText("/home/jw/projects/aes/data/key");
            Console.WriteLine(key);

            var token = File.ReadAllText("/home/jw/projects/aes/data/encrypted");
            Console.WriteLine(token);
            var decoded64 = SimpleFernet.Decrypt(Base64StringExtensions.UrlSafe64Decode(key), token, out var timestamp);
            var decoded = decoded64.UrlSafe64Encode().FromBase64String();
            Console.WriteLine(decoded);
        }
    }
}
