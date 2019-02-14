using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fibonacci
{
    class Program
    {
        public class Matrix
        {
            public int[,] Mat;

            public Matrix()
            {
                Mat = new[,] { { 0, 1 }, { 1, 1 } };
            }

            public static Matrix operator *(Matrix a, Matrix b)
            {
                var c = new Matrix();
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        c.Mat[i, j] = a.Mat[i, 0] * b.Mat[0, j] + a.Mat[i, 1] * b.Mat[1, j];
                return c;
            }

            public Matrix Pow(int pow)
            {
                if (pow == 1) return new Matrix { Mat = Mat };
                var temp = Pow(pow / 2);
                if (pow % 2 == 0) return temp * temp;
                return temp * temp * this;
            }
        }

        public static int RecFib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return RecFib(n - 1) + RecFib(n - 2);
        }

        public static int NonRecFib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int a = 0;
            int b = 1;
            for (int i = 2; i <= n; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }
            return b;
        }

        public static int MatFib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return new Matrix().Pow(n - 1).Mat[1, 1];
        }

        public static void Run(Profiler profiler, int maxNum, int repetitionsCount, ChartBuilder builder)
        {
            var result = profiler.Measure(maxNum, repetitionsCount);
            var chart = builder.Build(result);
            var form = new Form { ClientSize = new Size(800, 600) };
            chart.Dock = DockStyle.Fill;
            form.Controls.Add(chart);
            Application.Run(form);
        }

        static void Main(string[] args)
        {
            Run(new Profiler(), 30, 3, new ChartBuilder());
            //Run(new Profiler(), 100, 700, new ChartBuilder());

            //var n = int.Parse(Console.ReadLine());
            //Console.WriteLine(RecFib(n));
            //Console.WriteLine(NonRecFib(n));
            //Console.WriteLine(MatFib(n));
            //Console.ReadKey();
        }
    }
}
