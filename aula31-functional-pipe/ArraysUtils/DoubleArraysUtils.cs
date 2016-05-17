using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysUtils
{
    public class DoubleArraysUtils
    {
        public static double[] sqrt(double[] a)
        {
            return a.Select(n => Math.Sqrt(n)).ToArray();
        }
        public static double[] duplicate(double[] a)
        {
            return a.Select(n => n * 2).ToArray();
        }
        public static double[] square(double[] a)
        {
            return a.Select(n => n * n).ToArray();
        }

    }
}
