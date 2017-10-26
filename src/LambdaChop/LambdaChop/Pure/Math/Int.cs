using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChop.Pure.Math
{
    public static class Int
    {
        // UNARY OPERATIONS
        public static readonly Func<int, int> Identity = a => a;
        public static readonly Func<int, int> Negate = a => -a;
        public static readonly Func<int, int> Abs = a => a < 0 ? -a : a;
        public static readonly Func<int, int> Square = a => a * a;
        public static readonly Func<int, int> Cube = a => a * a * a;
        public static readonly Func<int, int> Factorial = a =>
        {
            int product = 1;
            while (a > 1)
                product *= a--;
            return product;
        };

        // BINARY OPERATIONS
        public static readonly Func<int, int, int> Add = (a, b) => a + b;
        public static readonly Func<int, int, int> Subtract = (a, b) => a - b;
        public static readonly Func<int, int, int> Multiply = (a, b) => a * b;
        public static readonly Func<int, int, int> Divide = (a, b) => a / b;
        public static readonly Func<int, int, int> Modulo = (a, b) => a % b;
        public static readonly Func<int, int, int> Power = (b, exp) =>
        {
            int product = 1;
            for (int i = 0; i < exp; i++)
                product *= b;
            return product;
        };
        public static readonly Func<int, int, bool> Divides = (a, b) => b % a == 0;
        public static readonly Func<int, int, int> Max = (a, b) => a > b ? a : b;
        public static readonly Func<int, int, int> Min = (a, b) => a < b ? a : b;
        
    }
}
