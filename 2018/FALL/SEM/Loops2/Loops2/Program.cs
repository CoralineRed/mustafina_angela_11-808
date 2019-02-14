using System;

namespace Loops2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cnt = 0;
            for (int i = 1; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (n - i - j >= 0 && n - i - j < 10)
                        cnt++;
            Console.WriteLine(cnt);
        }
    }
}
