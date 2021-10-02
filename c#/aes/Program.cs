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
            var key = File.ReadAllText("/home/jw/projects/aes/data/key");
            Console.WriteLine("key: " + key);
            var token = File.ReadAllText("/home/jw/projects/aes/data/encrypted");
            Console.WriteLine("token: " + token);
            var decoded64 = SimpleFernet.Decrypt(Base64StringExtensions.UrlSafe64Decode(key), token, out var timestamp);
            var decoded = decoded64.UrlSafe64Encode().FromBase64String();
            Console.WriteLine("decrypted:\n" + decoded);
        }
    }
}
