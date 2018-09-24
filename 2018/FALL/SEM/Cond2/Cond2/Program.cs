using System;

namespace Cond2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();
            int x = int.Parse(input1[0]);
            int y = int.Parse(input1[1]);
            int z = int.Parse(input1[1]);
            int a = int.Parse(input2[0]);
            int b = int.Parse(input2[1]);
            if (x > y)
            {
                int p = x;
                x = y;
                y = p;
            }
            if (x > z)
            {
                int p = x;
                x = z;
                z = p;
            }
            if (x <= Math.Min(a, b) && Math.Min(y, z) <= Math.Max(a, b))
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
