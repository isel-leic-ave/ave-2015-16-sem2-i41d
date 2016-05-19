using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalPipe;

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
    }
    
}
