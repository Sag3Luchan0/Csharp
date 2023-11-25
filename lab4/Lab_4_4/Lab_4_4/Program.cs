using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Roots
    {
        public delegate double F(double x);

        public static double[] GetRoots(double xStart, double xEnd, double xStep, F function)
        {
            var roots = new List<double>();

            for (double x = xStart; x <= xEnd - xStep; x += xStep)
            {
                if ((function(x) > 0 && function(x + xStep) < 0) || (function(x) < 0 && function(x + xStep) > 0))
                {
                    roots.Add(x);
                }
            }

            return roots.ToArray();
        }
    }

    public class Program
    {
        public static void Main()
        {
            var roots = Roots.GetRoots(-5, 5, 0.0001, Math.Cos);
            foreach (var root in roots)
            {
                Console.WriteLine(root);
            }
        }
    }
}
