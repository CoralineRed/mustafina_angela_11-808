using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            string[] days = new string[31];
            for (int i = 1; i < 32; i++)
                days[i - 1] = i.ToString();
            double[] peopleCounts = new double[31];
            foreach (var person in names)
                if (person.Name == name && person.BirthDate.Day != 1)
                    peopleCounts[person.BirthDate.Day - 1]++;
            return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), days, peopleCounts);
        }
    }
}