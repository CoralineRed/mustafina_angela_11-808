using System;

namespace Loops4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 1, 3, 5, 4, 4, 4, 4 };
            int max = 0;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                cnt++;
                if (i == array.Length - 1 || array[i] != array[i + 1])
                {
                    if (max < cnt) max = cnt;
                    cnt = 0;
                }
            }
            Console.WriteLine(max);
        }
    }
}
