using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given an integer size, return array of length size filled with 1s.
// Example:
//          For size = 4, the output should be
//          createArray(size) = [1, 1, 1, 1].

namespace CreateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] testRes = createArray(15);
            foreach (int i in testRes) Console.Write(i + " ");
            Console.ReadKey();
        }

        // Returns an array with given number elements, all of which are 1-s
        static int[] createArray(int size)
        {
            int[] res = new int[size];
            for (int i = 0; i < size; i++)
            {
                res[i] = 1;
            }

            return res;
        }
    }
}
