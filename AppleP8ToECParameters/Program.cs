using System;
using System.Security.Cryptography;
using System.Text.Json;

namespace AppleP8ToECParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Paste Apple p8 private key");

                var p8 = Console.ReadLine();
                var bytes = Convert.FromBase64String(p8);

                var ecd = ECDsa.Create();
                ecd.ImportPkcs8PrivateKey(bytes, out int _);

                var ecp = ecd.ExportParameters(true);
                var json = JsonSerializer.Serialize(new { ecp.D, ecp.Q });

                Console.WriteLine("EC Parameters:");
                Console.WriteLine(json);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}