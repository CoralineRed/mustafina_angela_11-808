using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Combsort
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataGenerator.GenerateIn("data.txt");
            var repetitionCount = 1;
            var arrayResults = new List<Result>();
            var listResults = new List<Result>();
            var arrays = File.ReadAllLines("data.txt");
            foreach (var arrayAsString in arrays)
            {
                var array = ((arrayAsString.Trim().Split()).Select(int.Parse)).ToArray();
                var list = new LinkedList<int>();
                foreach (var e in array)
                    list.AddLast(e);
                var arrayIteration = Sorter<int>.ArraySort(array);
                var listIteration = Sorter<int>.ListSort(list);
                var watch = new Stopwatch();
                GC.Collect();
                watch.Start();
                for (int i = 0; i < repetitionCount; i++)
                    Sorter<int>.ArraySort(array);
                watch.Stop();
                arrayResults.Add(new Result(array.Length, arrayIteration, (double)watch.ElapsedMilliseconds / repetitionCount));

                watch.Restart();
                for (int i = 0; i < repetitionCount; i++)
                    Sorter<int>.ListSort(list);
                watch.Stop();
                listResults.Add(new Result(array.Length, listIteration, (double)watch.ElapsedMilliseconds / repetitionCount));
            }

            var arrayTime = new PointPairList();
            var arrayIterations = new PointPairList();
            foreach (var result in arrayResults)
            {
                arrayTime.Add(result.Size, result.Time);
                arrayIterations.Add(result.Size, result.IterationAmount);
            }

            var listTime = new PointPairList();
            var listIterations = new PointPairList();
            foreach (var result in listResults)
            {
                listTime.Add(result.Size, result.Time);
                listIterations.Add(result.Size, result.IterationAmount);
            }

            Application.Run(CreateForm(CreateChart("Execution Time, ms", arrayTime, listTime)));
            Application.Run(CreateForm(CreateChart("Amount of Iterations", arrayIterations, listIterations)));
        }

        public static Control CreateChart(string yTitle, PointPairList arr, PointPairList list)
        {
            var chart = new ZedGraphControl();
            chart.GraphPane.Title.Text = "Comb sort";
            chart.GraphPane.YAxis.Title.Text = yTitle;
            chart.GraphPane.XAxis.Title.Text = "Amount of Elements";
            chart.GraphPane.YAxis.Scale.MaxAuto = chart.GraphPane.YAxis.Scale.MinAuto = true;
            chart.GraphPane.AddCurve("Array", arr, Color.Red, SymbolType.None);
            chart.GraphPane.AddCurve("List", list, Color.Blue, SymbolType.None);
            chart.AxisChange();
            return chart;
        }

        public static Form CreateForm(Control chart)
        {
            var form = new Form { WindowState = FormWindowState.Maximized };
            chart.Dock = DockStyle.Fill;
            form.Controls.Add(chart);
            return form;
        }
    }
}
