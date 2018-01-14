using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalc
{
    [TestFixture]
   public class DivisionTest
    {
        [Test]
        public void DivisionTest1()
        {
            double result = Calculator.Division(15, 2);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void DivisionTest2()
        {
            double result = Calculator.Division(43, 32);
            Assert.IsNotNull(result);
        }
        [Test]
        public void DivisionTest3()
        {
            double result = Calculator.Division(5.53, 3);
            double result1 = Calculator.Division(5.53, 3);
            Assert.AreEqual(result, result1);
        }
        [Test]
        public void DivisionTest4()
        {
            Assert.IsNaN(Calculator.Division(Double.NaN, 445));
        }
        public void DivisionTest5()
        {
            double result = Calculator.Division(1025, 5);
            Assert.AreEqual(205, result);

        }
    }
}
