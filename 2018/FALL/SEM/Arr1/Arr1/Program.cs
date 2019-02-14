using System;

namespace Arr1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int k = 3;
            Array.Reverse(array, 0, array.Length);
            Array.Reverse(array, 0, k);
            Array.Reverse(array, k, array.Length - k);
            foreach (var elem in array)
                Console.WriteLine(elem);
        }
    }
}
