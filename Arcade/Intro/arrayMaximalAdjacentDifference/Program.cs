using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROBLEM: Given an array of integers, find the maximal absolute difference
//          between any two of its adjacent elements.

namespace arrayMaximalAdjacentDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test array
            int[] testArray = new int[] { 2, 35, 1, 0 };

            // Printing the maximum adjacent difference in testArray[]
            Console.WriteLine(arrayMaximalAdjacentDifference(testArray));
            Console.ReadKey();
        }

        // The method calculates and returns the maximum adjacent diff. in inputArray[]
        static int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            // initializing variables
            int maxDiff = 0; // maxDiff will be the maximum adjacent difference
            int arrayLength = inputArray.Length; // the length of inputArray[]

            // calculating the maxDiff
            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (Math.Abs(inputArray[i] - inputArray[i+1]) > maxDiff)

                    maxDiff = Math.Abs(inputArray[i] -inputArray[i+1]);
            }

            // returning the maxDiff
            return maxDiff;
        }
    }
}
