using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You probably know about the famous Fibonacci sequence, which involves generating terms by adding up
// the previous two terms. But did you know that the concept can be extended to the general n-bonacci numbers,
// where each term is the sum of the previous n terms?
// For example, [1, 1, 1, 3, 5, 9, 17, 31] is a 3-bonacci sequence, since each term is the sum of the
// previous 3 terms(except for the first 3 terms).
// PROBLEM: Given a sequence of numbers(in the form of an array of integers), your task is to find
//          the "degree" of the n-bonacci sequence(in other words, find the value of n).
//          If the sequence does not form an n-bonacci sequence, return -1.
// Example:
//          For sequence = [1, 2, 3], the output should be nbonacciDegree(sequence) = 2.
//          It's not a very long sequence, but since 1 + 2 = 3, it qualifies as a 2-bonacci sequence,
//          so the answer is 2.
//
//          For sequence = [0, 6, -2, 3, 7, 14, 22, 46, 89, 171, 328, 634, 1222, 2355],
//          the output should be nbonacciDegree(sequence) = 4.
//          After the first four terms, each term of the sequence is the sum of the previous 4 terms,
//          so the answer is 4.
//
//          For sequence = [1, 2, 5], the output should be nbonacciDegree(sequence) = -1.
//          This sequence does not qualify as n-bonacci, since none of the terms are sums
//          of any number of previous terms.

namespace NBonacciDegree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = new int[] { 1, 0, -1, 0, -1, -2, -3, -6, -11, -20 };
            Console.WriteLine(nbonacciDegree(test));
            Console.ReadKey();
        }

        static int nbonacciDegree(int[] sequence)
        {
            int res = -1;
            List<int> n = new List<int>();
            int[] sum = new int[sequence.Length];
            sum[0] = sequence[0];

            // Calculating the sum of elements, from beginning to i-th elem
            // If finding a case when sum[i-1] equals to sequence[i], then add the index to a list
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] == sum[i - 1]) n.Add(i);
                sum[i] = sum[i - 1] + sequence[i];
            }

            if (n.Count == 0) return res;
            n.OrderByDescending(i => i);

            // iterating in the list until, finding the first (the biggest) nBonacci n
            while (n.Count > 0)
            {
                bool isBon = true;
                int curN = n.ElementAt(0);
                for (int i = curN + 1; isBon && i < sequence.Length; i++)
                    if (sum[i - 1] - sum[i - curN - 1] != sequence[i]) isBon = false;
                if (isBon)
                {
                    res = curN;
                    break;
                }

                n.RemoveAt(0);
            }

            return res;
        }
    }
}
