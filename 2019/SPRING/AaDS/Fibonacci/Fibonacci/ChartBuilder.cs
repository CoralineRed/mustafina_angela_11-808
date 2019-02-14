using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Fibonacci
{
    class ChartBuilder
    {
        public Control Build(List<ExperimentResult> results)
        {
            var chart = new ZedGraphControl();
            // Задаем параметры графика.
            chart.GraphPane.Title.Text = "Comparing of Different Algorithms";
            chart.GraphPane.YAxis.Title.Text = "Execution Time, ms";
            chart.GraphPane.XAxis.Title.Text = "Fibonacci Number";
            chart.GraphPane.YAxis.Scale.Max = 0.00000000001;
            chart.GraphPane.YAxis.Scale.Min = 0;
            SetCurves(results, chart);
            SetXLabels(results, chart);
            // Обновляем график.
            chart.AxisChange();
            return chart;
        }

        private void SetCurves(List<ExperimentResult> results, ZedGraphControl chart)
        {
            // Создаем листы пар (кол-во полей, время работы) для классов и структур
            var recResults = new PointPairList();
            var nonRecResults = new PointPairList();
            var matResults = new PointPairList();
            // и заполняем их.
            foreach (var result in results)
            {
                recResults.Add(result.Num, result.RecResult);
                nonRecResults.Add(result.Num, result.NonRecResult);
                matResults.Add(result.Num, result.MatResult);
            }
            // Создаем кривые классов и структур.
            //chart.GraphPane.AddCurve("Recursion", recResults, Color.Red);
            chart.GraphPane.AddCurve("NonRecursion", nonRecResults, Color.Blue);
            chart.GraphPane.AddCurve("Matrix", matResults, Color.Green);
        }

        private static void SetXLabels(List<ExperimentResult> results, ZedGraphControl chart)
        {
            var xLabels = new string[results.Count];
            // Заполняем текстовые представления кол-ва полей.
            for (int i = 0; i < results.Count; i++)
                xLabels[i] = i.ToString();
            // Устанавливаем значения оси Х.
            chart.GraphPane.XAxis.Type = AxisType.Text;
            chart.GraphPane.XAxis.Scale.TextLabels = xLabels;
        }
    }
}
