using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given array of integers, for each position i, search among the previous positions for the last
// (from the left) position that contains a smaller value. Store this value at position i in the answer.
// If no such value can be found, store -1 instead.
// Example:
//          For items = [3, 5, 2, 4, 5], the output should be
//          arrayPreviousLess(items) = [-1, 3, -1, 2, 4].

namespace ArrayPreviousLess
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] arrayPreviousLess(int[] items)
        {
            int[] res = new int[items.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (items[j] < items[i])
                    {
                        res[i] = items[j];
                        break;
                    }
                }
            }

            return res;

        }

    }
}
