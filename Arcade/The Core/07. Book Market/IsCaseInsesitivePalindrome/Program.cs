using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, check if it can become a palindrome through a case change of some (possibly, none) letters.
// Example:
//          For inputString = "AaBaa", the output should be
//          isCaseInsensitivePalindrome(inputString) = true.
//          "aabaa" is a palindrome as well as "AABAA", "aaBaa", etc.
//
//          For inputString = "abac", the output should be
//          isCaseInsensitivePalindrome(inputString) = false.
//          All the strings which can be obtained via changing case of some group of letters,
//          i.e. "abac", "Abac", "aBAc" and 13 more, are not palindromes.

namespace IsCaseInsesitivePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(isCaseInsensitivePalindrome("AaBaa"));
            Console.ReadKey();
        }

        // Returns true, if inputString is case-insensitive palindrome
        static bool isCaseInsensitivePalindrome(string inputString)
        {
            // making all of the letters in the string lower-case
            string newStr = inputString.ToLower();

            // Checking if newStr is palindrome
            bool isPol = true; // is true while it is palidrome-like
            for (int i = 0; isPol && i < inputString.Length; i++)
            {
                if (newStr[i] != newStr[newStr.Length - 1 - i]) isPol = false;
            }

            return isPol;

        }
    }
}
