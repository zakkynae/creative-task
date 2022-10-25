using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Names
{
    internal class PiechartData
    {
        public string Title { get; }
        public string[] Labels { get; }
        public double[] Values { get; }

        public PiechartData(string title, string[] labels, double[] values)
        {
            Title = title;
            Labels = labels;
            Values = values; 
        }
    }
}
