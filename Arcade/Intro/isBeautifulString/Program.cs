using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A string is said to be beautiful if b occurs in it no more times than a; c occurs in it no more times than b; etc.
// PROBLEM: Given a string, check whether it is beautiful.

namespace isBeautifulString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isBeautifulString("abbc"));
            Console.ReadKey();
        }

        // Returns true if the inputString is "Beautiful"
        static bool isBeautifulString(string inputString)
        {
            bool isBeautiful = true; // will be the returning variable
            int diff = 'z' - 'a'; // the number diff. of chars 'a' and 'z'
            int[] counts = new int[diff+1]; // an array with length of alphabet letters. Will contain counts of letters
            for (int i = 0; i <= diff; i++) counts[i] = 0; // initializing the array to 0-s

            foreach (char i in inputString) counts[i-'a'] += 1; // counting the letters in the string and adding to array

            // checking if counts a >= b >= c >= d .....
            for (int i = 0; i < diff; i++)
            {
                if (counts[i] < counts[i+1])
                {
                    isBeautiful = false;
                    break;
                }
            }
            return isBeautiful;
        }
    }
}
