using System;
using System.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        public static string[] CreatingCoordinateAxis(int minValue, int maxValue) =>
            Enumerable.Range(minValue, maxValue)
            .Select(day => day.ToString())
            .ToArray();

        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var days = CreatingCoordinateAxis(2, 30);
            var months = CreatingCoordinateAxis(1, 12);

            var numberBirths = new double[days.Length, months.Length];

            foreach (var name in names)
            {
                if (name.BirthDate.Day > 1)
                    numberBirths[name.BirthDate.Day - 2, name.BirthDate.Month - 1]++;
            }

            return new HeatmapData("Карта интенсивностей рождаемости", numberBirths, days, months);
        }
    }
}