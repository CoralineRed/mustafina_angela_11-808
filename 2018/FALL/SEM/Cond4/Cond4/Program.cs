using System;

namespace Cond4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);
            int d = int.Parse(input[3]);
            int intersection = Math.Min(b, d) - Math.Max(a, c);
            if (intersection > 0) Console.WriteLine(intersection);
            else Console.WriteLine(0);
        }
    }
}
