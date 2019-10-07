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
            WebRequest request = WebRequest.Create("https://www.w3.org/TR/PNG/iso_8859-1.txt");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен");
            Console.Read();

        }
    }
}
