using Names;
using System;
using System.Linq;
using System.Security;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var days = Enumerable.Range(1, 31)
                .Select(day => day.ToString())
                .ToArray();

            var birthCounts = new double[31];
            foreach (var day in names)
            {
                if (day.Name == name && day.BirthDate.Day > 1)
                    birthCounts[day.BirthDate.Day - 1]++;
            }

            return new HistogramData($"Рождаемость людей с именем '{name}'", 
                days, 
                birthCounts);
        }
    }
}
