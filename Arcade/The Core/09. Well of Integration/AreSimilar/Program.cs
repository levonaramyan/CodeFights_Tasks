using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Two arrays are called similar if one can be obtained from another by swapping at most one pair
// of elements in one of the arrays.
// PROBLEM: Given two arrays a and b, check whether they are similar.
// Example:
//          For a = [1, 2, 3] and b = [1, 2, 3], the output should be
//          areSimilar(a, b) = true.
//          The arrays are equal, no need to swap any elements.
//
//          For a = [1, 2, 3] and b = [2, 1, 3], the output should be
//          areSimilar(a, b) = true.
//          We can obtain b from a by swapping 2 and 1 in b.
//
//          For a = [1, 2, 2] and b = [2, 1, 1], the output should be
//          areSimilar(a, b) = false.
//          Any swap of any two elements either in a or in b won't make a and b equal.

namespace AreSimilar
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static bool areSimilar(int[] a, int[] b)
        {
            int arrLength = a.Length;
            int[] index = new int[2] { 0, 0 };
            int tempSwap;
            bool isSwapEnough = true;

            int j = 0;
            for (int i = 0; i < arrLength && j <= 1; i++)
            {
                if (a[i] != b[i])
                {
                    index[j] = i;
                    j++;
                }
            }

            tempSwap = a[index[0]];
            a[index[0]] = a[index[1]];
            a[index[1]] = tempSwap;

            for (int i = 0; i < arrLength; i++)
            {
                if (a[i] != b[i])
                {
                    isSwapEnough = false;
                    break;
                }
            }

            return isSwapEnough;
        }

    }
}
