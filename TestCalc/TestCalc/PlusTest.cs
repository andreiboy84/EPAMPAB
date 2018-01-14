using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestCalc
{
    [TestFixture]
    public class PlusTest
    {
        [Test]
        public void PlusTest1()
        {
            double result = Calculator.Plus(7, 9);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void PlusTest2()
        {
            double result = Calculator.Plus(4.57, 4);
            double result1 = Calculator.Plus(4.57, 4);
            Assert.AreEqual(result, result1);
        }
        [Test]
        public void PlusTest3()
        {
            double result = Calculator.Plus(4.57, 4);
            Assert.IsNotNull(result);
        }
        [Test]
        public void PlusTest4()
        {
            Assert.IsNaN(Calculator.Plus(Double.NaN, 465));
        }
        [Test]
        public void PlusTest5()
        {
            double result = Calculator.Plus(0, -100);
            Assert.AreEqual(-100, result);
        }
    }
}