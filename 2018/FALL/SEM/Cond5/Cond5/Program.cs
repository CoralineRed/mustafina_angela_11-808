using System;

namespace Cond5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int l = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            int h = int.Parse(input[2]);
            Console.WriteLine($"min time = {(double)(l / k) * h}");

            Console.WriteLine($"max time = {(double)(l / k) * h + h * ((l % k) * 2 / (l % k + 1))}");
        }
    }
}
