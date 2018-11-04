using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Remove a part of a given array between given 0-based indexes l and r (inclusive).

// Example:
//          For inputArray = [2, 3, 2, 3, 4, 5], l = 2, and r = 4, the output should be
//          removeArrayPart(inputArray, l, r) = [2, 3, 5].

namespace RemoveArrayPart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing Test values
            int[] test = new int[] { 2, 3, 2, 3, 4, 5 };
            int l = 2, r = 4;

            // Testing and printing the result
            int[] res = removeArrayPart(test, l, r);
            foreach (int i in res) Console.Write(i + " ");
            Console.ReadKey();
            
        }

        // Returns a new array where elements from l to r are abscent
        static int[] removeArrayPart(int[] inputArray, int l, int r)
        {
            int[] res = new int[inputArray.Length - r + l - 1];
            for (int i = 0; i < l; i++)
                res[i] = inputArray[i];
            for (int i = l; i < inputArray.Length - r + l - 1; i++)
                res[i] = inputArray[i + r - l + 1];

            return res;
        }
    }
}
