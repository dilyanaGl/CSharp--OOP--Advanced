using System;
using System.Collections.Generic;
using System.Text;

namespace MatchClass
{
    public class MathOperations
    {
        private double num;

        public MathOperations(double num)
        {
            this.num = num;
        }

        public double Abs()
        {
            if (num < 0)
            {
                return num * -1;
            }

            return num;
        }

        public double Floor()
        {
           return num - (num % 1);
        }
    }
}
