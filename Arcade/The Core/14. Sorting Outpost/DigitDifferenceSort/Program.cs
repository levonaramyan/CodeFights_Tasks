using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an array of integers, sort its elements by the difference of their largest and smallest digits.
// In the case of a tie, that with the larger index in the array should come first.
// Example:
//          For a = [152, 23, 7, 887, 243], the output should be
//          digitDifferenceSort(a) = [7, 887, 23, 243, 152].
//          Here are the differences of all the numbers:
//          152: difference = 5 - 1 = 4;
//          23: difference = 3 - 2 = 1;
//          7: difference = 7 - 7 = 0;
//          887: difference = 8 - 7 = 1;
//          243: difference = 4 - 2 = 2.
//          23 and 887 have the same difference, but 887 goes after 23 in a,
//          so in the sorted array it comes first.

namespace DigitDifferenceSort
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] digitDifferenceSort(int[] a)
        {
            int[] dig = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                dig[i] = MaxMinDiff(a[i]);
                int j = i;
                while (j > 0 && dig[j] <= dig[j - 1])
                {
                    int temp = a[j];
                    a[j] = a[j - 1];
                    a[j - 1] = temp;
                    temp = dig[j];
                    dig[j] = dig[j - 1];
                    dig[j - 1] = temp;
                    j--;
                }
            }

            return a;

        }

        static int MaxMinDiff(int n)
        {
            char[] d = $"{n}".ToCharArray();
            Array.Sort(d);
            return (int)d[d.Length - 1] - (int)d[0];
        }


    }
}
