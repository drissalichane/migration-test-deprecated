using System;
using System.Net;
using System.Security.Cryptography;

namespace MigrationTestDeprecated
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching data using deprecated WebClient...");
            using (var client = new WebClient())
            {
                // WebClient is deprecated in modern .NET (HttpClient is preferred)
                try {
                    string data = client.DownloadString("https://api.github.com");
                    Console.WriteLine("Data downloaded.");
                } catch { }
            }

            Console.WriteLine("Generating random bytes using deprecated RNGCryptoServiceProvider...");
            // RNGCryptoServiceProvider is deprecated (RandomNumberGenerator.Create() is preferred)
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[16];
                rng.GetBytes(bytes);
                Console.WriteLine(Convert.ToBase64String(bytes));
            }
        }
    }
}
