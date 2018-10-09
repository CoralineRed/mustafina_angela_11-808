using System;

namespace Names
{
    internal static class HistogramSample
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            // Двумерный массив дат
            double[,] dates = new double[31, 12];
            int mathesCount = 0;
            int peopleAmount = 23;
            Random rand = new Random();
            // Собираем статистику дней рождения рандомных человек в кол-ве peopleAmount
            for (int i = 0; i < peopleAmount; i++)
            {
                int temp = rand.Next(names.Length);
                if (dates[names[temp].BirthDate.Day - 1, names[temp].BirthDate.Month - 1] == 0)
                    dates[names[temp].BirthDate.Day - 1, names[temp].BirthDate.Month - 1] = 1;
                else
                {
                    dates[names[temp].BirthDate.Day - 1, names[temp].BirthDate.Month - 1] *= 50;
                    mathesCount++;
                }
            }
            string[] days = new string[31];
            for (int i = 1; i < 32; i++)
                days[i - 1] = i.ToString();
            string[] months = new string[12];
            for (int i = 1; i < 13; i++)
                months[i - 1] = i.ToString();
            return new HeatmapData($"Количество совпадений - {mathesCount}",
                dates, days, months);
        }
    }
}