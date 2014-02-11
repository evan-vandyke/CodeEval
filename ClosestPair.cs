using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClosestPair
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] eachLine = File.ReadAllLines(args[0]);
            List<string> lines = new List<string>();
            int index = Convert.ToInt32(eachLine[0]);
            for (int i = 0; i < eachLine.Length ; i++)
            {
                if ((!eachLine[i].Contains(' ')) && lines.Count>0)
                {
                    float distance = GetDistance(lines);
                    if (distance >= 10000)
                    {
                        Console.WriteLine("INFINITY");
                        lines.Clear();
                    }
                    else
                    {
                        Console.WriteLine("{0:F4}", distance);
                        lines.Clear();
                    }
                }
                else
                {
                    if (eachLine[i].Contains(' '))
                    {
                        lines.Add(eachLine[i]);
                    }
                }

            }
        }
        static float GetDistance(List<string> list)
        {

                List<int> x = new List<int>();
                List<int> y = new List<int>();
                float smallest = 10000f;
                foreach (string val in list)
                {
                    var s = val.Split(' ');
                    x.Add(Convert.ToInt32(s[0]));
                    y.Add(Convert.ToInt32(s[1]));
                }

                if (list.Count > 2)
                {
                    for (int i = 0; i <= list.Count - 2; i++)
                    {
                        for (int j = i + 1; j <= list.Count - 1; j++)
                        {
                            double distance = Math.Sqrt((
                                ((x[i] - x[j]) * (x[i] - x[j])) +
                                ((y[i] - y[j]) * (y[i] - y[j]))));
                            if (smallest > distance)
                            {
                                smallest = (float)distance;
                            }
                        }
                    }
                }
                else
                {
                    double distance = Math.Sqrt((
                        ((x[0] - x[1]) * (x[0] - x[1])) +
                        ((y[0] - y[1]) * (y[0] - y[1]))));
                    if (smallest > distance)
                        smallest = (float)distance;
                }
                return smallest;
        }       
    }
}