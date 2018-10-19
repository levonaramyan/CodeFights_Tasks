using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You found two items in a treasure chest! The first item weighs weight1 and is worth value1,
// and the second item weighs weight2 and is worth value2. What is the total maximum value
// of the items you can take with you, assuming that your max weight capacity is maxW
// and you can't come back for the items later?

// Note that there are only two items and you can't bring more than one item of each type,
// i.e. you can't take two first items or two second items.

namespace KnapsackLight
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing and printing the result
            Console.WriteLine(knapsackLight(15,2,25,4,5));
            Console.ReadKey();
        }

        // Return the maximum value that could be obtained with taking less than maxW weight.
        static int knapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
        {
            int max = 0;
            if (weight1 + weight2 <= maxW)
            {
                max = value1 + value2;
            }
            else
            {
                if (weight1 <= maxW) max = value1;
                if (weight2 <= maxW && value2 >= value1) max = value2;
            }

            return max;

        }
    }
}
