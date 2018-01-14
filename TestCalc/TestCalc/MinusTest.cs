using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalc
{
    [TestFixture]
     public class MinusTest
    {

        [Test]
        public void MinusTest1()
        {
            double result = Calculator.Minus(56, 3);
            Assert.AreEqual(49, result);
        }
        [Test]
        public void MinusTest2()
        {
            double result = Calculator.Minus(53, 3);
            Assert.IsNotNull(result);
        }
        [Test]
        public void MinusTest3()
        {
            Assert.IsNaN(Calculator.Minus(Double.NaN, 456));
        }
        [Test]
        public void MinusTest4()
        {
            double result = Calculator.Minus(-2, 10);
            Assert.AreEqual(-12, result);
        }
        [Test]
        public void MinusTest5()
        {
            double result = Calculator.Minus(1025, 3);
            Assert.AreEqual(1022, result);

        }
    }
}
