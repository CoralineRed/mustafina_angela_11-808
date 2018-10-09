using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            double[,] dates = new double[30, 12];
            foreach (var person in names)
            {
                if (person.BirthDate.Day != 1)
                    dates[person.BirthDate.Day - 2, person.BirthDate.Month - 1]++;
            }
            string[] days = new string[30];
            for (int i = 2; i < 32; i++)
                days[i - 2] = i.ToString();
            string[] months = new string[12];
            for (int i = 1; i < 13; i++)
                months[i - 1] = i.ToString();
            return new HeatmapData("Пример карты интенсивностей",
                dates, days, months);
        }
    }
}