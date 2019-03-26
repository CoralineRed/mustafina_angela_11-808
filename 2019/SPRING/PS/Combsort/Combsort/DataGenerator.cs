using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combsort
{
    public static class DataGenerator
    {
        public static void GenerateIn(string fileName)
        {
            var rand = new Random(42);
            var lines = new List<string>();
            for (int size = 100; size <= 10000; size += 100)
            {
                var builder = new StringBuilder();
                for (int j = 0; j < size; j++)
                    builder.Append(rand.Next(100000) + " ");
                lines.Add(builder.ToString());
            }
            File.WriteAllLines(fileName, lines);
        }
    }
}
