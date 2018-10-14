using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, output its longest prefix which contains only digits.
// For inputString="123aa1", the output should be
// longestDigitsPrefix(inputString) = "123"

namespace longestDigitsPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test string and printing the test result
            string inputString = "0123456789";            
            Console.WriteLine(longestDigitsPrefix(inputString));
            Console.ReadKey();

        }

        // The method returns the longest prefix of digits
        static string longestDigitsPrefix(string inputString)
        {
            string prefix1 = ""; // will be the longest prefix
            string prefix2 = ""; // will be temporary prefix, through the string

            // checking the chars of the string one by one
            foreach (char i in inputString)
            {
                if (char.IsDigit(i)) // if it is a digit then add it in temporary prefix
                {
                    prefix2 += $"{i}";
                    if (prefix2.Length == inputString.Length) // exception, if the whole string is with digits
                    {
                        prefix1 = prefix2;
                        prefix2 = "";
                    }
                }
                else if (char.IsLetter(i)) // when finding a letter, check the length with the maximum founded
                                           // before prefix1 and if the new prefix is longer, then take it
                {
                    if (prefix2.Length > prefix1.Length)
                    {
                        prefix1 = prefix2;
                    }
                    prefix2 = "";
                }
                else prefix2 = "";
            }

            // Returning the longest prefix
            return prefix1;
        }


    }
}
