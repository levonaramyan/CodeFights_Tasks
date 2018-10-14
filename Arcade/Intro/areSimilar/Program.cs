using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Two arrays are called similar if one can be obtained from another by swapping at most 
// one pair of elements in one of the arrays.
// Problem: Given two arrays a and b, check whether they are similar.

namespace areSimilar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing two test arrays: a[] and b[]
            int[] a = new int[] { 832, 998, 148, 570, 533, 561, 894, 147, 455, 279 };
            int[] b = new int[] { 832, 998, 148, 570, 533, 561, 455, 147, 894, 279 };

            // Printing whether they will be equal after a swap.
            Console.WriteLine(AreSimilar(a, b));
            Console.ReadKey();

        }

        // A method, which compare two arrays: a and be, and return if they will become equal
        // after one swap of pair of elements
        static bool AreSimilar(int[] a, int[] b)
        {
            // initializing parameters
            int arrLength = a.Length;
            int[] index = new int[2] { 0, 0 };
            int tempSwap;
            bool isSwapEnough = true;

            // finding the indexes of first two differences in a[i] and b[i]
            int j = 0;
            for (int i = 0; i < arrLength && j <= 1 ; i++)
            {
                if (a[i] != b[i])
                {
                    index[j] = i;
                    j++;
                }
            }

            // swaping the first two missmatching element pair
            tempSwap = a[index[0]];
            a[index[0]] = a[index[1]];
            a[index[1]] = tempSwap;

            // checking if a == b, after the swaping procedure
            for (int i = 0; i < arrLength; i++)
            {
                if (a[i] != b[i])
                {
                    isSwapEnough = false;
                    break;
                }
            }

            // returning the result of checking
            return isSwapEnough;
        }
    }
}
