using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROBLEM: Check if all digits of the given integer are even.

namespace evenDigitsOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing a test variable and printing the result of test
            int a = 246841;
            Console.WriteLine(EvenDigitsOnly(a));
            Console.ReadKey();
            
        }

        // The method returns whether all of the digits in n are even
        static bool EvenDigitsOnly (int n)
        {
            string s = Convert.ToString(n);
            bool areEven = true;

            foreach (char i in s)
            {
                if (Convert.ToInt32(i) % 2 != 0)
                {
                    areEven = false;
                    break;
                }
            }

            return areEven;
        }
    }
}
