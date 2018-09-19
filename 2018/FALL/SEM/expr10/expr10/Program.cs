//Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5.

using System;

namespace expr10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((3 + 999) * (999 / 3) / 2 + (5 + 995) * (995 / 5) / 2 -
                (15 + 985) * (985 / 15) / 2);
            Console.ReadKey();
        }
    }
}
