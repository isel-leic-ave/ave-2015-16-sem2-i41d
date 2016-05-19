using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalPipe;
using System.Diagnostics;

namespace FunctionalPipeTest
{
    [TestClass]
    public class PipeUtilsChainMethodsTest
    {
        [TestMethod]
        public void TestChainMethodV1()
        {
            double[] a1 = { 16, 25 };
            Func<double[], double[]> f = PipeUtils.ChainMethodsV1<double[]>("ArraysUtils.dll");
            double[] res = f(a1); 

            Assert.AreEqual(64, res[0]);
            Assert.AreEqual(100, res[1]);
        }

        [TestMethod]
        public void TestChainMethodV2()
        {
            double[] a1 = { 16, 25 };
            Func<double[], double[]> f = PipeUtils.ChainMethodsV2<double[]>("ArraysUtils.dll");
            double[] res = f(a1);

            Assert.AreEqual(64, res[0]);
            Assert.AreEqual(100, res[1]);
            measurePerformance(f, a1, 10000);
        }

        [TestMethod]
        public void TestChainMethodV3()
        {
            double[] a1 = { 16, 25 };
            Func<double[], double[]> f = PipeUtils.ChainMethodsV3<double[]>("ArraysUtils.dll");
            double[] res = f(a1);

            Assert.AreEqual(64, res[0]);
            Assert.AreEqual(100, res[1]);
            measurePerformance(f, a1, 10000);
        }

        [TestMethod]
        public void TestVariance() 
        {
            B expected = Demo.F1(new B("isel"));
            expected = Demo.F2(expected);
            expected = Demo.F3(expected);
            Assert.AreEqual("ola super", expected.msg);

            Func<B, B> f = PipeUtils.ChainMethodsV2<B>("VarianceUtils.dll");
            Assert.AreEqual(expected.msg, f(new B("isel")).msg);
        }

        static void measurePerformance(Func<double[], double[]> f, double[] a, int max)
        {
            double duration = double.MaxValue;
            Stopwatch time = new Stopwatch();
            for (int i = 0; i < 15; i++)
            {
                time.Start();
                a = ExecuteMany(f, a, 10000); // Medir o tempo de execução de f
                double test = time.Elapsed.TotalMilliseconds;
                duration = test < duration ? test : duration;
            }
            Console.WriteLine("Duration = " + duration + " ms");
        }
        static double[] ExecuteMany(Func<double[], double[]> f, double[] a, int max)
        {
            for (int i = 0; i < max; i++)
            {
                a = f(a);
            }
            return a;
        }


    }
    
}
