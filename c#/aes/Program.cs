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
            try {
                var root = args[1];
                var key = File.ReadAllText(root + "/data/key");
                Console.WriteLine("key: " + key);
                var token = File.ReadAllText(root + "/data/encrypted");
                Console.WriteLine("token: " + token);
                var decoded64 = SimpleFernet.Decrypt(Base64StringExtensions.UrlSafe64Decode(key), token, out var timestamp);
                var decoded = decoded64.UrlSafe64Encode().FromBase64String();
                Console.WriteLine("decrypted:\n" + decoded);
            } catch (IndexOutOfRangeException) {
                Console.WriteLine("Specify the root of the project as first parameter.");
                System.Environment.Exit(-1);
            }
        }
    }
}
