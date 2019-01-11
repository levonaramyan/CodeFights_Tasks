using System;
using System.Collections.Generic;
using System.Linq;

// Given a string consisting of lowercase English letters, find the largest square number
// which can be obtained by reordering the string's characters and replacing them with any digits
// you need (leading zeros are not allowed) where same characters always map to the same digits
// and different characters always map to different digits.
// If there is no solution, return -1.
// Example:
//          For s = "ab", the output should be
//          constructSquare(s) = 81.
//          The largest 2-digit square number with different digits is 81.
//
//          For s = "zzz", the output should be
//          constructSquare(s) = -1.
//          There are no 3-digit square numbers with identical digits.
//
//          For s = "aba", the output should be
//          constructSquare(s) = 900.
//          It can be obtained after reordering the initial string into "baa"
//          and replacing "a" with 0 and "b" with 9.

namespace ConstructSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(constructSquare("ab"));
            Console.ReadKey();
        }

        // Returns the maximum square of a number, than could be obtained by replacing letters with digits
        static int constructSquare(string s)
        {
            int maxVal = -1;
            List<int> countL = new List<int>();
            int minNumber = (int)Math.Pow(10, s.Length - 1);

            // Counting the number of each letter in string s
            for (int i = 0; i < 26; i++)
            {
                countL.Add(0);
            }

            for (int i = 0; i < s.Length; i++)
            {
                countL[s[i] - 'a']++;
            }

            countL.Sort();


            // Looking for appropriate number in between sqrt(minNumber) and sqrt(maxNumber)
            for (int k = (int)Math.Floor(Math.Sqrt(minNumber)); k * k < minNumber * 10; k++)
            {
                int num = k * k;
                List<int> coundD = new List<int>();

                // Counting the number of each digit in num
                for (int i = 0; i < 26; i++)
                {
                    coundD.Add(0);
                }
                while (num > 0)
                {
                    coundD[num % 10]++;
                    num /= 10;
                }

                coundD.Sort();

                // if in sorted sequences the number of digits equals to the number letters
                // then get the num
                if (Enumerable.SequenceEqual(countL, coundD))
                {
                    maxVal = k * k;
                }
            }
            return maxVal;
        }
    }
}
