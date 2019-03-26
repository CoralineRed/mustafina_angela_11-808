using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_ex1
{
    class Program
    {
        public static IEnumerable<string> Linq1(int l, IEnumerable<string> a)
        {
            return a
                .TakeWhile(s => s.Length < l)
                .Where(s => char.IsLetter(s[s.Length - 1]))
                .OrderByDescending(s => s.Length)
                .ThenBy(s => s);
        }

        public static IEnumerable<int> Linq2(int k, IEnumerable<int> a)
        {
            return a
                .Where(x => x % 2 == 0)
                .Except(a.Skip(k))
                .Distinct()
                .Reverse();
        }

        public static IEnumerable<char> Linq3(IEnumerable<string> a)
        {
            return a
                .Select(s => s[0])
                .Reverse();
        }

        public static IEnumerable<string> Linq4(IEnumerable<int> nums)
        {
            return nums
                .Where(n => n % 2 == 1)
                .Select(n => n.ToString())
                .OrderBy(s => s);
        }

        static void Main(string[] args)
        {
            //int count = int.Parse(Console.ReadLine());
            //var list = new List<string>();
            //string s;
            //while ((s = Console.ReadLine()) != "")
            //    list.Add(s);
            //foreach (var e in Linq1(count, list))
            //    Console.WriteLine(e);

            //int k = int.Parse(Console.ReadLine());
            //var a = Console.ReadLine().Split().Select(x => int.Parse(x));
            //foreach (var e in Linq2(k, a))
            //    Console.WriteLine(e);

            Console.ReadKey();
        }
    }
}
