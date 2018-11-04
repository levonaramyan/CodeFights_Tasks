using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// We define the middle of the array arr as follows:
//      if arr contains an odd number of elements, its middle is the element whose index number
//      is the same when counting from the beginning of the array and from its end;
//      if arr contains an even number of elements, its middle is the sum of the two elements
//      whose index numbers when counting from the beginning and from the end of the array differ by one.
// PROBLEM: Given array arr, your task is to find its middle, and, if it consists of two elements,
//          replace those elements with the value of middle. Return the resulting array as the answer.
// Example:
//          For arr = [7, 2, 2, 5, 10, 7], the output should be
//          replaceMiddle(arr) = [7, 2, 7, 10, 7].
//          The middle consists of two elements, 2 and 5. These two elements
//          should be replaced with their sum, i.e. 7.
//
//          For arr = [-5, -5, 10], the output should be
//          replaceMiddle(arr) = [-5, -5, 10].
//          The middle is defined as a single element -5, so the initial array with no changes should be returned.

namespace ReplaceMiddle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] test = new int[] { 7, 2, 2, 5, 10, 7 };
            int[] res = replaceMiddle(test);
            foreach (int i in res) Console.Write(i+" ");
            Console.ReadKey();
        }

        // Returns a new array with updated middle
        static int[] replaceMiddle(int[] arr)
        {
            int middle = 0;
            int[] res = new int[arr.Length - 1];

            // If the lenght of arr is even, then gets the middle two elements and puts their sum instead of them
            if (arr.Length % 2 == 0)
            {
                middle = arr[arr.Length / 2 - 1] + arr[arr.Length / 2];
                for (int i = 0; i < res.Length / 2; i++)
                    res[i] = arr[i];
                res[res.Length / 2] = middle;
                for (int i = res.Length / 2 + 1; i < res.Length; i++)
                {
                    res[i] = arr[i + 1];
                }
            }

            return (arr.Length % 2 == 0) ? res : arr;
        }
    }
}
