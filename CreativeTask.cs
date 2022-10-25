using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Names
{
    internal class CreativeTask
    {
        public static PiechartData GetFirstLetters(NameData[] names)
        {
            var vowelLetters = new[] {'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я'};
            var lettersCount = new double [vowelLetters.Length];

            foreach(var name in names)
            {
                foreach(var letter in vowelLetters)
                {
                    if (letter == name.Name[0])
                        lettersCount[Array.IndexOf(vowelLetters, letter)]++;
                }
            }

            return new PiechartData("Самые популярные первые гласные буквы имен", 
                vowelLetters
                .Select(leter => leter.ToString())
                .ToArray(),
                lettersCount);
        }
        public static void ShowPiechart(PiechartData data)
        {
            var chart = new ZedGraphControl
            {
                Dock = DockStyle.Fill
            };
            var myPanel = new GraphPane();

            myPanel.Title.Text = data.Title;

            myPanel.Fill = new Fill(Color.White);

            var segments = myPanel.AddPieSlices(data.Values, data.Labels);

            chart.GraphPane = myPanel;
            chart.AxisChange();

            var form = new Form
            {
                Text = data.Title,
                Size = new Size(800, 600)
            };
            form.Controls.Add(chart);
            form.ShowDialog();
        }
    }
}
