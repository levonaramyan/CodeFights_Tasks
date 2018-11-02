using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given two arrays of integers a and b, obtain the array formed by the elements of a followed by the elements of b.
// Example:
//          For a = [2, 2, 1] and b = [10, 11], the output should be
//          concatenateArrays(a, b) = [2, 2, 1, 10, 11].

namespace ConcatenateArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] a = new int[] { 2, 2, 1 };
            int[] b = new int[] { 10,11 };
            int[] res = concatenateArrays(a, b);
            foreach (int i in res) Console.Write(i + " ");
            Console.ReadKey();
        }

        // Returns the concatenated array a[] , b[]
        static int[] concatenateArrays(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
            }

            for (int i = a.Length; i < a.Length + b.Length; i++)
            {
                c[i] = b[i - a.Length];
            }

            return c;
        }
    }
}
