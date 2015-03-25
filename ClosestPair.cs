using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*CHALLENGE DESCRIPTION:

Credits: Programming Challenges by Steven S. Skiena and Miguel A. Revilla 

You will be given the x/y co-ordinates of several locations. 
You will be laying out 1 cable between two of these locations. 
In order to minimise the cost, your task is to find the shortest distance
between a pair of locations, so that pair can be chosen for the cable installation.

INPUT SAMPLE:

Your program should accept as its first argument a path to a filename. 
The input file contains several sets of input. Each set of input starts with 
an integer N (0<=N<=10000), which denotes the number of points in this set. 
The next N line contains the coordinates of N two-dimensional points. 
The first of the two numbers denotes the X-coordinate and the latter denotes 
the Y-coordinate. The input is terminated by a set whose N=0. 
This set should not be processed. The value of the coordinates will be less 
than 40000 and non-negative. 

OUTPUT SAMPLE:

For each set of input produce a single line of output containing a floating point 
number (with four digits after the decimal point) which denotes the distance between 
the closest two points. If there is no such two points in the input whose distance is
less than 10000, print the line INFINITY  */

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
