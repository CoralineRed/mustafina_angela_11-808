using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fibonacci
{
    public class ExperimentResult
    {
        public int Num;
        public double RecResult;
        public double NonRecResult;
        public double MatResult;

        public ExperimentResult(int num, double recRes, double nonRecResult, double matResult)
        {
            Num = num;
            RecResult = recRes;
            NonRecResult = nonRecResult;
            MatResult = matResult;
        }
    }

    public class Profiler
    {
        public List<ExperimentResult> Measure(int maxNum, int repetitionsCount)
        {
            var results = new List<ExperimentResult>();
            for (int num = 0; num <= maxNum; num++)
            {
                // Прогреваем методы.
                Program.RecFib(num);
                Program.NonRecFib(num);
                Program.MatFib(num);
                GC.Collect();
                var recRes = 0; //MeasureTime(Program.RecFib, num, repetitionsCount);
                var nonRecRes = MeasureTime(Program.NonRecFib, num, repetitionsCount);
                var matRes = MeasureTime(Program.MatFib, num, repetitionsCount);
                results.Add(new ExperimentResult(num, recRes, nonRecRes, matRes));
            }
            return results;
        }

        public double MeasureTime(Func<int, int> f, int num, int repCount)
        {
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < repCount; i++)
                f(num);
            watch.Stop();
            return (double)watch.ElapsedMilliseconds / repCount;
        }
    }
}