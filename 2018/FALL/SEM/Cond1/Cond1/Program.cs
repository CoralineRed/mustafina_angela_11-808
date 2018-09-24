using System;

namespace Cond1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string begin = input[0];
            string end = input[1];
            if (Math.Abs(begin[0] - end[0]) == Math.Abs(begin[1] - end[1])
                && (begin[0] - end[0] + begin[1] - end[1] != 0))
                Console.WriteLine("Correct move for bishop");
            else Console.WriteLine("Incorrect move for bishop");

            if ((Math.Abs(begin[0] - end[0]) == 2 && Math.Abs(begin[1] - end[1]) == 1
                || Math.Abs(begin[0] - end[0]) == 1 && Math.Abs(begin[1] - end[1]) == 2)
                && (begin[0] - end[0] + begin[1] - end[1] != 0))
                Console.WriteLine("Correct move for knight");
            else Console.WriteLine("Incorrect move for knight");

            if ((Math.Abs(begin[0] - end[0]) + Math.Abs(begin[1] - end[1]) == Math.Abs(begin[0] - end[0])
                || Math.Abs(begin[0] - end[0]) + Math.Abs(begin[1] - end[1]) == Math.Abs(begin[1] - end[1]))
                && (begin[0] - end[0] + begin[1] - end[1] != 0))
                Console.WriteLine("Correct move for rook");
            else Console.WriteLine("Incorrect move for rook");

            if ((Math.Abs(end[0] - begin[0]) == Math.Abs(end[1] - begin[1]) || Math.Abs(end[1] - begin[1]) == 0 || Math.Abs(end[0] - begin[0]) == 0)
                && (Math.Abs(end[0] - begin[0]) + Math.Abs(end[1] - begin[1]) != 0))
                Console.WriteLine("Correct move for queen");
            else Console.WriteLine("Incorrect move for queen");

            if (Math.Abs(begin[0] - end[0]) == Math.Abs(begin[1] - end[1]) && Math.Abs(begin[0] - end[0]) == 1)
                Console.WriteLine("Correct move for king");
            else Console.WriteLine("Incorrect move for king");
        }
    }
}
