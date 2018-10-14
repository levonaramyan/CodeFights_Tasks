using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// You are given an array of integers.On each move you are allowed to increase exactly 
// one of its element by one.Find the minimal number of moves required to obtain
//a strictly increasing sequence from the input.

namespace arrayChange
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing a test array
            int[] testArray = new int[] { 2, 2, 10, 1 };

            // Printing out the steps for test array
            Console.WriteLine(arrayChange(testArray));
            Console.ReadKey();

        }

        // The method calculates the minimum necessary steps for inputArray[]
        // in order to make it strictly increasing
        static int arrayChange(int[] inputArray)
        {
            // Initializing variables
            int arrayLenght = inputArray.Length; // The length of inputArray[]
            int steps = 0; // will be the overall steps that are necessary

            // calculating the steps
            for (int i = 1; i < arrayLenght; i++)
            {
                if ( inputArray[i] <= inputArray [i-1])
                {
                    int diff = inputArray[i - 1] - inputArray[i] + 1;
                    steps += diff;
                    inputArray[i] += diff;
                }
            }

            // returning the sum of minimum necessary steps
            return steps;
        }
    }
}
