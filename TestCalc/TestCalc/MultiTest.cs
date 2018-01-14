using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalc
{
    [TestFixture]
    public class MultiTest
    {
        public void MultiTest1()
        {
            double result = Calculator.Multi(2, 3);
            Assert.AreEqual(6, result);
        }
        [Test]
        public void MultiTest2()
        {
            double result = Calculator.Multi(2, 3);
            Assert.IsNotNull(result);
        }
        [Test]
        public void MultiTest3()
        {
            Assert.IsNaN(Calculator.Multi(Double.NaN, 445));
        }
        [Test]
        public void MultiTest4()
        {
            double result = Calculator.Multi(0, -100);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void MultiTest5()
        {
            double result = Calculator.Multi(0, 50);
            Assert.AreEqual(0, result);
        }
    }
}
