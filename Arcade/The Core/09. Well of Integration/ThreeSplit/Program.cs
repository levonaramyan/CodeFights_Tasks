using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You have a long strip of paper with integers written on it in a single line from left to right.
// You wish to cut the paper into exactly three pieces such that each piece contains at least
// one integer and the sum of the integers in each piece is the same.
// You cannot cut through a number, i.e. each initial number will unambiguously belong to one of the pieces
// after cutting. How many ways can you do it?
// It is guaranteed that the sum of all elements in the array is divisible by 3.
// Example:
//          For a = [0, -1, 0, -1, 0, -1], the output should be
//          threeSplit(a) = 4.
//          Here are all possible ways:
//          [0, -1] [0, -1] [0, -1]
//          [0, -1] [0, -1, 0] [-1]
//          [0, -1, 0] [-1, 0] [-1]
//          [0, -1, 0] [-1] [0, -1]

namespace ThreeSplit
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int threeSplit(int[] a)
        {
            int len = a.Length;
            int[] sums = new int[len];
            int count = 0;
            sums[0] = a[0];

            for (int i = 1; i < len; i++)
            {
                sums[i] = sums[i - 1] + a[i];
            }

            for (int i = 0; i < len - 2; i++)
            {
                for (int j = i + 1; j < len - 1; j++)
                {
                    if (sums[i] == sums[j] - sums[i] && sums[i] == sums[len - 1] - sums[j])
                        count++;
                }
            }

            return count;

        }

    }
}
