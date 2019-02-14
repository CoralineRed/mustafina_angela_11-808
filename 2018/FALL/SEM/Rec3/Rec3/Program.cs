using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rec3
{
    class Program
    {
        static int d = 0;
        static public void PlaceQueens(int[] desk, int position)
        {
            int deskLen = desk.Length;
            if (position == deskLen)
            {
                WriteDesk(desk);
            }
            else
            {
                bool placed = false;
                for (int i = 0; i < deskLen; i++)
                {
                    bool found = true;
                    for (int j = 0; j < position; j++)
                    {
                        if (desk[j] == i || Math.Abs(desk[j] - i) == Math.Abs(j - position))
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        placed = true;
                        desk[position] = i;
                        PlaceQueens(desk, position + 1);
                    }
                }
                if (!placed) return;
            }
        }

        static public void WriteDesk(int[] desk)
        {
            Console.WriteLine(++d);
            int deskLen = desk.Length;
            for (int i = 0; i < deskLen; i++)
            {
                for (int j = 0; j < deskLen; j++)
                    if (desk[j] == i) Console.Write("1 ");
                    else Console.Write("0 ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PlaceQueens(new int[n], 0);
            Console.ReadKey();
        }
    }
}
