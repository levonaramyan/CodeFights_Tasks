using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Consider an arithmetic expression of the form a#b=c. Check whether it is possible to replace
// # with one of the four signs: +, -, * or / to obtain a correct expression.

namespace ArithmeticExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(arithmeticExpression(4,5,9));
            Console.ReadKey();
        }

        // Returns true if it could be any of the mentioned arithmetic expressions
        static bool arithmeticExpression(int a, int b, int c)
        {
            return (a + b == c || a - b == c || a * b == c || (a / b == c && a % b == 0));
        }
    }
}
