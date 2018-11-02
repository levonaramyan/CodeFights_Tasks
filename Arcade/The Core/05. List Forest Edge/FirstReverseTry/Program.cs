using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Reversing an array can be a tough task, especially for a novice programmer.
// Mary just started coding, so she would like to start with something basic at first.
// Instead of reversing the array entirely, she wants to swap just its first and last elements.

// Given an array arr, swap its first and last elements and return the resulting array.

// Example:
//          For arr = [1, 2, 3, 4, 5], the output should be
//          firstReverseTry(arr) = [5, 2, 3, 4, 1].

namespace FirstReverseTry
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] test = new int[] { 1, 2, 3, 4, 5 };
            int[] res = firstReverseTry(test);
            foreach (int i in res) Console.Write(i + " ");
            Console.ReadKey();
        }

        // Swaps the first and last elements of an array
        static int[] firstReverseTry(int[] arr)
        {
            if (arr.Length > 1)
            {
                int temp = arr[0];
                arr[0] = arr[arr.Length - 1];
                arr[arr.Length - 1] = temp;
            }


            return arr;
        }
    }
}
