//поменять местами значения двух переменных
using System;

namespace expr1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int p = a;
            a = b;
            b = p;
            Console.WriteLine(a.ToString() + ' ' + b.ToString());
            Console.ReadKey();
        }
    }
}
