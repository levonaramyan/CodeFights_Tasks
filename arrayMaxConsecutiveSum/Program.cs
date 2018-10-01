using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given array of integers, find the maximal possible sum of some of its k consecutive elements.

namespace arrayMaxConsecutiveSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intitializng test array and a number of k elements
            int[] test = new int[] { 1, 2, 3, 9, 4, 5, 6, 7, 8 };
            int k = 4;

            // testing adn printing the result
            Console.WriteLine(arrayMaxConsecutiveSum(test,k));
            Console.ReadKey();
        }

        // The method returns the maximum value of k consecutive elements in inputArray[]
        static int arrayMaxConsecutiveSum(int[] inputArray, int k)
        {
            int aLen = inputArray.Length;

            int maxsum = 0;

            for (int i = 0; i <= aLen - k; i++)
            {
                int sum = 0;
                for (int j = i; j < i + k; j++)
                {
                    sum += inputArray[j];
                }

                if (sum > maxsum) maxsum = sum;
            }

            return maxsum;

        }
    }
}
