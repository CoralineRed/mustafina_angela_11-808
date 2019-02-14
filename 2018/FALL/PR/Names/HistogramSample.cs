using System;

namespace Names
{
    internal static class HistogramSample
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names)
        {
            int[] arr = new[] { 10, 20, 23, 30, 50, 100, 200, 365};
            string[] amount = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                amount[i] = arr[i].ToString();
            double[] matchesAmount = new double[arr.Length];
            Random rand = new Random();
            double[,] dates = new double[31, 12];
            for (int j = 0; j < arr.Length; j++)
            {
                for (int k = 0; k < arr[j]; k++)
                {
                    for (int i = 0; i < arr[j]; i++)
                    {
                        int temp = rand.Next(names.Length);
                        if (dates[names[temp].BirthDate.Day - 1, names[temp].BirthDate.Month - 1] == 0)
                            dates[names[temp].BirthDate.Day - 1, names[temp].BirthDate.Month - 1] = 1;
                        else
                        {
                            matchesAmount[j]++;
                        }
                    }
                }
                matchesAmount[j] /= arr[j];
            }
            
            return new HistogramData(string.Format("kdjbnd"), amount, matchesAmount);
        }

        
    }
}