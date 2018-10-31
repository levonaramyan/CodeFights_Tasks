using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// It's Halloween night! You and your friends are getting ready to go out in the streets to get as much candy as possible.
// You noticed that every year most of the night was wasted walking to the different streets, but this year will be different:
// you will be driving around the city for candy.
//
// Unfortunately starting up the car and stopping will also take a lot of time and many police officers will be around
// the neighborhood to ensure everyone's safety, so you decide on the following plan:
//
// Once getting out of the car, you must visit at least n houses in a row(You could however start anywhere on the street).
// You will only get out of the car once per street.
// You can only visit k streets at most.
// With the data you've acquired from the previous years, you and your friends know how much candy each house will give.
// This data is denoted by streets, where streets[i][j] represents the amount of candy given by the jth house on the ith street.

// Your task is to find the total amount of candy you can get by visiting as many as k streets,
// stopping once to visit at least n houses in a row.

// Example:
//          For streets = [[1, 6, -50, 9, 0], [5,4,3,-3,2]], n = 3, and k = 1,
//          the output should be speedingForCandy(streets, n, k) = 12.
//          Here is the maximum amount of candy you can get in each street:
//          https://i.imgur.com/nbVsNzq.png
//          You and your friends are only visiting 1 street maximum, so you can ignore the first street,
//          which will not be beneficial for the night.

namespace SpeedingForCandy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing test values
            int[][] streets = new int[2][];
            streets[0] = new int[] { 1, 6, -50, 9, 0 };
            streets[1] = new int[] { 5, 4, 3, -3, 2 };
            int n = 3;
            int k = 1;

            // Printing the result of the test
            Console.WriteLine(speedingForCandy(streets,n,k));
            Console.ReadKey();
        }

        static int speedingForCandy(int[][] streets, int n, int k)
        {
            int candies = 0;
            int[] max = new int[streets.Length];

            // for each street, get the maximum candies, which could be gained
            for (int i = 0; i < max.Length; i++)
                max[i] = MaxInStreet(streets[i], n);

            // Sort the array, and get the k biggest ones
            Array.Sort(max);
            for (int i = 0; i < k; i++)
                candies += max[max.Length - 1 - i];
            return candies;
        }

        // Returns a maximum amount of candies (if positive, else 0), from at least n houses in a row
        static int MaxInStreet(int[] h, int n)
        {
            int[] max = new int[h.Length];
            int houses = 0;
            int end = 0;
            int rem = 0;

            // The number of candies from first n houses
            for (int i = 0; i < n; i++)
            {
                houses += h[i];
                max[i] = -10000;
            }

            // Since n-th house, max[i], will contain a number of total candies, from 0-th to i-th house
            max[n - 1] = houses;
            for (int i = n; i < h.Length; i++)
                max[i] += max[i - 1] + h[i];
            houses = max.Max();
            int theMax = houses;
            int maxIndex = Array.LastIndexOf(max, houses);

            // For each starting house, get the maximum amount of candies, until the max[]-s maximum (after i)
            for (int i = n; i < h.Length && h.Length - i >= 0; i++)
            {
                max[i - 1] = -10000;
                rem += h[i - n];
                if (maxIndex == i - 1) { theMax = max.Max(); maxIndex = Array.LastIndexOf(max, theMax); }
                int curMax = theMax - rem;
                houses = curMax > houses ? curMax : houses;
            }

            return (houses > 0 ? houses : 0);
        }
    }
}
