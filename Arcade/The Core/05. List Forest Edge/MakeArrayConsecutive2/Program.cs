using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ratiorg got statues of different sizes as a present from CodeMaster for his birthday,
// each statue having an non-negative integer size. Since he likes to make things perfect,
// he wants to arrange them from smallest to largest so that each statue will be bigger
// than the previous one exactly by 1. He may need some additional statues to be able to accomplish that.
// Help him figure out the minimum number of additional statues needed.
// Example:
//          For statues = [6, 2, 3, 8], the output should be
//          makeArrayConsecutive2(statues) = 3.
//          Ratiorg needs statues of sizes 4, 5 and 7.

namespace MakeArrayConsecutive2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            int[] test = new int[] { 6, 2, 3, 8 };
            Console.WriteLine(makeArrayConsecutive2(test));
            Console.ReadKey();
        }

        // Returns a number of abscent statues
        static int makeArrayConsecutive2(int[] statues)
        {
            int min = statues[0];
            int max = statues[0];

            // Getting the min and max heights of statues
            for (int i = 1; i < statues.Length; i++)
            {
                if (statues[i] < min) min = statues[i];
                if (statues[i] > max) max = statues[i];
            }

            // The total number of statues should be max-min+1
            // so the number of abscent elements is max - min - statues.Length + 1
            return max - min - statues.Length + 1;
        }
    }
}
