using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given array of integers, remove each k-th element from it.

namespace extractEachKth
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test array and variable k
            int[] test = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int rem = 3;

            // Testing and printing the result
            int[] testResult = extractEachKth(test, rem);
            foreach (int i in test) Console.Write($"{i}");
            Console.WriteLine();
            foreach (int i in testResult) Console.Write($"{i}");
            Console.ReadKey();
        }

        // The method returns a new array without each k element of inputArray[]
        static int[] extractEachKth(int[] inputArray, int k)
        {
            int aLen = inputArray.Length;
            int[] newArray = new int[aLen - aLen / k];
            int j = 0;
            for (int i = 1; i <= aLen; i++)
            {
                if (i % k != 0)
                {
                    newArray[j] = inputArray[i - 1];
                    j++;
                }
            }

            return newArray;
        }
    }
}
