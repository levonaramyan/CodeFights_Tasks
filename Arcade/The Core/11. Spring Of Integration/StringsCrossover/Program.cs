using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define crossover operation over two equal-length strings A and B as follows:
//      the result of that operation is a string of the same length as the input strings
//      result[i] is either A[i] or B[i], chosen at random
// Given array of strings inputArray and a string result, find for how many pairs of strings
// from inputArray the result of the crossover operation over them may be equal to result.
// Note that (A, B) and (B, A) are the same pair.Also note that the pair cannot include
// the same element of the array twice (however, if there are two equal elements
// in the array, they can form a pair).
// Example:
//          For inputArray = ["abc", "aaa", "aba", "bab"] and result = "bbb", the output should be
//          stringsCrossover(inputArray, result) = 2.

namespace StringsCrossover
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int stringsCrossover(string[] inputArray, string result)
        {
            int c = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
                for (int j = i + 1; j < inputArray.Length; j++)
                    if (IsGoodPair(inputArray[i], inputArray[j], result)) c++;
            return c;
        }

        static bool IsGoodPair(string a, string b, string s)
        {
            bool isOk = true;
            for (int i = 0; isOk && i < a.Length; i++) if (s[i] != a[i] && s[i] != b[i]) isOk = false;
            return isOk;
        }
    }
}
