using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an array of 2k integers (for some integer k), perform the following operations until
// the array contains only one element:
// On the 1st, 3rd, 5th, etc.iterations(1-based) replace each pair of consecutive elements with their sum;
// On the 2nd, 4th, 6th, etc.iterations replace each pair of consecutive elements with their product.
// After the algorithm has finished, there will be a single element left in the array. Return that element.
// Example:
//          For inputArray = [1, 2, 3, 4, 5, 6, 7, 8], the output should be
//          arrayConversion(inputArray) = 186.
//          We have [1, 2, 3, 4, 5, 6, 7, 8] -> [3, 7, 11, 15] -> [21, 165] -> [186], so the answer is 186.

namespace ArrayConversion
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int arrayConversion(int[] inputArray)
        {
            bool iter = false;
            while (inputArray.Length > 1)
            {
                inputArray = RecConv(inputArray, iter);
                iter = !iter;
            }

            return inputArray[0];

        }

        static int[] RecConv(int[] arr, bool even)
        {
            int[] conv = new int[arr.Length / 2];
            for (int i = 0; i < conv.Length; i++) conv[i] = even ? arr[2 * i] * arr[2 * i + 1] : arr[2 * i] + arr[2 * i + 1];
            return conv;
        }
    }
}
