using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CodeMaster has just returned from shopping.He scanned the check of the items he bought
// and gave the resulting string to Ratiorg to figure out the total number of purchased items.
// Since Ratiorg is a bot he is definitely going to automate it, so he needs a program
// that sums up all the numbers which appear in the given input.

// Help Ratiorg by writing a function that returns the sum of numbers that appear in the given inputString.

namespace sumUpNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(sumUpNumbers("bjhgg 2323 434 jhugfjdgygeg 23 "));
            Console.ReadKey();
        }

        // The method returns the summ of all numbers in the text
        static int sumUpNumbers(string inputString)
        {
            int num = 0; // the sum
            string curr = ""; // current number

            // checking char by char to find the numbers
            foreach (char i in inputString)
            {
                // when finding a digit, adding in curr
                if (char.IsDigit(i)) curr += $"{i}";
                else
                {
                    if (curr.Length > 0) num += Convert.ToInt32(curr); // if the digits are just ended, add the number
                    curr = "";
                }
            }

            // adding the last number, when it is at the end of the text
            if (curr.Length > 0) num += Convert.ToInt32(curr);

            return num;
        }
    }
}
