using System;

namespace Cond3
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int firstHalf = num[0] + num[1] + num[2];
            int secondHalf = num[3] + num[4] + num[5];
            if (firstHalf < secondHalf && num[5] == '0' || firstHalf > secondHalf && num[5] == '9')
                Console.WriteLine("No");
            else Console.WriteLine("Yes");
        }
    }
}
