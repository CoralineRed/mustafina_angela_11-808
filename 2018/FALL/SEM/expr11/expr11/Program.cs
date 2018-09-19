//Дано время в часах и минутах. Найти угол от часовой к минутной стрелке на обычных часах.

using System;

namespace expr11
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int time = h * 60 + m;
            Console.WriteLine(Math.Abs(m * 5 - time / 2));
            Console.ReadKey();
        }
    }
}
