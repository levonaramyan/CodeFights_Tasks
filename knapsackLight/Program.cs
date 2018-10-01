using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You found two items in a treasure chest! The first item weighs weight1
// and is worth value1, and the second item weighs weight2 and is worth value2.

// PROBLEM: What is the total maximum value of the items you can take with you, assuming
//          that your max weight capacity is maxW and you can't come back for the items latesr?

// Note that there are only two items and you can't bring more than one item of each type,
// i.e. you can't take two first items or two second items.

namespace knapsackLight
{
    class Program
    {
        static void Main(string[] args)
        {
            // testing and printing the result
            Console.WriteLine(knapsackLight(5, 6, 4, 3, 10));
            Console.ReadKey();
        }

        // The method returns the max value that can be taken, with no more than maxW weight
        static int knapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
        {
            int maxValue = 0;
            int[] values = new int[] { value1, value2, value1 + value2 };
            int[] weights = new int[] { weight1, weight2, weight1 + weight2 };

            for (int i = 0; i <= 2; i++)
            {
                if (weights[i] <= maxW && values[i] >= maxValue) maxValue = values[i];
            }

            return maxValue;
        }
    }
}
