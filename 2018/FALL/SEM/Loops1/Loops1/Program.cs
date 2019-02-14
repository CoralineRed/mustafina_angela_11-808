using System;

namespace Loops1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int reversedNum = 0;
            while (num > 0)
            {
                reversedNum = reversedNum * 10 + num % 10;
                num /= 10;
            }
            Console.WriteLine(reversedNum);
        }
    }
}
