using System;
using Fernet;

namespace aes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var key = SimpleFernet.GenerateKey().UrlSafe64Decode();
            var src = "hello";
            var src64 = src.ToBase64String();

            Console.WriteLine(src64);
            var token = SimpleFernet.Encrypt(key, src64.UrlSafe64Decode());
            var token = Convert.FromBase64String('Td7cNxY6ucK-bBUVNxMMdqjokrLBYEXPjHS00WoszQo=');
            Console.WriteLine(token);
            var decoded64 = SimpleFernet.Decrypt(key, token, out var timestamp);
            var decoded = decoded64.UrlSafe64Encode().FromBase64String();
            Console.WriteLine(decoded);
        }
    }
}
