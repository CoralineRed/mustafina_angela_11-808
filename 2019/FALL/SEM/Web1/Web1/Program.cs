using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Web1
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadFileAsync().GetAwaiter();

            Console.WriteLine("Файл загружен");
            Console.Read();
        }

        private static async Task DownloadFileAsync()
        {
            WebClient client = new WebClient();
            await client.DownloadFileTaskAsync(new Uri("https://www.w3.org/TR/PNG/iso_8859-1.txt"),
                "mytxtFile.txt");
        }
    }
}
