using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, find out if its characters can be rearranged to form a palindrome.

namespace palindromeRearranging
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing a test string for check
            string teststring = "abccbddd";
            
            //Printing the result for above test string
            Console.WriteLine(palindromeRearranging(teststring));
            Console.ReadKey();
        }

        // The method return if it is possible to rearrange the string to palindrome
        static bool palindromeRearranging (string inputString)
        {
            // initializing the variables
            int evenPairs = 0; // will be the number of symbols, which meet in the string even times
            int lenght = inputString.Length; // The length of the string
            bool isPalindromeable;

            // checking if the symbols meet in a string odd times,
            // and return the number of even symbols
            foreach (char i in inputString)
            {
                int charRepeat = 0;

                foreach (char j in inputString)
                {
                    if (Char.Equals(i, j)) charRepeat += 1;
                }

                if (charRepeat % 2 == 1) evenPairs++;
            }

            // if the string is palindromable, then the number of even symbols should be no more than 1
            isPalindromeable = (evenPairs <= 1);

            return isPalindromeable;
        }


    }
}
