using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project01.IntroductionToCsharp.Operators.Arithmetic;

    public class Calculator
    {
        public int Sum(int a,int b)
        {
            int c = a + b;

            return c;
        }
        public int Subtract(int a,int b)
        {
            int c = a - b;

            return c;
        }

        public long Multiply(long a,long b)
        {
            long c = a * b;

            return c;
        }

        public double Divide(long a,long b)
        {
            double c = (double)a / b;

            return c;
        }

        public double Pi()
    {
        return 3.1416;
    }

    public double Module(double n1, double n2)
    {
        return n1 % n2;
    }
}
