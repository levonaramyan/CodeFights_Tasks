using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROBLEM: Given a string, return its encoding defined as follows:
// * First, the string is divided into the least possible number of disjoint substrings
//   consisting of identical characters: for example, "aabbbc" is divided into["aa", "bbb", "c"]
// * Next, each substring with length greater than one is replaced with a concatenation
//   of its length and the repeating character: for example, substring "bbb" is replaced by "3b"
// * Finally, all the new strings are concatenated together in the same order and a new string is returned.

namespace lineEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(lineEncoding("aaaabbcbbaaa"));
            Console.ReadKey();
        }

        // The method returns the encoded string
        static string lineEncoding(string s)
        {
            int sLen = s.Length; // the length of stris s
            int counter = 1; // will be the number of repeating each character in s
            char countChar; // will be the considered for repeating character 
            string encoded = ""; // will be the final encoded string

            // encoding the string
            for (int i = 0; i < sLen; i++)
            {
                counter = 1;
                countChar = s[i];
                int j = i;

                // if the character is repeating, then count how many times
                while ((j + 1 <= sLen - 1) && s[j] == s[j + 1])
                {
                    counter++;
                    j++;
                    i++;
                }

                // if it the letter is not repeating the add the letter itself, else add both the count and letter
                if (counter == 1) encoded = $"{encoded}{countChar}";
                else encoded = $"{encoded}{counter}{countChar}";
            }

            return encoded;

        }
    }
}
