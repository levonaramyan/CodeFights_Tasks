using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given two strings s and t of the same length, consisting of uppercase English letters.
// Your task is to find the minimum number of "replacement operations" needed to get some anagram
// of the string t from the string s. A replacement operation is performed by picking exactly
// one character from the string s and replacing it by some other character.
// Example:
//          For s = "AABAA" and t = "BBAAA", the output should be
//          createAnagram(s, t) = 1;
//
//          For s = "OVGHK" and t = "RPGUC", the output should be
//          createAnagram(s, t) = 4.

namespace CreateAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(createAnagram("AABAA","BBAAA"));
            Console.ReadKey();
        }

        // Returns the number of replacements needed to get the anagram of t from s.
        static int createAnagram(string s, string t)
        {
            // For each s[i] char removing it from t (if found)
            // the number of replacements is the final length of t 
            for (int i = 0; i < s.Length; i++)
            {
                int j = t.IndexOf(s[i]);
                if (j >= 0 && j < t.Length)
                {
                    t = (j == t.Length - 1) ? t.Substring(0, j) : t.Substring(0, j) + t.Substring(j + 1);
                }
            }

            return t.Length;
        }
    }
}
