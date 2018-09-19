using System;
using System.Globalization;

namespace Percentages
{
    class Program
    {
        public static double Calculate(string userInput)
        {
            string[] args = userInput.Split();
            double deposit = double.Parse(args[0], CultureInfo.InvariantCulture);
            double percentage = double.Parse(args[1], CultureInfo.InvariantCulture);
            int months = int.Parse(args[2]);
            return deposit * Math.Pow(1 + (double)percentage / 1200, months);
        }

        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(Calculate(str).ToString(CultureInfo.InvariantCulture));
            Console.ReadKey();
        }
    }
}
