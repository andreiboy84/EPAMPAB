using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalc
{
    class Calculator
    {
        public static double Plus(double first, double second)
        {
            return first + second;
        }
        public static double Minus(double first, double second)
        {
            return first - second;
        }
        public static double Division(double first, double second)
        {
            if (second == 0) throw new DivideByZeroException();
            return first / second;
        }
        public static double Multi(double first, double second)
        {
            return first * second;
        }
    }
}
