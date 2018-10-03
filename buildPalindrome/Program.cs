using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, find the shortest possible string which can be achieved
// by adding characters to the end of initial string to make it a palindrome.
// Example: For st = "abcdc", the output should be: buildPalindrome(st) = "abcdcba".

namespace buildPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(buildPalindrome("alcbc"));
            Console.ReadKey();
        }

        // The method takes the st and returns the shortest possible palindrome by adding symbols after
        static string buildPalindrome(string st)
        {
            int length = st.Length;
            string stPal = st;
            int steps = 0;

            // Look for the longest palindrome in st, from any index to the end, and counts the shortening
            while (!checkPalindrom(stPal))
            {
                steps++;
                stPal = st.Substring(steps);
            }

            // if the initial st is not palindrome then add the necessary elements
            if (steps != 0)
            {
                for (int i = 1; i <= steps; i++)
                {
                    st = $"{st}{st[steps - i]}";
                }
            }

            return st;

        }

        // The method cheks whether the string s is palindrome
        static bool checkPalindrom(string s)
        {
            bool isPal = true;
            if (s.Length > 1)
            {
                for (int i = 0; i <= s.Length / 2; i++)
                {
                    if (s[i] != s[s.Length - i - 1])
                    {
                        isPal = false;
                        break;
                    }
                }
            }           

            return isPal;
        }
    }
}
