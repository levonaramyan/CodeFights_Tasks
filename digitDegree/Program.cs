using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Let's define digit degree of some positive integer as the number of times we need 
// to replace this number with the sum of its digits until we get to a one digit number.
// PROBLEM: Given an integer, find its digit degree.

namespace digitDegree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test number and printing the result of the test
            int n = 10;        
            Console.WriteLine(digitDegree(n));
            Console.ReadKey();

        }

        //the method returns the digit degree of a given number n
        static int digitDegree(int n)
        {
            int j = 0; // will be the digit degree

            // while the sum of digits is not one digit, make the number a sum of its digits
            while (n.ToString().Length != 1)
            {
                string nStr = n.ToString();
                int digitSum = 0;
                foreach (char i in nStr)
                {
                    digitSum += Convert.ToInt32($"{i}");
                }

                n = digitSum;
                j++;
            }

            return j;
        }


    }
}
